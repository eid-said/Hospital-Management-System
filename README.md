# Hospital Management System

A modern, extensible Hospital Management System built with ASP.NET Core and Entity Framework Core. This project provides the core building blocks for managing patients, appointments, medical staff, departments, and billing — designed for clarity and ease of extension for real-world hospital workflows.

# Screenshots
## Appointment resource
  
 ![Dashboard screenshot](images/1.jpg)
  
## For Authentecation
 
 ![Authentecation screenshot](images/2.jpg)
  

Table of contents
- [Features](#features)
- [Tech stack](#tech-stack)
- [Architecture overview](#architecture-overview)
- [Getting started (local)](#getting-started-local)
  - [Prerequisites](#prerequisites)
  - [Configuration](#configuration)
  - [Run locally](#run-locally)
  - [Sample data & API usage](#sample-data--api-usage)
- [Contact](#contact)

Features
- Patient management (CRUD)
- Appointment scheduling and calendar support
- Staff management (doctors, nurses, specializations)
- Department and room management
- Basic billing/invoice generation
- Role-based authentication and authorization (placeholder for identity)
- RESTful API endpoints suitable for SPA or mobile clients
- Database migrations and seed data with EF Core

Tech stack
- ASP.NET Core (Web API / MVC) — recommended .NET SDK: 8.0+
- Entity Framework Core (code-first migrations)
- SQL Server (works with PostgreSQL / SQLite with small config changes)
- Optional: React / Angular for frontend (not included by default)
- Docker (optional containerization)

Architecture overview
- Presentation: Web API / MVC controllers
- Application: Services and DTOs for business logic
- Infrastructure: EF Core DbContext, repositories, migrations
- Domain: Entities (Patient, Staff, Appointment, Department, Invoice)
Follow the folders and projects in the repo to find controllers, services, models, and migrations.

Getting started (local)

Prerequisites
- .NET SDK (8.0 or compatible) — download from https://dotnet.microsoft.com
- SQL Server (or use SQL Server LocalDB / Docker)
- (Optional) EF Core CLI: dotnet tool install --global dotnet-ef

Configuration
1. Copy the example configuration:
   - appsettings.json.example -> appsettings.Development.json (or update appsettings.json)
2. Edit the connection string in appsettings.Development.json:
   - "ConnectionStrings": { "DefaultConnection": "Server=.;Database=HospitalDb;Trusted_Connection=True;" }

Run locally
1. Restore dependencies
   - dotnet restore
2. Apply EF Core migrations and seed database (if migrations present)
   - dotnet ef database update
   - If you don't have dotnet-ef installed: dotnet tool install --global dotnet-ef
3. Run the app
   - dotnet run --project src/YourApiProjectName
4. Visit:
   - Web UI: https://localhost:5001 (if an MVC/UI exists)
   - API root / swagger: https://localhost:5001/swagger

Sample data & API usage (small sample)
- Example: Create a patient via the API (replace port + paths as needed):

## Sample data & API usage (via Swagger)

This project exposes a Swagger (OpenAPI) UI so you can interact with the API and use example request bodies directly from the browser.

How to use examples in Swagger UI
1. Run the app (dotnet run or via Docker) and open the Swagger UI, e.g.:
   - https://localhost:5001/swagger

2. Use the interactive UI:
   - POST /api/patients: open the operation, click "Try it out" and you will see an "Example Value" prefilled in the request body (if you enabled example providers). Edit if needed and click "Execute".
   - GET /api/appointments: click "Try it out", set the query parameters `from` and `to` (example values shown below) and click "Execute".

Contact
- Maintainer: Eid Said — GitHub: @eid-said
- For questions or feature requests, open an issue.


## Feel Free to Contribute