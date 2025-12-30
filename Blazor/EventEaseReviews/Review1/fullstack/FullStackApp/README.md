# InventoryHub - Full-Stack Integration Project

A complete inventory management system built with Blazor WebAssembly (frontend) and ASP.NET Core Minimal API (backend).

## Project Structure

- **ClientApp**: Blazor WebAssembly frontend application
- **ServerApp**: ASP.NET Core Minimal API backend

## Features

- Product listing with category information
- Real-time data fetching from API
- Error handling and loading states
- CORS-enabled API communication
- Structured JSON responses with nested objects

## Running the Application

### Prerequisites
- .NET 8.0 SDK

### Start the Backend (ServerApp)
```bash
cd ServerApp
dotnet run
```
The API will be available at `https://localhost:7000`

### Start the Frontend (ClientApp)
```bash
cd ClientApp
dotnet run
```
The Blazor app will be available at `https://localhost:5001`

## API Endpoints

- `GET /api/productlist` - Returns list of products with categories

## Key Components

### Backend (ServerApp/Program.cs)
- Minimal API with CORS configuration
- Product endpoint returning structured JSON with nested category objects

### Frontend (ClientApp/Pages/FetchProducts.razor)
- Blazor component for displaying products
- HTTP client integration with error handling
- JSON deserialization with case-insensitive options

## Integration Features

1. **CORS Configuration**: Allows cross-origin requests from the frontend
2. **Error Handling**: Try-catch blocks for API failures and JSON parsing errors
3. **Loading States**: User feedback during data fetching
4. **Structured Data**: Products include nested category information
5. **Type Safety**: Strongly-typed C# classes for API responses