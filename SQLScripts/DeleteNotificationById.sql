/****** Object:  StoredProcedure [dbo].[DeleteNotificationById]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[DeleteNotificationById]
    @IdNotification INT
AS
BEGIN
    DELETE FROM [iTEC Hackathon].[dbo].[Notifications]
    WHERE IdNotification = @IdNotification
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteReport]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteReport]
    @IdApplicationReport INT,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM [iTEC Hackathon].[dbo].[ApplicationReports]
        WHERE [IdApplicationReport] = @IdApplicationReport;

        SET @Success = 1; -- Deletion succeeded
    END TRY
    BEGIN CATCH
        SET @Success = 0; -- Deletion failed
    END CATCH;
END;
GO