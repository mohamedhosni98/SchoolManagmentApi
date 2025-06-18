# School Management API

A clean, modular, and high-performance RESTful API for managing school data (students, classes, enrollments, and marks), built with **.NET 8**, **FastEndpoints**, and **Entity Framework Core**.

---

##  Features

 Student and Class Management
-  Enrollment and Mark Tracking
-  Clean Architecture (Layered structure)
-  High performance using [FastEndpoints](https://fast-endpoints.com/)
-  JWT Authentication Ready *(optional)*
-  Entity Framework Core 8 + SQL Server
-  Easy Unit Testing and Extensibility
-  Global Error Handling Middleware
- OpenAPI/Swagger UI Documentation

---

##  Project Structure

```bash
managment_api/
│
├── Endpoints/           # All FastEndpoints definitions
├── Interfaces/          # Service interfaces
├── Models/              # Domain models (Entities)
├── Services/            # Business logic
├── Data/                # DbContext & EF Configuration
├── Middleware/          # Custom middlewares (e.g., global error handling)
├── DTOs/                # Data Transfer Objects
├── Program.cs           # Entry point with DI setup
├── appsettings.json     # Configuration (DB, logging, etc.)
└── README.md            # You're here


## Technologies Used
.NET 8

FastEndpoints

Entity Framework Core 8

SQL Server

Swagger (OpenAPI)

C#

 Getting Started
1. Clone the repo
bash
نسخ
تحرير
git clone https://github.com/your-username/school-management-api.git
cd school-management-api
2. Update the connection string in appsettings.json
json
نسخ
تحرير
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=School-DB;Integrated Security=True;TrustServerCertificate=True"
}
3. Run migrations and update database
bash
نسخ
تحرير
dotnet ef database update
4. Run the project
bash
نسخ
تحرير

