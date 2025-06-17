
A clean and modular RESTful API built with .NET 8, using FastEndpoints for minimal and fast endpoint definitions, and Entity Framework Core for database access.

🎯 Features
Manage Students, Classes, Enrollments, and Marks

CRUD operations using FastEndpoints

Entity Framework Core integration with SQL Server

Global Exception Handling

Clean architecture with services and interfaces

Swagger UI for easy API testing

🔧 Tech Stack
ASP.NET Core (.NET 8)

FastEndpoints

Entity Framework Core

SQL Server

Swagger / OpenAPI

Dependency Injection

🚀 How to Run
Clone the repo

Set your connection string in appsettings.json

Run EF Core migrations:

bash
نسخ
تحرير
dotnet ef database update
Run the application:

bash
نسخ
تحرير
dotnet run
Open Swagger at https://localhost:<port>/swagger


