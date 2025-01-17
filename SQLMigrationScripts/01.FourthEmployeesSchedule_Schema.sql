PRINT 'Creating database FourthEmployeesSchedule...';
GO
CREATE DATABASE [FourthEmployeesSchedule]
GO

USE [FourthEmployeesSchedule]
GO

PRINT 'Creating table Employees...';
GO
CREATE TABLE dbo.Employees (
    EmployeeId UNIQUEIDENTIFIER NOT NULL DEFAULT (NEWID()),
    FirstName NVARCHAR(50) NULL,
    LastName NVARCHAR(50) NULL,
    CONSTRAINT PK_Employees PRIMARY KEY (EmployeeId)
);
GO

PRINT 'Creating table Roles...';
GO
CREATE TABLE dbo.Roles (
    RoleId UNIQUEIDENTIFIER NOT NULL  DEFAULT (NEWID()),
    RoleName NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_Roles PRIMARY KEY (RoleId)
);
GO

PRINT 'Creating table RolesToEmployees...';
GO
CREATE TABLE dbo.RolesToEmployees (
    RolesToEmployeeId UNIQUEIDENTIFIER NOT NULL  DEFAULT (NEWID()),
    EmployeeId UNIQUEIDENTIFIER NOT NULL,
    RoleId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT PK_RolesToEmployees PRIMARY KEY (RolesToEmployeeId),
    CONSTRAINT FK_RolesToEmployees_Employees FOREIGN KEY (EmployeeId) REFERENCES dbo.Employees (EmployeeId),
    CONSTRAINT FK_RolesToEmployees_Roles FOREIGN KEY (RoleId) REFERENCES dbo.Roles (RoleId)
);
GO

PRINT 'Creating table Shifts...';
GO
CREATE TABLE dbo.Shifts (
    ShiftId UNIQUEIDENTIFIER NOT NULL  DEFAULT (NEWID()),
    RolesToEmployeeId UNIQUEIDENTIFIER NOT NULL,
    Date DATE NULL,
    StartHour TIME(7) NOT NULL,
    EndHour TIME(7) NOT NULL,
    CONSTRAINT PK_Shifts PRIMARY KEY (ShiftId),
    CONSTRAINT FK_Shifts_RolesToEmployees FOREIGN KEY (RolesToEmployeeId) REFERENCES dbo.RolesToEmployees (RolesToEmployeeId)
);
GO

PRINT 'Creating stored procedure Shifts...';
GO
CREATE PROCEDURE [dbo].[spGetShiftsForWeek]
    @FirstDateOfTheWeek DATE, 
    @EmployeeId uniqueidentifier = NULL
AS
BEGIN
    SELECT 
        s.ShiftId AS ShiftId,
        s.Date,
        CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
        ro.RoleName,
		s.StartHour,
		s.EndHour
    FROM Shifts s
    JOIN RolesToEmployees r ON s.RolesToEmployeeId = r.RolesToEmployeeId
    JOIN Employees e ON r.EmployeeId = e.EmployeeId
    JOIN Roles ro ON r.RoleId = ro.RoleId
    WHERE 
        s.Date >= @FirstDateOfTheWeek 
        AND s.Date < DATEADD(DAY, 7, @FirstDateOfTheWeek);
END;
GO

