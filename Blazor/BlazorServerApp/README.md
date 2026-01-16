# BlazorServerApp

A Blazor Server application demonstrating core server-side Blazor concepts, including component-based UI, state management, navigation, and real-time communication using SignalR.

This project was built as part of the **Foundations of Full Stack Development** section to explore how Blazor Server handles UI rendering, shared state, and real-time updates.

---

## Purpose

The purpose of this project is to understand how Blazor Server applications work end-to-end, including:

- Server-side rendering with interactive components  
- Managing component state within a Blazor Server app  
- Implementing real-time features using SignalR  
- Structuring a Blazor Server application with hubs, services, and pages  

The focus is on learning architecture and communication patterns rather than production-ready features.

---

## Concepts Demonstrated

- Blazor Server application structure
- Razor components and routing
- Interactive server render mode
- Component state management
- Navigation using `NavLink`
- SignalR hubs for real-time communication
- Client–server messaging with `HubConnection`
- Proper resource cleanup with `IAsyncDisposable`
- Separation of concerns between UI, hubs, and configuration

---

## Application Features

### Navigation
The application includes a navigation menu that links to:

- Home (default template page)
- Counter
- Weather
- State Management demo
- SignalR Chat

---

### State Management Page
A simple page demonstrating local component state:

- Displays a counter value
- Updates state through user interaction
- Shows how Blazor Server preserves component state during interaction

---

### SignalR Chat
A real-time chat feature implemented using SignalR:

- Users can enter a name and message
- Messages are broadcast to all connected clients
- Messages update instantly without page refresh
- Uses a strongly-typed message model for clarity
- Demonstrates async lifecycle handling and proper disposal of connections

---

## Architecture Overview

- **SignalR Hub**  
  A `NotificationHub` handles incoming messages and broadcasts them to all clients.

- **Blazor Components**  
  Razor components handle UI rendering, user input, and interaction with SignalR.

- **Program Configuration**  
  SignalR and interactive server components are registered and mapped in `Program.cs`.

---

## Possible Improvements

- Add authentication to identify users uniquely
- Persist chat messages using a database or storage service
- Add timestamps or message history
- Implement chat rooms or private messaging
- Introduce shared state across components using scoped services
- Improve UI styling and layout

---

## Notes

This project intentionally keeps features minimal to focus on understanding **Blazor Server fundamentals and real-time communication**.  
Some implementations go beyond the tutorial baseline to reinforce best practices and structured design.