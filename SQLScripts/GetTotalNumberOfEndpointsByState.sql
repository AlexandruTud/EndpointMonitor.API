/****** Object:  StoredProcedure [dbo].[GetTotalNumberOfEndpointsByState]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetTotalNumberOfEndpointsByState]
AS
BEGIN
    SET NOCOUNT ON;

    -- Declare variables
    DECLARE @TotalStableEndpoints INT = 0;
    DECLARE @TotalUnstableEndpoints INT = 0;
    DECLARE @TotalDownEndpoints INT = 0;

    -- Cursor for iterating through endpoints
    DECLARE endpoint_cursor CURSOR FOR
        SELECT IdEndpoint FROM [iTEC Hackathon].[dbo].[Endpoints];
    OPEN endpoint_cursor;

    -- Loop through each endpoint
    DECLARE @EndpointId INT; -- Declare @EndpointId here

    FETCH NEXT FROM endpoint_cursor INTO @EndpointId;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @StableCount INT;
        DECLARE @UnstableCount INT;
        DECLARE @DownCount INT;

        -- Count the number of stable, unstable, and down states for the current endpoint
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

        SET @DownCount = (SELECT COUNT(*) FROM (
            SELECT TOP 10 Code
            FROM [iTEC Hackathon].[dbo].[EndpointHistory]
            WHERE IdEndpoint = @EndpointId
            ORDER BY DateCreated DESC
        ) AS T
        WHERE Code NOT IN (200, 302));

        -- Determine the state for the current endpoint
        IF @DownCount = 10
            SET @TotalDownEndpoints += 1;
        ELSE IF @UnstableCount > 0
            SET @TotalUnstableEndpoints += 1;
        ELSE
        BEGIN
            -- Check if the endpoint is present in ApplicationReports with MarkedAsSolved = 0
            IF EXISTS (
                SELECT 1
                FROM [iTEC Hackathon].[dbo].[ApplicationReports]
                WHERE IdEndpoint = @EndpointId AND MarkedAsSolved = 0
            )
            BEGIN
                -- Increment @TotalUnstableEndpoints if IdEndpoint is present in ApplicationReports with MarkedAsSolved = 0
                SET @TotalUnstableEndpoints += 1;
            END
            ELSE
            BEGIN
                -- Increment @TotalStableEndpoints if IdEndpoint is not present in ApplicationReports with MarkedAsSolved = 0
                SET @TotalStableEndpoints += 1;
            END;
        END;

        FETCH NEXT FROM endpoint_cursor INTO @EndpointId;
    END;

    CLOSE endpoint_cursor;
    DEALLOCATE endpoint_cursor;

    -- Return the total numbers of endpoints by state
    SELECT @TotalStableEndpoints AS TotalStableEndpoints,
           @TotalUnstableEndpoints AS TotalUnstableEndpoints,
           @TotalDownEndpoints AS TotalDownEndpoints;
END;
GO