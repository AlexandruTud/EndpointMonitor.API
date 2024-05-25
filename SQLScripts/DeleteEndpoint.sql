/****** Object:  StoredProcedure [dbo].[DeleteEndpoint]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteEndpoint]
    @IdEndpoint INT,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Start a transaction
        BEGIN TRANSACTION;

        -- Delete from ApplicationReports
        DELETE FROM [iTEC Hackathon].[dbo].[ApplicationReports]
        WHERE [IdEndpoint] = @IdEndpoint;

        -- Delete from EndpointHistory
        DELETE FROM [iTEC Hackathon].[dbo].[EndpointHistory]
        WHERE [IdEndpoint] = @IdEndpoint;

        -- Delete from Notifications
        DELETE FROM [iTEC Hackathon].[dbo].[Notifications]
        WHERE [IdEndpoint] = @IdEndpoint;

        -- Delete from Endpoints
        DELETE FROM [iTEC Hackathon].[dbo].[Endpoints]
        WHERE [IdEndpoint] = @IdEndpoint;

        -- Commit the transaction
        COMMIT TRANSACTION;

        SET @Success = 1; -- Set Success variable to 1 if the deletion succeeded
    END TRY
    BEGIN CATCH
        -- Rollback the transaction in case of error
        ROLLBACK TRANSACTION;

        SET @Success = 0; -- Set Success variable to 0 if an error occurred
    END CATCH;
END;
GO