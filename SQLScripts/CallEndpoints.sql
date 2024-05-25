/****** Object:  StoredProcedure [dbo].[CallEndpoints]    Script Date: 5/25/2024 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[CallEndpoints]
AS
BEGIN
    DECLARE @random_num INT;
	DECLARE @endpoint_id INT;

    -- Loop through each record in Endpoints table
    DECLARE endpoint_cursor CURSOR FOR
    SELECT IdEndpoint
    FROM Endpoints;

    OPEN endpoint_cursor;
    FETCH NEXT FROM endpoint_cursor INTO @endpoint_id;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Generate a random number between 1 and 100
        SET @random_num = ROUND(RAND() * 100, 0);

        IF @random_num = 10 OR @random_num = 90
        BEGIN
            INSERT INTO EndpointHistory (IdEndpoint, DateCreated, Code)
			VALUES (@endpoint_id, GETDATE(), 400);
        END
        ELSE
        BEGIN
            INSERT INTO EndpointHistory (IdEndpoint, DateCreated, Code)
			VALUES (@endpoint_id, GETDATE(), 200);
        END

        FETCH NEXT FROM endpoint_cursor INTO @endpoint_id;
    END

    CLOSE endpoint_cursor;
    DEALLOCATE endpoint_cursor;
END;
GO