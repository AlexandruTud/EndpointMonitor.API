/****** Object:  StoredProcedure [dbo].[UpdateApplicationStateForAllApplications]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateApplicationStateForAllApplications]
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE A
    SET A.[IdApplicationState] = CASE
                                     WHEN NOT EXISTS (
                                         SELECT 1
                                         FROM [dbo].[Endpoints] E
                                         INNER JOIN [dbo].[EndpointHistory] EH ON E.[IdEndpoint] = EH.[IdEndpoint]
                                         WHERE E.[IdApplication] = A.[IdApplication]
                                           AND EH.[DateCreated] = (
                                               SELECT MAX(EH2.[DateCreated])
                                               FROM [dbo].[EndpointHistory] EH2
                                               WHERE EH2.[IdEndpoint] = EH.[IdEndpoint]
                                           )
                                           AND EH.[Code] <> 200
                                     )
                                         THEN 1 
                                     WHEN EXISTS (
                                         SELECT 1
                                         FROM [dbo].[Endpoints] E
                                         INNER JOIN [dbo].[EndpointHistory] EH ON E.[IdEndpoint] = EH.[IdEndpoint]
                                         WHERE E.[IdApplication] = A.[IdApplication]
                                           AND EH.[DateCreated] = (
                                               SELECT MAX(EH2.[DateCreated])
                                               FROM [dbo].[EndpointHistory] EH2
                                               WHERE EH2.[IdEndpoint] = EH.[IdEndpoint]
                                           )
                                           AND EH.[Code] <> 200
                                           AND EH.[Code] <= 3
                                     )
                                         THEN 2 
                                     WHEN NOT EXISTS (
                                         SELECT 1
                                         FROM [dbo].[Endpoints] E
                                         INNER JOIN [dbo].[EndpointHistory] EH ON E.[IdEndpoint] = EH.[IdEndpoint]
                                         WHERE E.[IdApplication] = A.[IdApplication]
                                           AND EH.[DateCreated] = (
                                               SELECT MAX(EH2.[DateCreated])
                                               FROM [dbo].[EndpointHistory] EH2
                                               WHERE EH2.[IdEndpoint] = EH.[IdEndpoint]
                                           )
                                           AND EH.[Code] = 200
                                     )
                                         THEN 3 
                                     ELSE 3 
                                 END
    FROM [dbo].[Applications] A;
END;
GO