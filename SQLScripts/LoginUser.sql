/****** Object:  StoredProcedure [dbo].[LoginUser]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoginUser]
    @Email NVARCHAR(255),
    @Password NVARCHAR(255),
    @UserID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT @UserID = IdUser
    FROM [iTEC Hackathon].[dbo].[Users]
    WHERE Email = @Email
    AND Password = @Password;

	IF @UserID IS NULL
    BEGIN
        SET @UserID = -1 
    END

END;
GO