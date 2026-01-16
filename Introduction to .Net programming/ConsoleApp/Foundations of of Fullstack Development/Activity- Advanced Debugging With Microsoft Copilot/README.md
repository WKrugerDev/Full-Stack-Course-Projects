# Console Task Manager

A simple console-based task management application built to practice C# and .NET fundamentals while using AI-assisted tooling (GitHub Copilot) as part of the development workflow.

## Purpose

This project represents a focused exercise in using AI-assisted development (GitHub Copilot) to generate and debug code, while ensuring all logic was reviewed, understood, and refined. Other projects use AI primarily for suggestions and minor refinements, but here the emphasis was on deliberate learning through iterative development.

GitHub Copilot was used to assist with code generation and debugging during development. All generated code was reviewed, tested, and modified to ensure understanding of the underlying logic and behavior.

## Concepts Demonstrated

- C# variables and collections (`List<T>`)
- Basic application structure using `Program.cs`
- Classes, methods, and simple data models
- Control flow (`if`, `switch`, loops)
- Menu-driven console applications
- User input parsing and validation (`int.TryParse`)
- Index-based collection access
- Managing and updating object state
- Overriding `ToString()` for display logic

## How It Works

The application runs in a continuous loop and allows the user to:

- View tasks
- Add new tasks
- Mark tasks as complete
- Delete tasks

The program runs until the user selects the exit option from the menu.

## How to Run

1. Open the project in Visual Studio or VS Code
2. Run the application using the terminal:
   ```bash
   dotnet run