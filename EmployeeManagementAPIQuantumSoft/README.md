# Employee Management API

## Project Overview
This project is a RESTful API built using ASP.NET Core Web API and Entity Framework Core. It manages employees, departments, and roles with authentication and authorization.

## Setup Instructions
1. Clone the repository.
2. Open the solution in Visual Studio 2022.
3. Update the database connection string in `appsettings.json`.
4. Run the migrations using `dotnet ef database update` or through Package Manager Console.
5. Run the project.

## API Endpoints
- `GET /api/employee` - Get all employees (Admin, Manager roles) 
- `POST /api/employee` - Create a new employee (Admin role only)
- … (add other endpoints here)

## Authentication
JWT-based authentication is implemented. Use the login endpoint to get your token.
https://localhost:7168/api/Auth/login?username=Admin&password=Admin123
https://localhost:7168/api/Auth/login?username=Manager&password=Manager123

## Technologies Used
- ASP.NET Core 8.0
- Entity Framework Core (Code-First Approch)
- JWT Authentication
- Swagger for API documentation

## API Endpoints
- Employee Endpoints
- GET /api/employee
  Get all employees (Authorized Roles: Admin, Manager)
  https://localhost:7168/api/Employee

- GET /api/employee/{id}
  Get a single employee by ID (Authorized Roles: Admin, Manager)
  https://localhost:7168/api/Employee/{id}

- POST /api/employee
  Create a new employee (Authorized Role: Admin)
  https://localhost:7168/api/Employee

- PUT /api/employee/{id}

- DELETE /api/employee/{id}

- Department Endpoints
- https://localhost:7168/api/Department
 (Add Department endpoints here, similar to employee)

- Role Endpoints
- https://localhost:7168/api/Roles
 (Add Role endpoints here)
