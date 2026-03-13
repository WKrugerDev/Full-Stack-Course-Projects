# WeatherApp – Blazor WebAssembly Project

This project is a small Blazor WebAssembly application demonstrating how to fetch and display data from a public RESTful API (WeatherAPI).  

The app showcases:

- Using `HttpClient` to call a public API
- Async lifecycle handling with `OnInitializedAsync`
- Conditional rendering and basic error handling in the UI

---

## 🧱 Tech Stack

- .NET 8  
- Blazor WebAssembly (Frontend)  
- C#  
- Public RESTful API (WeatherAPI)

---

## 📁 Project Structure

### Pages (`Pages/`)  
Contains Blazor Razor components for UI.

- **WeatherFetch.razor** – Fetches and displays weather data from the API.  
  Demonstrates:  
  - Injecting `HttpClient`  
  - Defining data models to match the JSON response  
  - Fetching data asynchronously in `OnInitializedAsync`  
  - Conditional rendering (`Loading`, `Error`)  
  - Displaying API data in a table format

---

### wwwroot (`wwwroot/`)  
Contains static assets such as CSS, JS, or placeholder images if needed for fallback display.

---

## 🧠 Key Learning Outcomes

- Using `HttpClient.GetFromJsonAsync<T>()` to deserialize JSON into typed objects  
- Handling API errors gracefully and displaying user-friendly messages  
- Mapping JSON properties to C# objects with required fields  
- Rendering dynamic data in Razor components  

---

## 📌 Running the Application

1. Navigate to the project folder in your terminal:
cd WeatherApp
2. Run the app:
dotnet run
3. Open the browser at the URL displayed in the terminal (e.g., https://localhost:5001)
4. Navigate to the WeatherFetch page to see weather data for London or your chosen city

## 💡 Possible Future Enhancements
- Add user input to allow searching by different cities
- Include more weather details (humidiy, wind speed, etc.)
- Use a fallback icon or placeholder for weather conditions if the API call fails
- Style the table and display using CSS frameworkds (e.g. Bootstrap)
- Implement caching and refresh button to fetch updated data without reloading the page.