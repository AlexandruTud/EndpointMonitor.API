/****** Object:  StoredProcedure [dbo].[GetTotalNumberOfReportsBySolved]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetTotalNumberOfReportsBySolved]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TotalSolvedReports INT;
    DECLARE @TotalUnsolvedReports INT;

    -- Calculate total number of reports marked as solved
    SELECT @TotalSolvedReports = COUNT(*)
    FROM [iTEC Hackathon].[dbo].[ApplicationReports]
    WHERE MarkedAsSolved = 1;

    -- Calculate total number of reports marked as unsolved
    SELECT @TotalUnsolvedReports = COUNT(*)
    FROM [iTEC Hackathon].[dbo].[ApplicationReports]
    WHERE MarkedAsSolved = 0;

    -- Return the results
    SELECT @TotalSolvedReports AS TotalSolvedReports, @TotalUnsolvedReports AS TotalUnsolvedReports;
END;
GO