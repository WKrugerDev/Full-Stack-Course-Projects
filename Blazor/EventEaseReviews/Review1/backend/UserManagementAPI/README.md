# User Management API

A simple ASP.NET Core Web API for managing users with CRUD operations, built with Microsoft Copilot assistance.

## Features

- **CRUD Operations**: Create, Read, Update, Delete users
- **Input Validation**: Email format, required fields, string length validation
- **Error Handling**: Comprehensive exception handling with consistent JSON responses
- **Middleware Pipeline**: 
  - Error handling middleware
  - Token-based authentication middleware
  - Request/response logging middleware
- **Swagger Documentation**: Interactive API documentation

## API Endpoints

### GET /api/users
Retrieve all users

### GET /api/users/{id}
Retrieve a specific user by ID

### POST /api/users
Create a new user
```json
{
  "name": "John Doe",
  "email": "john@example.com",
  "phone": "+1234567890"
}
```

### PUT /api/users/{id}
Update an existing user
```json
{
  "name": "Jane Doe",
  "email": "jane@example.com",
  "phone": "+0987654321"
}
```

### DELETE /api/users/{id}
Delete a user by ID

## Authentication

All endpoints require a Bearer token in the Authorization header:
```
Authorization: Bearer valid-token-123
```

## Running the Application

1. Navigate to the project directory
2. Run `dotnet run`
3. Access Swagger UI at `https://localhost:7xxx/swagger`

## Testing with Postman

1. Set Authorization header: `Bearer valid-token-123`
2. Test all CRUD endpoints
3. Verify error handling with invalid data
4. Check logging output in console

## How Copilot Assisted

- **Code Generation**: Generated boilerplate CRUD operations and controller structure
- **Validation**: Added comprehensive input validation with data annotations
- **Error Handling**: Implemented try-catch blocks and consistent error responses
- **Middleware**: Created logging, authentication, and error handling middleware
- **Best Practices**: Applied proper async/await patterns and dependency injection