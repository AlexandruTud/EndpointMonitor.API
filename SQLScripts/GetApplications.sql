/****** Object:  StoredProcedure [dbo].[GetApplications]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetApplications]
    @IdUserAuthor INT
AS
BEGIN
    SET NOCOUNT ON;
	EXEC [dbo].[UpdateApplicationStateForAllApplications];

    SELECT A.[IdApplication],
           A.[Name],
           A.[Description],
           A.[Image], -- Include the Image column
           U.[Email] AS [UserEmail],
           AS1.[State] AS [ApplicationState],
           A.[DateCreated]
    FROM [iTEC Hackathon].[dbo].[Applications] A
    LEFT JOIN [iTEC Hackathon].[dbo].[ApplicationStates] AS1 ON A.[IdApplicationState] = AS1.[IdApplicationState]
    LEFT JOIN [iTEC Hackathon].[dbo].[Users] U ON A.[IdUserAuthor] = U.[IdUser]
    WHERE @IdUserAuthor = 0 OR A.[IdUserAuthor] = @IdUserAuthor;
END;
GO