# Leave Tracker

## Overview
The Leave Tracker is a web application designed to manage leave requests for employees with role-based access control (RBAC). It allows employees to apply for leaves, and managers to approve or decline those requests. The application implements fine-grained, scalable RBAC using ASP.NET Core, SQL Server for role storage, and JWT tokens for stateless authentication.

## Features
- User authentication and authorization using JWT tokens.
- Role-based access control with support for hierarchical roles.
- Custom endpoint permissions for enhanced security.
- Logging of user access attempts, including denied requests for compliance and monitoring.
- Dynamic roles and permissions for scalability to handle millions of users.

## Project Structure
- **Controllers**: Contains the API controllers for handling requests.
  - `AuthController.cs`: Manages user authentication.
  - `LeaveController.cs`: Manages leave requests.
  - `UserController.cs`: Manages user-related operations.
  
- **Data**: Contains the database context and migrations.
  - `ApplicationDbContext.cs`: Defines the database context.
  - `Migrations`: Contains migration files for database schema changes.
  
- **Models**: Contains the data models used in the application.
  - `User.cs`: Represents a user.
  - `Role.cs`: Represents a role.
  - `Permission.cs`: Represents a permission.
  - `LeaveRequest.cs`: Represents a leave request.
  - `RolePermission.cs`: Represents the relationship between roles and permissions.
  
- **Services**: Contains the business logic for the application.
  - `AuthService.cs`: Handles authentication logic.
  - `JwtService.cs`: Manages JWT token creation and validation.
  - `RoleService.cs`: Manages role-related operations.
  - `LeaveService.cs`: Manages leave request operations.
  
- **Policies**: Contains authorization policies.
  - `PermissionRequirement.cs`: Implements policy-based authorization.
  
- **Middleware**: Contains custom middleware for logging.
  - `LoggingMiddleware.cs`: Logs incoming requests and responses.
  
- **Configuration**: Contains configuration files.
  - `appsettings.json`: Configuration settings for the application.
  
- **Entry Point**: Contains the main application files.
  - `Program.cs`: Entry point of the application.
  - `Startup.cs`: Configures services and middleware.

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd leave-tracker
   ```
3. Restore the dependencies:
   ```
   dotnet restore
   ```
4. Update the `appsettings.json` file with your database connection string and JWT settings.
5. Run the migrations to set up the database:
   ```
   dotnet ef database update
   ```
6. Start the application:
   ```
   dotnet run
   ```

## Usage
- Use the `/api/auth/login` endpoint to authenticate and receive a JWT token.
- Use the `/api/leaves` endpoint to apply for, approve, or decline leave requests.
- Use the `/api/users` endpoint to manage user-related operations.

## Compliance and Monitoring
The application logs all user access attempts, including denied requests, to ensure compliance and facilitate monitoring.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.