# BlazorPerformanceAppTrue

A Blazor Hybrid/Interactive project demonstrating component lifecycle, hybrid rendering, and performance patterns.

## Purpose

This project explores the behavior of hybrid components, how they load, and how data is fetched/rendered in a hybrid environment.

## Concepts Demonstrated

- Blazor Hybrid/Interactive template usage
- Component lifecycle methods (`OnInitializedAsync`)
- Conditional rendering of components
- Dependency injection of services (e.g., ILogger)
- Asynchronous data loading and UI updates

## How It Works

- Click the **Load Hybrid Component** button on the home page to load the `HybridComponent`.
- The component simulates fetching data asynchronously, then displays it in a list.
- Logs are written to the browser console to demonstrate lifecycle and performance patterns.

## How to Run

1. Open the project in Visual Studio 2022 (or VS Code with .NET 8 SDK)
2. Ensure you are targeting the correct **Hybrid template**
3. Build and run the project
4. Navigate to the home page and test component loading

## Notes

- A previous version (`BlazorPerformanceApp`) used the wrong template and has limited functionality.
- The focus of this project is understanding **component behavior in hybrid rendering**, not template setup.