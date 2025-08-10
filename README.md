# 🧾 Employee Registration App

A modular and maintainable Employee Registration system built using **.NET** and **Clean Architecture** principles.

---

## 📐 Architecture Overview

This project follows the **Clean Architecture** pattern, separating concerns across distinct layers:

- **Domain** – Core business logic and entities
- **Application** – Use cases, interfaces, and MediatR handlers
- **Infrastructure** – Data access, external services
- **Presentation** – API controllers and UI (if applicable)

---

## 🚀 Features

- Register new employees
- Validate input using FluentValidation
- Decoupled command handling via MediatR
- Entity Framework Core for data persistence
- SQL Server (or PostgreSQL/MySQL) support

---

## 🛠️ Technologies Used

| Technology       | Purpose                         |
|------------------|----------------------------------|
| .NET 7 / .NET 8   | Core framework                  |
| MediatR          | CQRS and request handling       |
| Entity Framework | ORM for database access         |
| FluentValidation | Input validation                |
| SQL Server       | Default database (configurable) |

---

## 🧰 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)

### Setup Instructions

1. Clone the repository:
2. **Update the connection string**  
   In `appsettings.json` (under the API project), configure your SQL Server connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=EmployeeDb;Trusted_Connection=True;"
   }
   ```

3. **Apply EF Core migrations**
   ```bash
   dotnet ef database update --project EmployeeRegistrationApp.Infrastructure
   ```

4. **Run the application**
   ```bash
   dotnet run --project EmployeeRegistrationApp.API
   ```

---

## 🧪 Testing

Unit tests are located in the `EmployeeRegistrationApp.Tests` project.

To run all tests:
```bash
dotnet test
```

---

## 📦 Folder Structure

```plaintext
src/
├── EmployeeRegistrationApp.Domain         # Business entities and logic
├── EmployeeRegistrationApp.Application    # Use cases, interfaces, MediatR handlers
├── EmployeeRegistrationApp.Infrastructure # EF Core, repositories, external services
├── EmployeeRegistrationApp.API            # ASP.NET Core Web API
tests/
└── EmployeeRegistrationApp.Tests          # Unit and integration tests
```

---

## 🤝 Contributing

Pull requests are welcome!  
For major changes, please open an issue first to discuss what you'd like to modify.

---

## 📄 License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

---

## 🙋‍♂️ Author

**Sunil** – Bengaluru, India  
Exploring Clean Architecture, .NET, and modern software design.

---

   ```bash
   git clone https://github.com/your-username/EmployeeRegistrationApp.git
   cd EmployeeRegistrationApp
