-- SafeVault Database Schema
-- This file demonstrates secure database design principles

-- Create Users table with proper constraints
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL DEFAULT 'User',
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    
    -- Add constraints for security
    CONSTRAINT CK_Username_Format CHECK (Username LIKE '[a-zA-Z0-9_]%' AND LEN(Username) >= 3),
    CONSTRAINT CK_Email_Format CHECK (Email LIKE '%@%.%'),
    CONSTRAINT CK_Role_Values CHECK (Role IN ('User', 'Admin'))
);

-- Create index for performance
CREATE INDEX IX_Users_Username ON Users(Username);
CREATE INDEX IX_Users_Email ON Users(Email);

-- Example of secure parameterized query (for reference)
-- NEVER use string concatenation like this: "SELECT * FROM Users WHERE Username = '" + username + "'"
-- ALWAYS use parameterized queries like this:
-- SELECT * FROM Users WHERE Username = @Username

-- Example of vulnerable query (DO NOT USE):
-- SELECT * FROM Users WHERE Username = '" + userInput + "'

-- Example of secure query (USE THIS):
-- SELECT * FROM Users WHERE Username = @Username

-- Insert sample admin user (password is 'admin123' hashed with BCrypt)
INSERT INTO Users (Username, Email, PasswordHash, Role) 
VALUES ('admin', 'admin@safevault.com', '$2a$11$example.hash.here', 'Admin');

-- Sample queries demonstrating security best practices:

-- 1. Secure user authentication (parameterized)
-- SELECT UserID, Username, Email, PasswordHash, Role 
-- FROM Users 
-- WHERE Username = @Username;

-- 2. Secure user registration check (parameterized)
-- SELECT COUNT(*) 
-- FROM Users 
-- WHERE Username = @Username OR Email = @Email;

-- 3. Secure role-based query (parameterized)
-- SELECT UserID, Username, Email, Role, CreatedAt 
-- FROM Users 
-- WHERE Role = @Role;

-- Security Notes:
-- 1. Always use parameterized queries to prevent SQL injection
-- 2. Store password hashes, never plain text passwords
-- 3. Use proper data types and constraints
-- 4. Implement proper indexing for performance
-- 5. Use role-based access control
-- 6. Validate input at both client and server side