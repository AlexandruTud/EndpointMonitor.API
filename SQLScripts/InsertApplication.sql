/****** Object:  StoredProcedure [dbo].[InsertApplication]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[InsertApplication]
    @Name NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @IdUserAuthor INT,
    @IdApplicationState INT,
    @DateCreated DATETIME,
    @Image NVARCHAR(MAX), -- Add parameter for the Image column
    @IdApplication INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO [iTEC Hackathon].[dbo].[Applications] ([Name], [Description], [IdUserAuthor], [IdApplicationState], [DateCreated], [Image])
    VALUES (@Name, @Description, @IdUserAuthor, @IdApplicationState, @DateCreated, @Image);

    SET @IdApplication = SCOPE_IDENTITY();
END;
GO