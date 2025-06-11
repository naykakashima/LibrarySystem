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

## Technologies Used

- .NET 9
- C#
- Entity Framework Core
- SQL Server
- LINQ

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

