# EventEase - Event Management Application

## Overview
EventEase is a comprehensive Blazor Server application for corporate and social event management, built through three progressive activities demonstrating modern web development practices.

## Features Implemented

### Activity 1: Foundation Components
- **Event Card Component**: Reusable component displaying event information
- **Basic Routing**: Navigation between Events, Event Details, and Registration pages
- **Two-way Data Binding**: Dynamic display of event data
- **Mock Data**: Sample events for demonstration

### Activity 2: Debugging and Optimization
- **Service Layer**: EventService for centralized data management
- **Error Handling**: Graceful handling of invalid routes and missing data
- **Input Validation**: Form validation using DataAnnotations
- **Performance Optimization**: Async operations and loading states
- **User Experience**: Loading spinners and error messages

### Activity 3: Advanced Features
- **State Management**: SessionService for user session tracking
- **Attendance Tracking**: AttendanceService for event registration management
- **Form Validation**: Comprehensive validation with ValidationSummary
- **User Session Display**: Welcome messages for returning users
- **Attendance Dashboard**: View registered attendees per event

## Architecture

### Models
- `Event`: Core event data structure
- `RegistrationModel`: Form model with validation attributes
- `AttendanceRecord`: Tracks user registrations

### Services
- `EventService`: Manages event data operations
- `SessionService`: Handles user session state
- `AttendanceService`: Tracks event registrations and attendance

### Components
- `EventCard`: Displays individual event information
- `UserSession`: Shows user session information
- Pages: Home, Events, EventDetails, Registration, AttendanceTracker

## Key Technologies
- **Blazor Server**: Interactive server-side rendering
- **Dependency Injection**: Service registration and injection
- **Data Annotations**: Form validation
- **Bootstrap**: Responsive UI styling
- **C# 12**: Modern language features

## How Microsoft Copilot Assisted

### Activity 1 - Foundation
- Generated basic Blazor component structure
- Suggested proper parameter binding syntax
- Provided routing configuration examples
- Recommended Bootstrap styling patterns

### Activity 2 - Debugging & Optimization
- Identified potential null reference issues
- Suggested async/await patterns for better performance
- Recommended proper error handling strategies
- Provided validation attribute examples

### Activity 3 - Advanced Features
- Suggested dependency injection patterns
- Recommended state management approaches
- Provided comprehensive form validation examples
- Suggested user experience improvements

## Running the Application

```bash
cd EventEase
dotnet run
```

Navigate to `https://localhost:5001` to access the application.

## Future Enhancements
- Database integration with Entity Framework
- Authentication and authorization
- Real-time updates with SignalR
- Email notifications for registrations
- Event capacity management
- Payment integration