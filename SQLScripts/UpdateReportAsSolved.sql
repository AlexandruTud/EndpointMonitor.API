/****** Object:  StoredProcedure [dbo].[UpdateReportAsSolved]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateReportAsSolved]
    @IdApplicationReport INT,
    @MarkedAsSolved INT,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Update the MarkedAsSolved column
        UPDATE [iTEC Hackathon].[dbo].[ApplicationReports]
        SET MarkedAsSolved = @MarkedAsSolved
        WHERE IdApplicationReport = @IdApplicationReport;

        -- Set Success variable to 1 indicating success
        SET @Success = 1;
    END TRY
    BEGIN CATCH
        -- If an error occurs, set Success variable to 0 indicating failure
        SET @Success = 0;
    END CATCH;
END;
GO