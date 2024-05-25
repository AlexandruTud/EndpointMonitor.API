/****** Object:  StoredProcedure [dbo].[InsertEndpoint]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertEndpoint]
    @URL NVARCHAR(MAX),
    @IdType INT,
    @DateCreated DATETIME,
    @IdApplication INT,
    @IdEndpoint INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO [iTEC Hackathon].[dbo].[Endpoints] ([URL], [IdType], [DateCreated], [IdApplication])
        VALUES (@URL, @IdType, @DateCreated, @IdApplication);

        SET @IdEndpoint = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        SET @IdEndpoint = 0;
    END CATCH;
END;
GO