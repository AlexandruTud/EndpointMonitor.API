CREATE PROCEDURE [dbo].[AddComment]
    @IdApplication INT,
    @IdUser INT,
    @Comment VARCHAR(MAX),
    @DateComented DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Comments (IdApplication, IdUser, Comment, DateComented)
    VALUES (@IdApplication, @IdUser, @Comment, @DateComented);
END;
GO