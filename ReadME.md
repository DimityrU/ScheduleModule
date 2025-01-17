# Schedule API

This is a .NET-based API project. This README provides instructions on how to set up, run, and access the application locally.

---

## Prerequisites

Ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 8.0 or later recommended)
- [Node.js](https://nodejs.org/en/download/) (Version 14.0 or later recommended)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Version 2019 or later recommended)
- [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (Version 18.0 or later recommended)

---

## Getting Started

### 1. CreateDatabase
In ScheduleModule\SQLMigrationScripts, execute the script in order (Schema then Data) in your SQL Server.
In ScheduleModule\ScheduleModule, update the connection string in appsettings.json to point to your SQL Server.

### 2. Start the API
Execute 'dotnet run' in ScheduleModule\ScheduleModule. The API will be available at `https://localhost:5121/swagger/index.html`.

### 3. Install the required packages
Execute (as Administrator) 'npm install' in ScheduleModule\ScheduleModuleClient.
Execute (as Administrator) 'npm install -g http-server' in ScheduleModule\ScheduleModuleClient.
Execute (as Administrator) 'http-server' in ScheduleModule\ScheduleModuleClient. The client will be available at `http://localhost:8080`.
If API is running in a different port, update the API URL in ScheduleModule\ScheduleModuleClient\rest-config.js - ${BASE_URL}.