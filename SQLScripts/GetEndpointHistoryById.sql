/****** Object:  StoredProcedure [dbo].[GetEndpointHistoryById]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEndpointHistoryById]
    @IdEndpoint INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [Code],
        [DateCreated]
    FROM 
        [dbo].[EndpointHistory]
    WHERE 
        [IdEndpoint] = @IdEndpoint;
END
GO
/****** Object:  StoredProcedure [dbo].[GetEndpointsByApplicationId]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEndpointsByApplicationId]
    @IdApplication INT
AS
BEGIN
    SET NOCOUNT ON;

    CREATE TABLE #TempEndpoints (
        IdEndpoint INT,
        URL NVARCHAR(MAX),
        Type NVARCHAR(MAX),
        DateCreated DATETIME,
        IdApplication INT
    );

    INSERT INTO #TempEndpoints (IdEndpoint, URL, Type, DateCreated, IdApplication)
    SELECT e.IdEndpoint, e.URL, t.Type, e.DateCreated, e.IdApplication
    FROM [iTEC Hackathon].[dbo].[Endpoints] e
    INNER JOIN [iTEC Hackathon].[dbo].[Types] t ON e.IdType = t.IdType
    WHERE e.IdApplication = @IdApplication;

    DECLARE @IdEndpoint INT;
    DECLARE @EndpointState NVARCHAR(50);

    DECLARE endpoint_cursor CURSOR FOR
        SELECT IdEndpoint FROM #TempEndpoints;
    OPEN endpoint_cursor;
    FETCH NEXT FROM endpoint_cursor INTO @IdEndpoint;

    CREATE TABLE #EndpointStateResults (
        IdEndpoint INT,
        URL NVARCHAR(MAX),
        EndpointState NVARCHAR(50),
        Type NVARCHAR(MAX),
        DateCreated DATETIME
    );

    WHILE @@FETCH_STATUS = 0
    BEGIN
        CREATE TABLE #RecentEndpointHistoryCodes (
            Code INT
        );

        INSERT INTO #RecentEndpointHistoryCodes (Code)
        SELECT TOP 10 Code
        FROM [iTEC Hackathon].[dbo].[EndpointHistory]
        WHERE IdEndpoint = @IdEndpoint
        ORDER BY DateCreated DESC;

        IF (SELECT COUNT(*) FROM #RecentEndpointHistoryCodes WHERE Code NOT IN (200, 302)) = 0
            SET @EndpointState = 'Stable';
        ELSE IF (SELECT COUNT(*) FROM #RecentEndpointHistoryCodes WHERE Code NOT IN (200, 302)) = 10
            SET @EndpointState = 'Down';
        ELSE
            SET @EndpointState = 'Unstable';

        IF @EndpointState = 'Stable'
        BEGIN
            DECLARE @IsUnsolved BIT;

            SELECT @IsUnsolved = CASE WHEN EXISTS (
                SELECT 1 
                FROM [iTEC Hackathon].[dbo].[ApplicationReports] 
                WHERE IdEndpoint = @IdEndpoint AND MarkedAsSolved = 0
            ) THEN 1 ELSE 0 END;

            IF @IsUnsolved = 1
                SET @EndpointState = 'Unstable';
        END;

        INSERT INTO #EndpointStateResults (IdEndpoint, URL, EndpointState, Type, DateCreated)
        SELECT IdEndpoint, URL, @EndpointState, Type, DateCreated
        FROM #TempEndpoints
        WHERE IdEndpoint = @IdEndpoint;

        DROP TABLE #RecentEndpointHistoryCodes;

        FETCH NEXT FROM endpoint_cursor INTO @IdEndpoint;
    END;

    CLOSE endpoint_cursor;
    DEALLOCATE endpoint_cursor;

    SELECT * FROM #EndpointStateResults;

    DROP TABLE #TempEndpoints;
    DROP TABLE #EndpointStateResults;
END;
GO