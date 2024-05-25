
# Application Management System

The **Application Management System** is designed to manage user-generated applications, endpoints, comments, notifications, and reports. It supports various CRUD (Create, Read, Update, Delete) operations through a set of stored procedures, which handle the following functionalities:

## Comments Management

- **AddComment**: Allows users to add comments to applications, recording the user ID, application ID, comment content, and the date of the comment.

## Endpoints Management

- **CallEndpoints**: Iterates through all endpoints, performs some logic to generate a random status code (200 or 400), and logs this information in the `EndpointHistory` table.
- **DeleteEndpoint**: Deletes an endpoint and its associated records from multiple tables (`ApplicationReports`, `EndpointHistory`, `Notifications`, `Endpoints`), handling the operation within a transaction to ensure data integrity.

## Applications Management

- **DeleteApplication**: Deletes an application by its ID, with a check to confirm the application exists before attempting the deletion.
- **GetApplicationById**: Retrieves detailed information about a specific application, including the author’s details and the application's state.
- **GetApplications**: Retrieves all applications or those authored by a specific user, including their details and state.
- **GetApplicationsByAuthor**: Similar to `GetApplications`, but specifically designed to fetch applications by the author's ID.

## Reports Management

- **DeleteReport**: Deletes a specific application report, with success or failure indicated by an output parameter.
- **GetCommentsByApplicationId**: Retrieves comments associated with a specific application, including details about the commenting user.

## Notifications Management

- **DeleteNotificationById**: Deletes a notification by its ID.

## Features

- **Data Integrity**: Ensures operations such as deleting an endpoint are performed within a transaction to maintain data consistency.
- **Randomized Logic**: Implements randomized decision-making in the `CallEndpoints` procedure, which inserts different status codes into the history table based on random values.
- **Comprehensive Application Handling**: Allows for detailed management and retrieval of applications, supporting operations from addition of comments to deletion of applications.
- **User Notifications**: Manages notifications, including deletion based on notification ID.
- **Reporting**: Facilitates deletion of application reports and retrieval of comments for applications.

## Use Cases

- **Users**: Can add comments to applications, view their applications, and manage notifications.
- **Administrators**: Can manage the lifecycle of applications, endpoints, and related data, ensuring the system remains clean and up-to-date.
- **Reports and Analytics**: Can be generated based on the data logged in the `EndpointHistory` and comments, providing insights into application usage and user feedback.

This application would be useful in environments where managing user-generated content and ensuring data consistency and integrity are critical, such as collaborative platforms, content management systems, or service monitoring tools.

## Example Stored Procedure

sql
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



![image](https://github.com/TufanIonut/EndPointMonitor-API/assets/117408976/13ce016a-5011-47b4-8dc5-a33610d0d1b7)
![image](https://github.com/TufanIonut/EndPointMonitor-API/assets/117408976/48dcd6ec-5c67-4ed2-b46d-e862c3bea34b)
![image](https://github.com/TufanIonut/EndPointMonitor-API/assets/117408976/cc44e59f-f616-4dce-85a9-f3da17c65860)
![image](https://github.com/TufanIonut/EndPointMonitor-API/assets/117408976/5e796610-d20e-442d-9709-1f88a00b9e35)



