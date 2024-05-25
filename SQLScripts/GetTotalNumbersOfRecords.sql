/****** Object:  StoredProcedure [dbo].[GetTotalNumbersOfRecords]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetTotalNumbersOfRecords]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TotalApplications INT;
    DECLARE @TotalEndpoints INT;
    DECLARE @TotalUsers INT;
    DECLARE @TotalEndpointHistoryRecords INT;

    -- Get total number of records in Applications table
    SELECT @TotalApplications = COUNT(*)
    FROM [iTEC Hackathon].[dbo].[Applications];

    -- Get total number of records in Endpoints table
    SELECT @TotalEndpoints = COUNT(*)
    FROM [iTEC Hackathon].[dbo].[Endpoints];

    -- Get total number of records in Users table
    SELECT @TotalUsers = COUNT(*)
    FROM [iTEC Hackathon].[dbo].[Users];

    -- Get total number of records in EndpointHistory table
    SELECT @TotalEndpointHistoryRecords = COUNT(*)
    FROM [iTEC Hackathon].[dbo].[EndpointHistory];

    -- Return the total numbers of records
    SELECT @TotalApplications AS TotalApplications,
           @TotalEndpoints AS TotalEndpoints,
           @TotalUsers AS TotalUsers,
           @TotalEndpointHistoryRecords AS TotalEndpointHistoryRecords;
END;
GO