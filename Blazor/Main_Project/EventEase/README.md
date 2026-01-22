# EventEase - Event Management Application

EventEase is a Blazor Server application designed to manage events and event registrations.  
This project demonstrates advanced Blazor concepts such as state management, forms with validation, component interaction, and dependency injection.

---

## Purpose

This project was developed as a graded assignment to consolidate Blazor Server knowledge.  
It covers practical implementation of:

- Component-based architecture
- Application state tracking
- Event and registration management
- Form validation
- Server-side rendering and routing
- Singleton service injection for shared state

---

## Concepts Demonstrated

- **Blazor Components:** Reusable Razor components for home page, events, and registration.
- **Forms & Validation:** Using `EditForm`, `DataAnnotationsValidator`, and `ValidationSummary`.
- **Application State Management:** Using a custom `AppState` service to track selected events and user sessions.
- **Dependency Injection:** Singleton services for event and registration management.
- **Routing:** Page routing using `@page` directives.
- **Async Programming:** Async methods for retrieving and storing event and registration data.
- **Console Logging:** Tracking app state changes with logging for debugging and understanding flow.

---

## How It Works

The application has two main pages accessible via the navigation menu:

1. **Home**
    - Displays welcome message and general info.
2. **Events**
    - Displays a list of events.
    - Users can view event details and register for an event.
    - Registration form validates inputs (name, email, required fields).

**State Management** ensures that selected events and user interactions are tracked across components.

---

## How to Run

1. Open the project in Visual Studio or VS Code.
2. Run the application using the terminal:
    dotnet run
3. Open a browser and navigate to https://localhost:{port} to interact with the app.

---

## Possible Improvements

- Persist events and registrations to a database instead of in-memory lists.
- Add authentication for users.
- Include event filtering and search functionality.
- Implement email notifications upon event registration.
- Add more advanced UI/UX components for better user experience.

## Notes

- All events and registrations are currently stored in memory for simplicity.
- The main purpose of this project was to demonstrate competency in Blazor Server and component-based application design.
- Logging is implemented in AppState to help visualize application state changes during runtime.