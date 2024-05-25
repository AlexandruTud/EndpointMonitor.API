/****** Object:  StoredProcedure [dbo].[GetNotificationsByReceiver]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNotificationsByReceiver]
    @IdReceiver INT
AS
BEGIN
    SELECT 
        N.IdNotification, 
        N.IdReceiver,
		E.IdEndpoint,
        N.IdSender, 
        U_sender.Email AS SenderEmail, 
        N.Text, 
        N.DateCreated,
        A.Name AS ApplicationName, 
        E.URL AS EndpointURL, 
        ET.Type AS EndpointType,
        AR.IdApplicationReport AS ReportId

    FROM 
        [iTEC Hackathon].[dbo].[Notifications] N
    INNER JOIN 
        [iTEC Hackathon].[dbo].[Users] U_sender ON N.IdSender = U_sender.IdUser
    INNER JOIN 
        [iTEC Hackathon].[dbo].[Applications] A ON N.IdApplication = A.IdApplication
    INNER JOIN 
        [iTEC Hackathon].[dbo].[Endpoints] E ON N.IdEndpoint = E.IdEndpoint
    INNER JOIN 
        [iTEC Hackathon].[dbo].[Types] ET ON E.IdType = ET.IdType
    LEFT JOIN 
        [iTEC Hackathon].[dbo].[ApplicationReports] AR ON N.IdSender = AR.IdUser 
            AND N.IdApplication = AR.IdApplication 
            AND N.IdEndpoint = AR.IdEndpoint 
            AND N.Text = AR.Mentions
    WHERE 
        N.IdReceiver = @IdReceiver
        AND N.Text = AR.Mentions
END
GO
/****** Object:  StoredProcedure [dbo].[GetReportsByApplicationId]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetReportsByApplicationId]
    @IdApplication INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT AR.[IdApplicationReport],
           AR.[IdEndpoint],
           AR.[IdUser],
           AR.[DateCreated] AS [ReportDateCreated],
           AR.[Mentions],
           AR.[MarkedAsSolved],
           A.[IdUserAuthor],
           A.[Name],
           A.[Description],
           A.[Image],
           A.[DateCreated] AS [ApplicationDateCreated],
           AS1.[State] AS [State],
           E.[URL],
           T.[Type],
           E.[DateCreated] AS [EndpointDateCreated]
    FROM [iTEC Hackathon].[dbo].[ApplicationReports] AR
    INNER JOIN [iTEC Hackathon].[dbo].[Applications] A ON AR.[IdApplication] = A.[IdApplication]
    LEFT JOIN [iTEC Hackathon].[dbo].[ApplicationStates] AS1 ON A.[IdApplicationState] = AS1.[IdApplicationState]
    INNER JOIN [iTEC Hackathon].[dbo].[Endpoints] E ON AR.[IdEndpoint] = E.[IdEndpoint]
    INNER JOIN [iTEC Hackathon].[dbo].[Types] T ON E.[IdType] = T.[IdType]
    WHERE AR.[IdApplication] = @IdApplication;
END;
GO