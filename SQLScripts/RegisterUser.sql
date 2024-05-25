/****** Object:  StoredProcedure [dbo].[RegisterUser]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterUser]
    @Email NVARCHAR(255),
    @Password NVARCHAR(255),
    @UserID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO [iTEC Hackathon].[dbo].[Users] ([Email], [Password])
    VALUES (@Email, @Password);

    SET @UserID = SCOPE_IDENTITY();
END;
GO