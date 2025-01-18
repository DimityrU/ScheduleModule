USE [FourthEmployeesSchedule]
GO

DECLARE @Employee1 UNIQUEIDENTIFIER = NEWID();
DECLARE @Employee2 UNIQUEIDENTIFIER = NEWID();
DECLARE @Employee3 UNIQUEIDENTIFIER = NEWID();

DECLARE @Role1 UNIQUEIDENTIFIER = NEWID();
DECLARE @Role2 UNIQUEIDENTIFIER = NEWID();
DECLARE @Role3 UNIQUEIDENTIFIER = NEWID();

DECLARE @RoleToEmployee1 UNIQUEIDENTIFIER = NEWID();
DECLARE @RoleToEmployee2 UNIQUEIDENTIFIER = NEWID();
DECLARE @RoleToEmployee3 UNIQUEIDENTIFIER = NEWID();
DECLARE @RoleToEmployee4 UNIQUEIDENTIFIER = NEWID();
DECLARE @RoleToEmployee5 UNIQUEIDENTIFIER = NEWID();


PRINT N'Inserting Employees...'
INSERT INTO [dbo].[Employees]
           ([EmployeeId]
           ,[FirstName]
           ,[LastName])
     VALUES (@Employee1, 'Ivan', 'Ivanov'), 
			(@Employee2, 'Dimitar', 'Dimitrov'), 
			(@Employee3, 'Maria', 'Marinova');

PRINT N'Inserting Roles...'
INSERT INTO [FourthEmployeesSchedule].[dbo].[Roles] (RoleId, RoleName)
	VALUES 
			(@Role1, 'Waiter'),
			(@Role2, 'Chef'),
			(@Role3, 'Bartender');

PRINT N'Inserting RolesToEmployee...'
INSERT INTO [FourthEmployeesSchedule].[dbo].[RolesToEmployees] (RolesToEmployeeId, EmployeeId, RoleId)
	VALUES 
			(@RoleToEmployee1, @Employee1, @Role1),
			(@RoleToEmployee2, @Employee1, @Role3),
			(@RoleToEmployee3, @Employee2, @Role1),
			(@RoleToEmployee4, @Employee2, @Role3),
			(@RoleToEmployee5, @Employee3, @Role2);

DECLARE @StartDate DATE = '2025-01-20';
DECLARE @EndDate DATE = '2025-01-26';

PRINT N'Inserting Shifts...'
WHILE @StartDate <= @EndDate
BEGIN
    INSERT INTO [FourthEmployeesSchedule].[dbo].[Shifts] (ShiftId, RolesToEmployeeId, Date, StartHour, EndHour)
    VALUES 
    (NEWID(), @RoleToEmployee1, @StartDate, CAST('08:00:00' AS TIME), CAST('12:00:00' AS TIME)),
    (NEWID(), @RoleToEmployee2, @StartDate, CAST('13:00:00' AS TIME), CAST('20:00:00' AS TIME)),
    (NEWID(), @RoleToEmployee3, @StartDate, CAST('14:00:00' AS TIME), CAST('16:00:00' AS TIME)),
	(NEWID(), @RoleToEmployee4, @StartDate, CAST('09:00:00' AS TIME), CAST('13:00:00' AS TIME)),
    (NEWID(), @RoleToEmployee5, @StartDate, CAST('08:00:00' AS TIME), CAST('12:00:00' AS TIME)),
    (NEWID(), @RoleToEmployee5, @StartDate, CAST('18:00:00' AS TIME), CAST('23:00:00' AS TIME));

    SET @StartDate = DATEADD(DAY, 1, @StartDate);
END;
    
