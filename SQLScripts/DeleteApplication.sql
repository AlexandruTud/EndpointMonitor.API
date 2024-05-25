/****** Object:  StoredProcedure [dbo].[DeleteApplication]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteApplication]
    @IdApplication INT,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM [iTEC Hackathon].[dbo].[Applications] WHERE [IdApplication] = @IdApplication)
    BEGIN
        DELETE FROM [iTEC Hackathon].[dbo].[Applications] WHERE [IdApplication] = @IdApplication;
        SET @Success = 1; -- Deletion succeeded
    END
    ELSE
    BEGIN
        SET @Success = 0; -- Deletion failed (no row found with the given IdApplication)
    END
END;
GO