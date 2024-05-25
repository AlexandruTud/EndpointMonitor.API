/****** Object:  StoredProcedure [dbo].[GetReportsUnsolvedByIdUser]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetReportsUnsolvedByIdUser]
    @IdUser INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Selecting the desired columns from joined tables
    SELECT AR.IdApplicationReport,
           E.URL,
		   U.IdUser,
           U.Email,
           A.Name,
           T.Type,
           AR.DateCreated,
           AR.Mentions
    FROM [iTEC Hackathon].[dbo].[ApplicationReports] AR
    INNER JOIN [iTEC Hackathon].[dbo].[Endpoints] E ON AR.IdEndpoint = E.IdEndpoint
    INNER JOIN [iTEC Hackathon].[dbo].[Applications] A ON E.IdApplication = A.IdApplication
    INNER JOIN [iTEC Hackathon].[dbo].[Users] U ON A.IdUserAuthor = U.IdUser
    INNER JOIN [iTEC Hackathon].[dbo].[Types] T ON E.IdType = T.IdType
    WHERE AR.IdUser = @IdUser
      AND AR.MarkedAsSolved = 0;
END;
GO