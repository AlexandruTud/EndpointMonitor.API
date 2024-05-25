/****** Object:  StoredProcedure [dbo].[UpdateApplication]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[UpdateApplication]
    @IdApplication INT,
    @IdState INT,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the application with the specified IdApplication exists
    IF EXISTS (SELECT 1 FROM [iTEC Hackathon].[dbo].[Applications] WHERE [IdApplication] = @IdApplication)
    BEGIN
        -- Update the IdApplicationState
        UPDATE [iTEC Hackathon].[dbo].[Applications]
        SET [IdApplicationState] = @IdState
        WHERE [IdApplication] = @IdApplication;

        SET @Success = 1; -- Update successful
    END
    ELSE
    BEGIN
        SET @Success = 0; -- Application not found, update failed
    END
END;
GO