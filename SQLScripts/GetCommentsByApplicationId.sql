/****** Object:  StoredProcedure [dbo].[GetCommentsByApplicationId]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCommentsByApplicationId]
    @IdApplication INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT IdComment, IdApplication, c.IdUser, u.Email, Comment, DateComented
    FROM Comments as c
	inner join Users as u on c.IdUser = u.IdUser
    WHERE IdApplication = @IdApplication
    ORDER BY DateComented DESC;
END;
GO