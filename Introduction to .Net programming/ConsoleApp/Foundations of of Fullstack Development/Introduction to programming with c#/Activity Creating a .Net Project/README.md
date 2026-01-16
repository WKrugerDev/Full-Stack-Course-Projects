# Console Library Manager

A simple console-based library management application built as a first hands-on .NET project.  
The goal of this project is to practice core C# and .NET fundamentals in a small, focused application.

## Purpose

This project was created to reinforce foundational programming concepts after completing introductory .NET lessons.  
It focuses on clean structure, basic validation, and readable logic rather than advanced features or data persistence.

## Concepts Demonstrated

- C# variables and collections (`List<T>`)
- Basic application structure using `Program.cs`
- Classes, methods, and simple data models
- Control flow (`if`, `switch`, and loops)
- User input handling and validation
- Case-insensitive string comparisons
- Enforcing business rules (book limits, borrow limits)
- Refactoring logic into helper methods for readability

## How It Works

The application runs in a continuous loop and allows the user to:

- Add books to the library (up to a maximum limit)
- Remove books from the library
- Borrow and check in books
- Search for a book by title
- View the current library state after each action

The program runs until the user selects the `exit` command.

## How to Run

1. Open the project in Visual Studio or VS Code
2. Run the application using the terminal:
   ```bash
   dotnet run


## Possible Improvements

- Persist the library data using file storage or a database instead of keeping it in memory
- Support multiple users instead of a single implicit user
- Improve the search functionality (partial matches, listing results)
- Add unit tests for the core library logic
- Separate concerns further by moving business logic out of `Program.cs`
- Replace the console interface with a simple UI or API layer

## Notes

This project intentionally avoids file storage or databases in order to focus on core language fundamentals and program structure. The scope is intentionally limited to keep the learning focus clear and manageable. Although this is a console-based application, it focuses on core programming and state-management concepts that apply across the full stack.