### Library System

A simple console-based Library Management System built with .NET and Entity Framework Core, using a normalized SQL Server database schema. The application supports borrowing, returning, and donating both physical and audio books. It uses Table-per-Type (TPT) inheritance and globally unique identifiers (GUIDs) for primary keys.

## Features

- Borrow and return books
- Donate physical and audio books
- Display available books
- Display all books in the library
- Persistent storage using a normalized relational database
- GUIDs used as primary keys
- Table-per-Type (TPT) mapping for clean separation of Book and AudioBook entities
- Serilog to keep track of all events that have occured

## Technologies Used

- .NET 9
- C#
- Entity Framework Core
- SQL Server
- LINQ
- Serilog

## Database Design

The database schema is normalized using EF Core's TPT inheritance pattern:

- `Books`: Base table for shared properties (ID, Title, Author, Available)
- `Books_Physical`: Table for physical books
- `Books_Audio`: Table for audiobooks with an additional `RuntimeMinutes` column

All tables use a `Guid` as the primary key to support scalability and distributed systems.

## Project Structure

- `BookBase.cs`: Abstract base class for all book types
- `Book.cs`: Represents a standard book
- `AudioBook.cs`: Represents an audiobook with runtime
- `LibraryDbContext.cs`: EF Core DbContext class
- `BookRepository.cs`: Handles database operations
- `BookService.cs`: Implements core business logic
- `Menu.cs`: User interface logic
- `Program.cs`: Application entry point

## Setup Instructions

# Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- SQL Server (Express or Standard)
- EF Core CLI (`dotnet tool install --global dotnet-ef`)

# 1. Clone the Repository

``` 
git clone https://github.com/yourusername/LibrarySystem.git
cd LibrarySystem
```

2. Configure the Connection String
Edit the connection string in appsettings.json or within LibraryDbContext.cs:

```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LibrarySystemDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. Apply the Database Migrations

If migrations already exist:

```
dotnet ef database update
```

To create a new migration (optional):

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. Run the Application

```
dotnet run
```