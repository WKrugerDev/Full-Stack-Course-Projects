# Feedback App

A Blazor WebAssembly application that allows users to submit feedback through a validated form and view submitted feedback stored in browser local storage.

This project focuses on form handling, validation, service-based state management, and client-side persistence using Blazored LocalStorage.

## Purpose

This application was built to practice:

- Form handling and validation in Blazor
- Using Data Annotations for model validation
- Dependency Injection with custom services
- Persisting data on the client using Local Storage
- Async lifecycle methods in Razor components
- Separating concerns between UI, models, and services

## Concepts Demonstrated

- Razor Components and routing (`@page`)
- Edit forms with validation (`EditForm`, `DataAnnotationsValidator`)
- Model validation using attributes (`[Required]`, `[EmailAddress]`, `[MaxLength]`)
- Dependency Injection with singleton services
- Asynchronous programming with `async` / `await`
- Client-side persistence using `Blazored.LocalStorage`
- Conditional UI rendering
- Navigation using `NavLink`

## Project Structure

- `NavMenu.razor`  
  Custom navigation menu for the application, demonstrating component logic and UI state toggling.

- `Models/Feedback.cs`  
  Defines the `Feedback` model with validation rules and a submission timestamp.

- `FeedbackForm.razor`  
  A form that allows users to submit feedback with validation and success confirmation.

- `FeedbackList.razor`  
  Displays all submitted feedback in a table format.

- `Services/FeedbackService.cs`  
  Handles saving and retrieving feedback using browser local storage.

- `Program.cs`  
  Registers the `FeedbackService` and `Blazored.LocalStorage` services.

## How It Works

1. Users navigate to the **Feedback Form** page.
2. The form validates input using data annotations.
3. On valid submission:
   - The feedback is timestamped.
   - The feedback is saved to browser local storage via `FeedbackService`.
4. A success message is displayed to the user.
5. Users can navigate to the **Feedback List** page to view all submitted feedback.
6. Feedback persists across page reloads due to local storage usage.

## Key Technical Details

- Feedback is stored client-side using `Blazored.LocalStorage`.
- All feedback operations are asynchronous.
- Validation errors are displayed automatically using Blazor’s built-in validation system.
- The navigation menu demonstrates basic UI state management.

## Possible Improvements

- Add delete or edit functionality for feedback entries
- Add pagination or sorting to the feedback list
- Improve UI styling and layout
- Add authentication so feedback can be user-specific
- Persist feedback to a backend API or database

## Notes

This project emphasizes clean separation between UI, models, and services while reinforcing Blazor fundamentals.  
Client-side storage was intentionally used to keep the project simple and focused on frontend concepts rather than backend persistence.