/****** Object:  StoredProcedure [dbo].[GetIsUserAuthor]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetIsUserAuthor]
    @IdUser INT,
    @IdApplication INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IsUserAuthor BIT;

    -- Check if the IdUserAuthor of the application matches the provided IdUser
    IF EXISTS (
        SELECT 1
        FROM [iTEC Hackathon].[dbo].[Applications]
        WHERE IdApplication = @IdApplication
        AND IdUserAuthor = @IdUser
    )
    BEGIN
        SET @IsUserAuthor = 1;
    END
    ELSE
    BEGIN
        SET @IsUserAuthor = 0;
    END

    -- Return 1 if the user is the author of the application, otherwise return 0
    SELECT @IsUserAuthor AS isAuthor;
END;
GO