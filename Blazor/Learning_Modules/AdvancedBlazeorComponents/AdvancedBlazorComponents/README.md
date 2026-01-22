# Advanced Blazor Components

A Blazor project demonstrating reusable components, parent-child communication, and service injection. This project was built to explore more advanced features of component-based development in Blazor.

## Purpose

This project was designed to practice:

- Creating reusable UI components
- Interacting between parent and child components
- Injecting and using services within components
- Using cascading parameters to share data like theme colors
- Building small test pages to verify component functionality

The goal is to reinforce understanding of Blazor component architecture and how to manage state and communication within a component-based app.

## Concepts Demonstrated

- **Reusable components** – demonstrated via `ReusableComponent.razor` and multiple instances on a page
- **Parent-child interaction** – calling methods on child components from the parent
- **Event callbacks** – ability for child to notify the parent (example shown in answer key)
- **Dependency Injection (DI)** – injecting `DataService` into components to provide mock data
- **Cascading parameters** – sharing `ThemeColor` with nested components
- **Component testing** – using `Index.razor` to render multiple reusable components and verify reusability

## How It Works

- `DataService` provides mock data to the reusable component.
- `ReusableComponent` displays the data, applies a theme color from a cascading parameter, and references a `ChildComponent`.
- Users can interact with the child component via a button to retrieve messages or trigger parent callbacks.
- `Index.razor` demonstrates multiple instances of `ReusableComponent` to test reusability.
- `MainLayout.razor` defines the theme color used by all components via cascading parameters.

## How to Run

1. Open the project in Visual Studio or VS Code.
2. Restore dependencies and run the project (in terminal):
dotnet restore
dotnet run
3. Open the browser to the indicated local URL (typically https://localhost:5091).
4. Interact with the components on the index page to see parent-child communication and service data.

## Possible Improvements

- Add real data services or API integration instead of mock DataService
- Expand parent-child communication using EventCallback for child-to-parent events
- Create more reusable UI components with parameters for text, styles, and behavior
- Add unit and integration tests for component behavior
- Implement dynamic theming with multiple cascading parameters