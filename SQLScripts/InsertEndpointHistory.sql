/****** Object:  StoredProcedure [dbo].[InsertEndpointHistory]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertEndpointHistory]
    @DateCreated DATETIME,
    @Mentions NVARCHAR(MAX),
    @IdEndpoint INT,
    @IdUser INT,
    @Code INT,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Attempt to insert into EndpointHistory
        INSERT INTO [iTEC Hackathon].[dbo].[EndpointHistory] ([DateCreated], [Mentions], [IdEndpoint], [IdUser], [Code])
        VALUES (@DateCreated, @Mentions, @IdEndpoint, @IdUser, @Code);

        -- If successful, set @Success to 1
        SET @Success = 1;
    END TRY
    BEGIN CATCH
        -- If an error occurs, set @Success to 0
        SET @Success = 0;

        -- Log the error message
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END;
GO