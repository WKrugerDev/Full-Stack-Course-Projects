# MyBlazorApp – Counter Component

A basic Blazor application created from the default project template to introduce core Blazor concepts such as components, routing, data binding, and event handling.

## Purpose

This project represents my **first hands-on Blazor application**, built to understand how Razor components work and how UI updates are handled in a Blazor app.

The focus was on learning the **Blazor component model**, not customization or advanced logic. All non-essential template files were left unchanged to keep attention on the core concepts being introduced.

## Concepts Demonstrated

- Razor components (`.razor` files)
- Component routing using `@page`
- One-way data binding in Razor
- Event handling with `@onclick`
- Component state and automatic UI re-rendering
- Separation of markup and logic using `@code`

## Key Component: Counter

The `Counter.razor` component demonstrates:

- Declaring a route (`/counter`)
- Maintaining component state (`currentCount`)
- Updating state through a method
- Automatic UI updates when state changes

Each button click increments the counter and immediately reflects the updated value in the UI, illustrating Blazor’s reactive rendering model.

## How to Run

1. Open the project in Visual Studio
2. Run the application using:

```bash
dotnet run