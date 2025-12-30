# SafeVault - Secure Web Application

## Project Overview
SafeVault is a comprehensive security-focused web application demonstrating secure coding practices, authentication, authorization, and vulnerability prevention techniques.

## Security Features Implemented

### 1. Input Validation and SQL Injection Prevention (5 pts)
- **Secure Input Validation Service**: Implemented comprehensive input sanitization
- **Parameterized Queries**: All database operations use Entity Framework with parameterized queries
- **XSS Prevention**: HTML encoding and script tag removal
- **Regex Validation**: Username and email format validation

### 2. Authentication and Authorization (5 pts)
- **Password Hashing**: BCrypt implementation for secure password storage
- **JWT Token Authentication**: Secure token-based authentication
- **Role-Based Access Control (RBAC)**: Admin and User roles with proper authorization
- **Secure Login/Registration**: Input validation and sanitization

### 3. Security Vulnerabilities Resolved (5 pts)
- **SQL Injection**: Prevented through parameterized queries and input validation
- **XSS Attacks**: Mitigated through HTML encoding and input sanitization
- **Authentication Bypass**: Secure password verification and token validation
- **Unauthorized Access**: Role-based authorization on sensitive endpoints

### 4. Comprehensive Testing (5 pts)
- **Input Validation Tests**: SQL injection and XSS attack simulation
- **Authentication Tests**: Login, registration, and token generation testing
- **Authorization Tests**: Role-based access control verification
- **Security Vulnerability Tests**: Malicious input handling verification

## Vulnerabilities Identified and Fixed

### SQL Injection Vulnerabilities
**Issue**: Direct string concatenation in SQL queries could allow malicious SQL execution
**Fix**: Implemented Entity Framework with LINQ queries and parameterized statements
**Copilot Assistance**: Generated secure query patterns and validation methods

### Cross-Site Scripting (XSS)
**Issue**: User input displayed without proper encoding could execute malicious scripts
**Fix**: HTML encoding, script tag removal, and input sanitization
**Copilot Assistance**: Created comprehensive XSS prevention functions

### Authentication Bypass
**Issue**: Weak password storage and validation could allow unauthorized access
**Fix**: BCrypt password hashing and secure authentication flow
**Copilot Assistance**: Generated secure authentication service with proper validation

### Authorization Flaws
**Issue**: Missing role-based access control could allow privilege escalation
**Fix**: JWT-based authorization with role claims and endpoint protection
**Copilot Assistance**: Implemented RBAC with proper attribute-based authorization

## How Microsoft Copilot Assisted

1. **Secure Code Generation**: Copilot helped generate secure coding patterns and best practices
2. **Vulnerability Detection**: Assisted in identifying potential security flaws in code
3. **Test Case Creation**: Generated comprehensive test cases for security scenarios
4. **Input Validation**: Created robust validation methods for different input types
5. **Authentication Logic**: Helped implement secure authentication and authorization flows

## Project Structure
```
SafeVault/
├── Controllers/          # API controllers with security attributes
├── Data/                # Entity Framework context
├── Models/              # Data models with validation attributes
├── Services/            # Business logic with security implementations
├── Tests/               # Comprehensive security tests
├── Views/               # Secure web forms
├── wwwroot/             # Static files
└── Program.cs           # Application configuration
```

## Running the Application
1. Install .NET 8.0 SDK
2. Run `dotnet restore` to install packages
3. Run `dotnet run` to start the application
4. Navigate to `https://localhost:5001` to access the web form
5. Use admin/admin123 for admin access testing

## Testing
Run tests with: `dotnet test`

## Security Best Practices Demonstrated
- Input validation and sanitization
- Parameterized database queries
- Password hashing with BCrypt
- JWT token authentication
- Role-based authorization
- XSS prevention
- SQL injection prevention
- Secure error handling
- HTTPS enforcement
- CORS configuration

This project demonstrates a comprehensive approach to web application security using modern .NET practices and Microsoft Copilot assistance.