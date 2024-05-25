/****** Object:  StoredProcedure [dbo].[GetApplicationById]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetApplicationById]
    @IdApplication INT
AS
BEGIN
    SET NOCOUNT ON;

	EXEC [dbo].[UpdateApplicationStateForAllApplications];

    SELECT A.[Name],
           A.[Description],
		   U.IdUser,
           U.[Email] AS [UserEmail],
           AS1.[State] AS [ApplicationState],
           A.[Image],
           A.[DateCreated]
    FROM [iTEC Hackathon].[dbo].[Applications] A
    LEFT JOIN [iTEC Hackathon].[dbo].[Users] U ON A.[IdUserAuthor] = U.[IdUser]
    LEFT JOIN [iTEC Hackathon].[dbo].[ApplicationStates] AS1 ON A.[IdApplicationState] = AS1.[IdApplicationState]
    WHERE A.[IdApplication] = @IdApplication;
END;
GO