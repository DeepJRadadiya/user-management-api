# User Management API

This project is a complete ASP.NET Core Web API for managing users, developed as part of a technical assignment.

## Project Overview
The User Management API provides a robust system for performing CRUD operations on User entities. It features data validation using DataAnnotations, custom logging middleware, and is configured for modern API development.

## CRUD Endpoints
The following endpoints are available in the `UsersController`:

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| **GET** | `/api/users` | Retrieves a list of all users. |
| **POST** | `/api/users` | Creates a new user. Expects a JSON body with `Name` and `Email`. |
| **PUT** | `/api/users/{id}` | Updates an existing user by their ID. |
| **DELETE** | `/api/users/{id}` | Removes a user from the system by their ID. |

## Data Validation
The `User` model uses `System.ComponentModel.DataAnnotations` to ensure data integrity:
- **Id**: Unique integer identifier.
- **Name**: Required field.
- **Email**: Required field and must be a valid email format (`[EmailAddress]`).

Example of a validation error response:
```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Email": ["Invalid email address"]
  }
}
```

## Middleware
The project includes a custom **Logging Middleware** (`LoggingMiddleware.cs`).
- **Functionality**: Logs the HTTP Request Method (e.g., GET, POST) and the Request Path (e.g., /api/users) to the console for every incoming request.
- **Registration**: Registered in `Program.cs` using `app.UseMiddleware<LoggingMiddleware>()`.

## GitHub Copilot Debugging
GitHub Copilot was utilized during development to identify and fix common issues. Examples include:

1. **Missing DataAnnotations**: Copilot suggested adding `using System.ComponentModel.DataAnnotations;` when I forgot it for the `[Required]` attribute.
2. **ModelState Validation**: Copilot helped generate the check `if (!ModelState.IsValid)` in the controller to handle validation errors gracefully.
3. **LINQ Queries**: When implementing the `PUT` endpoint, Copilot suggested the correct use of `.FirstOrDefault(u => u.Id == id)` to find the existing user.

**Debugging Example**:
If an error occurs where `id` is not found, Copilot can suggest adding:
```csharp
if (user == null) return NotFound();
```

## GitHub Repository Upload Commands
To upload this project to a GitHub repository, follow these steps in your terminal:

1. **Initialize Git**:
   ```bash
   git init
   ```
2. **Add Files**:
   ```bash
   git add .
   ```
3. **Commit Changes**:
   ```bash
   git commit -m "Initial commit: User Management API"
   ```
4. **Create a Remote**: (Replace `<your-repo-url>` with your actual repository URL)
   ```bash
   git remote add origin <your-repo-url>
   ```
5. **Push to GitHub**:
   ```bash
   git push -u origin main
   ```

## Folder Structure
```text
UserManagementApi/
├── Controllers/
│   └── UsersController.cs
├── Middleware/
│   └── LoggingMiddleware.cs
├── Models/
│   └── User.cs
├── Program.cs
├── appsettings.json
└── UserManagementApi.csproj
```
