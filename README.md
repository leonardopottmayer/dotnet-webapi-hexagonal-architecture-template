# ASP.NET Core based startup template using .NET 7

This template is a simple startup project to start a WEB API
using ASP.NET Core.

## Prerequirements

* Visual Studio 2022
* .NET Core SDK
* MySQL

## Database configuration

This project accesses a MySQL database using the Adapter.Data project.
A simple initial database setup is required. The SQL commands are
located in the "database" folder.

## How To Run

* Open solution in Visual Studio 2022
* Set .Api project as Startup Project and build the project.
* Run the application.

## Projects in the solution

* HexagonalArchitecture.Adapter.Authorization
* HexagonalArchitecture.Adapter.Data
* HexagonalArchitecture.Adapter.Rest
* HexagonalArchitecture.Adapter.SystemInfoProvider
* HexagonalArchitecture.Adapter.UserProvider
* HexagonalArchitecture.Adapter.Api
* HexagonalArchitecture.Adapter.Domain
* HexagonalArchitecture.Adapter.Infrastructure
* HexagonalArchitecture.Adapter.Logic
* HexagonalArchitecture.Adapter.Tests
