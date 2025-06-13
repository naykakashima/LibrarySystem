# LibrarySystem

A modular and clean-architecture-driven library management system built with .NET 9.0. Includes a console application for basic interaction and a Web API with Swagger UI for modern consumption.

---

## Project Structure

```yaml

LibrarySystem/
│
├── Backend/
│ ├── Application/
│ │ └── Library.Application/
│ │ ├── BookServices/
│ │ └── Interfaces/
│ │ ├── IBookRepository.cs
│ │ └── IBookService.cs
│ │
│ ├── Domain/
│ │ └── Library.Domain/
│ │ ├── Book.cs
│ │ ├── AudioBook.cs
│ │ └── BookBase.cs
│ │
│ ├── Infrastructure/
│ │ └── Library.Infrastructure/
│ │ ├── Database/
│ │ │ └── LibraryDbContext.cs
│ │ ├── Migrations/
│ │ └── Repositories/
│ │ └── BookRepository.cs
│ │
│ ├── Presentation/
│ │ ├── Library.ConsoleApplication/
│ │ │ ├── Program.cs
│ │ │ └── Menu.cs
│ │ │
│ │ └── Library.WebAPI/
│ │ ├── Controllers/
│ │ │ └── BooksController.cs
│ │ ├── Program.cs
│ │ └── appsettings.json
│
└── LibrarySystem.sln

```
---

## Technologies Used

- [.NET 9.0](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Dependency Injection
- Clean Architecture (DDD, SOLID, DRY)

---

## Getting Started

### Prerequisites

- .NET 9 SDK
- SQL Server
- IDE: Visual Studio or VS Code

### Running the Web API

1. **Update `appsettings.json`** with your database connection string under `Library.WebAPI`.
2. **Apply EF migrations** (if needed):
	```bash
   dotnet ef database update --project Library.Infrastructure
	```
3. Run the Web API:
	```bash
	cd Backend/Presentation/Library.WebAPI
	dotnet run
    ```
Open your browser to:
https://localhost:<port>/swagger

# Project Principles

Great care was taken with the following:
- Clean Architecture: Domain logic is at the core, surrounded by Application, Infrastructure, and Presentation layers.
- SOLID principles: Each class has a single responsibility and is loosely coupled.
- DRY: Shared logic is abstracted and reused.
- Separation of Concerns: Each layer has a focused role.