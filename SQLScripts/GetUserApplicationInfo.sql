/****** Object:  StoredProcedure [dbo].[GetUserApplicationInfo]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserApplicationInfo]
    @IdUser INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Temporary table to store application information
    CREATE TABLE #TempApplications (
        IdApplication INT,
        Name NVARCHAR(255),
        Description NVARCHAR(MAX),
        IdUserAuthor INT,
        IdApplicationState INT,
        DateCreated DATETIME,
        Image NVARCHAR(255)
    );

    -- Temporary table to store endpoint information
    CREATE TABLE #TempEndpoints (
        IdEndpoint INT,
        URL NVARCHAR(MAX),
        IdType INT,
        DateCreated DATETIME,
        IdApplication INT
    );

    -- Inserting application information
    INSERT INTO #TempApplications (IdApplication, Name, Description, IdUserAuthor, IdApplicationState, DateCreated, Image)
    SELECT IdApplication, Name, Description, IdUserAuthor, IdApplicationState, DateCreated, Image
    FROM [iTEC Hackathon].[dbo].[Applications]
    WHERE IdUserAuthor = @IdUser;

    -- Inserting endpoint information
    INSERT INTO #TempEndpoints (IdEndpoint, URL, IdType, DateCreated, IdApplication)
    SELECT IdEndpoint, URL, IdType, DateCreated, IdApplication
    FROM [iTEC Hackathon].[dbo].[Endpoints]
    WHERE IdApplication IN (SELECT IdApplication FROM #TempApplications);

    -- Getting counts
    DECLARE @NrOfApplications INT;
    DECLARE @NrOfEndpoints INT;
    DECLARE @NrOfEndpointsStable INT = 0;
    DECLARE @NrOfEndpointsUnstable INT = 0;
    DECLARE @NrOfEndpointsDown INT = 0;

    SELECT @NrOfApplications = COUNT(*) FROM #TempApplications;
    SELECT @NrOfEndpoints = COUNT(*) FROM #TempEndpoints;

    -- Getting user email
    DECLARE @UserEmail NVARCHAR(255);
    SELECT @UserEmail = Email FROM [iTEC Hackathon].[dbo].[Users] WHERE IdUser = @IdUser;

    -- Calculating endpoint statuses
    DECLARE @EndpointId INT;
    DECLARE @Code INT;

    DECLARE endpoint_cursor CURSOR FOR
        SELECT IdEndpoint FROM #TempEndpoints;
    OPEN endpoint_cursor;
    FETCH NEXT FROM endpoint_cursor INTO @EndpointId;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @StableCount INT;
        DECLARE @UnstableCount INT;
        DECLARE @DownCount INT;
        
        SELECT @StableCount = COUNT(*) FROM (
            SELECT TOP 10 Code
            FROM [iTEC Hackathon].[dbo].[EndpointHistory]
            WHERE IdEndpoint = @EndpointId
            ORDER BY DateCreated DESC
        ) AS T
        WHERE Code = 200 OR Code = 302;
        
        SELECT @UnstableCount = COUNT(*) FROM (
            SELECT TOP 10 Code
            FROM [iTEC Hackathon].[dbo].[EndpointHistory]
            WHERE IdEndpoint = @EndpointId
            ORDER BY DateCreated DESC
        ) AS T
        WHERE Code != 200 AND Code != 302;

        -- Inside the cursor loop for calculating endpoint statuses
        SET @DownCount = (SELECT COUNT(*) FROM (
            SELECT TOP 10 Code
            FROM [iTEC Hackathon].[dbo].[EndpointHistory]
            WHERE IdEndpoint = @EndpointId
            ORDER BY DateCreated DESC
        ) AS T
        WHERE Code NOT IN (200, 302));

        IF @DownCount = 10
            SET @NrOfEndpointsDown += 1;
        ELSE IF @UnstableCount > 0
            SET @NrOfEndpointsUnstable += 1;
        ELSE
        BEGIN
            -- Check if the endpoint is present in ApplicationReports with MarkedAsSolved = 0
            IF EXISTS (
                SELECT 1
                FROM [iTEC Hackathon].[dbo].[ApplicationReports]
                WHERE IdEndpoint = @EndpointId AND MarkedAsSolved = 0
            )
            BEGIN
                -- Increment NrOfEndpointsUnstable if IdEndpoint is present in ApplicationReports with MarkedAsSolved = 0
                SET @NrOfEndpointsUnstable += 1;
            END
            ELSE
            BEGIN
                -- Increment NrOfEndpointsStable if IdEndpoint is not present in ApplicationReports with MarkedAsSolved = 0
                SET @NrOfEndpointsStable += 1;
            END;
        END;

        FETCH NEXT FROM endpoint_cursor INTO @EndpointId;
    END;

    CLOSE endpoint_cursor;
    DEALLOCATE endpoint_cursor;

    -- Returning application, endpoint counts, and user email
    SELECT @NrOfApplications AS NrOfApplications, @NrOfEndpoints AS NrOfEndpoints, @NrOfEndpointsStable AS NrOfEndpointsStable, @NrOfEndpointsUnstable AS NrOfEndpointsUnstable, @NrOfEndpointsDown AS NrOfEndpointsDown, @UserEmail AS Email;

    -- Dropping temporary tables
    DROP TABLE #TempApplications;
    DROP TABLE #TempEndpoints;
END;
GO