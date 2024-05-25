/****** Object:  StoredProcedure [dbo].[InsertNotification]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[InsertNotification]
    @IdReceiver INT,
    @IdSender INT,
    @Text NVARCHAR(MAX),
    @DateCreated DATETIME,
    @IdApplication INT,
    @IdEndpoint INT
AS
BEGIN
    INSERT INTO [iTEC Hackathon].[dbo].[Notifications] (IdReceiver, IdSender, Text, DateCreated, IdApplication, IdEndpoint)
    VALUES (@IdReceiver, @IdSender, @Text, @DateCreated, @IdApplication, @IdEndpoint)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertReport]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertReport]
    @IdApplication INT,
    @IdEndpoint INT,
    @DateCreated DATETIME,
    @IdUser INT,
	@MarkedAsSolved INT,
    @Mentions NVARCHAR(MAX),
    @IdApplicationReport INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO [iTEC Hackathon].[dbo].[ApplicationReports] ([IdApplication], [IdEndpoint], [DateCreated], [IdUser], [MarkedAsSolved], [Mentions])
        VALUES (@IdApplication, @IdEndpoint, @DateCreated, @IdUser, @MarkedAsSolved, @Mentions);

        SET @IdApplicationReport = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        SET @IdApplicationReport = 0;
    END CATCH;
END;
GO