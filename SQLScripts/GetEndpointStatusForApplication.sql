/****** Object:  StoredProcedure [dbo].[GetEndpointStatusForApplication]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEndpointStatusForApplication]
    @IdApplication INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StableCount INT = 0;
    DECLARE @UnstableCount INT = 0;
    DECLARE @DownCount INT = 0;
    DECLARE @ApplicationState NVARCHAR(50);

    CREATE TABLE #EndpointStates (
        IdEndpoint INT,
        URL NVARCHAR(MAX),
        EndpointState NVARCHAR(50),
        Type NVARCHAR(MAX),
        DateCreated DATETIME
    );

    INSERT INTO #EndpointStates (IdEndpoint, URL, EndpointState, Type, DateCreated)
    EXEC [dbo].[GetEndpointsByApplicationId] @IdApplication = @IdApplication;

    SELECT 
        @StableCount = SUM(CASE WHEN EndpointState = 'Stable' THEN 1 ELSE 0 END),
        @UnstableCount = SUM(CASE WHEN EndpointState = 'Unstable' THEN 1 ELSE 0 END),
        @DownCount = SUM(CASE WHEN EndpointState = 'Down' THEN 1 ELSE 0 END)
    FROM #EndpointStates;

    IF @StableCount = (SELECT COUNT(*) FROM #EndpointStates)
        SET @ApplicationState = 'Stable';
    ELSE IF @StableCount >= 1 AND @StableCount <= 9
        SET @ApplicationState = 'Unstable';
    ELSE
        SET @ApplicationState = 'Down';

    SELECT 
        @ApplicationState AS ApplicationState;

    DROP TABLE IF EXISTS #EndpointStates;
END;
GO