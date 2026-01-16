# Project Submission – Console Product Manager

A console-based product management application built to reinforce C# and .NET fundamentals while practicing iterative development and debugging with AI-assisted tooling (GitHub Copilot).

## Purpose

This project was created as the final project for the Foundations of Full-Stack course. It focuses on practicing object-oriented programming, data handling, and user input validation within a console application.

GitHub Copilot was used to assist with code generation and debugging. All generated code was carefully reviewed, tested, and refined to ensure understanding of the underlying logic and behavior.

The project emphasizes learning **core programming patterns** that are foundational to full-stack development, such as state management, list operations, and input validation.

## Concepts Demonstrated

- Object-oriented programming: classes, constructors, and properties
- Overriding `ToString()` for custom object display
- Collections (`List<T>`) and index-based operations
- Menu-driven console applications
- Input parsing and validation (`int.TryParse`, `double.TryParse`)
- Updating object state (stock amount changes)
- Defensive programming (handling invalid or empty input)
- Iterative debugging and refinement using AI-assisted tooling
- Maintaining code readability and structure in a single file

## How It Works

The application runs in a continuous loop and allows the user to:

- View all products
- Add new products (name, price, stock)
- Edit stock levels of existing products
- Delete products from the list

The program continues running until the user selects the exit option from the menu.

## How to Run

1. Open the project in Visual Studio or VS Code
2. Run the application using the terminal:
   ```bash
   dotnet run

## Possible Improvements

- Persist products to a file or database instead of keeping them in memory
- Add product categories or descriptions
- Implement search functionality to find products by name
- Add unit tests for core product management logic
- Separate business logic from the console UI for better maintainability
- Replace the console interface with a simple GUI or web-based frontend