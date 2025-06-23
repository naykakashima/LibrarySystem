# Library Management System

A modern, full-stack library management system for tracking, borrowing, and managing books and audiobooks. Built with **.NET 9 (ASP.NET Core Web API)** and a **React + Vite** frontend, this project demonstrates clean architecture, modular design, and a smooth user experience.

---

## Features

- **User Authentication:** Register, login, and secure JWT-based sessions.
- **Role-based Access:** Admin and user roles with different permissions.
- **Book Management:** Add, view, update, and delete books and audiobooks.
- **Borrow & Return:** Users can borrow and return books; admins can manage inventory.
- **Responsive UI:** Modern, mobile-friendly interface with Tailwind CSS.
- **API Documentation:** Swagger/OpenAPI enabled for easy backend exploration.
- **Clean Architecture:** Separation of concerns across Domain, Application, Infrastructure, and Presentation layers.

---

## Project Structure

```
/LibrarySystem
  /Backend
    /Application      # Business logic, DTOs, interfaces
    /Domain           # Core entities and domain models
    /Infrastructure   # EF Core, database, repositories, security
    /Presentation
      /Library.WebAPI # ASP.NET Core Web API
      /Library.ConsoleApplication # Console client (optional)
    LibrarySystem.sln # Solution file
  /Frontend
    /src              # React app source code
    /public           # Static assets
    package.json      # Frontend dependencies
    vite.config.js    # Vite configuration
README.md             # This file
```

---

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- [Node.js & npm](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/)
- Visual Studio or VS Code

---

### Backend Setup

1. **Configure Database Connection:**
   - Edit `Backend/Presentation/Library.WebAPI/appsettings.json` and set your SQL Server connection string under `DefaultConnection`.

2. **Apply Entity Framework Migrations:**
   ```bash
   cd Backend
   dotnet ef database update --project Infrastructure
   ```

3. **Run the Web API:**
   ```bash
   cd Backend/Presentation/Library.WebAPI
   dotnet run
   ```
   - The API will be available at `https://localhost:7237`
   - Swagger UI: `https://localhost:7237/swagger`

---

### Frontend Setup

1. **Install Dependencies:**
   ```bash
   cd Frontend
   npm install
   ```

2. **Start the Development Server:**
   ```bash
   npm run dev
   ```
   - The app will be available at `http://localhost:5173`

3. **API Proxy:**
   - The frontend is configured to proxy `/api` requests to the backend (`vite.config.js`).

---

## Usage

- **Register** a new user or login with existing credentials.
- **Admin users** can add, update, or delete books and audiobooks.
- **Regular users** can browse, borrow, and return books.
- All API endpoints are documented in Swagger.

---

## Technologies Used

- **Backend:** .NET 9, ASP.NET Core, Entity Framework Core, SQL Server, JWT Auth
- **Frontend:** React 19, Vite, Tailwind CSS, Radix UI, Motion, Lucide Icons
- **Other:** Axios, ESLint, OpenAPI/Swagger

---

## Clean Architecture

- **Domain:** Core business entities and logic.
- **Application:** Use cases, DTOs, interfaces.
- **Infrastructure:** Data access, security, external integrations.
- **Presentation:** API controllers, UI.

---

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements and bug fixes.

---

## Acknowledgements

- [Microsoft .NET](https://dotnet.microsoft.com/)
- [React](https://react.dev/)
- [Vite](https://vitejs.dev/)
- [Tailwind CSS](https://tailwindcss.com/)
- [Radix UI](https://www.radix-ui.com/)
- [Swagger](https://swagger.io/)

---

**Happy reading!**