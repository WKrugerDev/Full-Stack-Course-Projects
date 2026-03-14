# WeatherApp – Blazor WebAssembly Project

This project is a small Blazor WebAssembly application demonstrating how to fetch and display data from public RESTful APIs.

The application retrieves:

- Weather data from WeatherAPI
- User data from JSONPlaceholder

The project demonstrates clean separation between UI components, state management, and data models.

---

## 🧱 Tech Stack

- .NET 8
- Blazor WebAssembly (Frontend)
- C#
- REST APIs
  - WeatherAPI
  - JSONPlaceholder

---

## 📁 Project Structure

### Pages (`Pages/`)

Contains Razor components responsible for displaying UI and interacting with the state service.

- **WeatherFetch.razor**

  Demonstrates:
  - Injecting services using dependency injection
  - Fetching data during component initialization
  - Conditional rendering for loading, error, and data states
  - Displaying API data in tables
  - Refreshing data through UI buttons

---

### Models (`Models/`)

Contains C# classes used to map JSON responses returned by the APIs.

**Weather Models**
- WeatherResponse
- Location
- Current
- Condition

These models represent the structure returned by the WeatherAPI.

**User Models**
- User
- Address
- Geo

These models represent the structure returned by the JSONPlaceholder API.

Separating models into a dedicated folder keeps the application organized and improves maintainability when working with multiple APIs.

---

### Services (`Services/`)

Contains the application's state management and API communication logic.

**WeatherStateService**

Responsibilities:

- Fetching weather data from WeatherAPI
- Fetching user data from JSONPlaceholder
- Storing application state
- Providing data to UI components
- Handling API errors

Key properties exposed by the service:

- WeatherData
- Users
- ErrorMessage

Key methods:

- FetchWeatherData()
- FetchUserData()

The Razor component calls these methods while the service manages the HTTP requests and stores the results.

Using a service for state management improves separation of concerns by keeping networking and business logic out of the UI components.

---

### wwwroot (`wwwroot/`)

Contains static assets used by the application such as:

- CSS files
- JavaScript files
- Images or placeholder assets

---

## 🧠 Key Learning Outcomes

This project demonstrates several important Blazor and .NET development concepts:

### API Consumption

Using:

HttpClient.GetFromJsonAsync<T>()

to deserialize JSON API responses directly into strongly typed C# objects.

---

### Dependency Injection

The application injects the state service into Razor components using:

@inject WeatherStateService weatherStateService

This allows components to access shared application state and API methods.

---

### Asynchronous Data Loading

Data is fetched using async lifecycle methods:

OnInitializedAsync()

This ensures API requests run without blocking the UI.

---

### Conditional Rendering

The UI handles multiple application states:

- Loading
- Error
- No Data
- Successful Data Retrieval

This ensures the user interface remains responsive and informative even when API calls fail.

---

### State Management with Services

Instead of placing API logic directly in the Razor component, the application uses a state service.

Benefits include:

- Reusable logic
- Cleaner UI components
- Easier testing
- Centralized error handling

---

## 🏗 Architecture Overview

This project follows a simple layered architecture to separate responsibilities within the application.

UI Layer (Razor Components)  
↓  
State Management Layer (Services)  
↓  
Data Models Layer (Models)  
↓  
External APIs  

Responsibilities of each layer:

**UI (Pages)**  
- Displays data to the user  
- Handles user interaction (buttons, refresh actions)  
- Calls service methods to retrieve data  

**Services**  
- Fetch data from APIs  
- Store application state  
- Handle API errors  
- Provide data to UI components  

**Models**  
- Represent API response structures  
- Provide strongly typed objects for JSON deserialization  

This separation keeps UI components simple and moves business logic into reusable services.

---

## 🔄 Data Flow

The application follows this flow when loading data:

1. The Razor component loads.
2. `OnInitializedAsync()` executes.
3. The component calls methods in `WeatherStateService`.
4. The service makes HTTP requests using `HttpClient`.
5. JSON responses are deserialized into typed C# models.
6. The service stores the data in its state properties.
7. The Razor component reads those properties and renders the UI.

This pattern keeps networking logic out of the UI layer and makes the application easier to maintain and extend.

---

## 🎯 Purpose of This Project

This project was created to practice important concepts used in modern .NET web development.

The goals include:

- Consuming REST APIs
- Structuring a Blazor WebAssembly application
- Implementing service-based state management
- Working with strongly typed JSON models
- Handling asynchronous data loading
- Managing UI loading and error states

The project is intended as a learning step toward building more complex full-stack .NET applications.


---

## 📌 Running the Application

1. Navigate to the project folder in your terminal:

cd WeatherApp

2. Run the application:

dotnet run

3. Open the browser at the URL shown in the terminal (for example):

https://localhost:5001

4. Navigate to the WeatherFetch page to see:

- Weather data from the Weather API
- User data retrieved from JSONPlaceholder

You can also refresh the data using the UI buttons.

---

## 💡 Possible Future Enhancements

### Separate Error Handling per API

Currently a single shared error message is used. In a larger application it would be beneficial to track errors separately for each API request.

Example improvements:

- WeatherErrorMessage
- UserErrorMessage

This would allow the application to continue displaying one dataset even if the other API fails.

---

### Parallel API Fetching

Currently API calls are executed sequentially.

An improvement would be to use:

Task.WhenAll()

to fetch data from multiple APIs simultaneously, reducing overall loading time.

---

### Service-Level Combined Fetch Method

Instead of coordinating multiple API calls in the Razor component, a service method such as:

FetchAllData()

could internally call:

FetchWeatherData()
FetchUserData()

This would further improve separation of concerns.

---

### Address Formatting in Models

The Address model currently exposes multiple properties such as:

- Street
- Suite
- City
- Zipcode

A computed property like:

FullAddress

could be added to the model to format addresses safely and handle optional values such as Suite being null.

---

### Improved UI Styling

The UI could be enhanced by integrating a CSS framework such as:

- Bootstrap
- Tailwind

This would improve layout, responsiveness, and overall presentation.

---

### Caching and State Persistence

The service could implement caching so that API data does not need to be fetched every time the user refreshes the page.

This would improve performance and reduce API usage.
