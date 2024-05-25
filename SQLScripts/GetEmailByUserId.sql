/****** Object:  StoredProcedure [dbo].[GetEmailByUserId]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEmailByUserId]
    @ApplicationId INT
AS
BEGIN
    -- Select the Email from the Users table by joining with the Applications table based on the ApplicationId
    SELECT U.Email
    FROM [iTEC Hackathon].[dbo].[Applications] A
    JOIN [iTEC Hackathon].[dbo].[Users] U
    ON A.IdUserAuthor = U.IdUser
    WHERE A.IdApplication = @ApplicationId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetEndpointHistoryByHours]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEndpointHistoryByHours]
    @IdEndpoint INT,
    @Hours INT,
    @TimeNow DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StartTime DATETIME;
    DECLARE @EndTime DATETIME;

    -- Calculate start time and end time based on the provided hours and current time
    SET @StartTime = DATEADD(HOUR, -@Hours, @TimeNow);
    SET @EndTime = @TimeNow;

    -- Select data from EndpointHistory table based on the given parameters
    SELECT [IdEndpoint],
           [IdUser],
           [DateCreated],
           [Mentions],
           [Code]
    FROM [iTEC Hackathon].[dbo].[EndpointHistory]
    WHERE [IdEndpoint] = @IdEndpoint
      AND [DateCreated] BETWEEN @StartTime AND @EndTime;
END;
GO