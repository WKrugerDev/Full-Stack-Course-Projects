# InventoryHub (Blazor WebAssembly + Minimal API)

## 📌 Overview
This project is a full-stack inventory management application built using **Blazor WebAssembly** for the client and **ASP.NET Core Minimal API** for the backend.  
It demonstrates seamless front-end and back-end integration, structured JSON communication, and client/server-side performance optimisation.

---

## 🏗️ Architecture

Blazor WebAssembly Client  ←→  ASP.NET Core Minimal API

### Project Structure

```
FullStackApp/
│
├── ClientApp/     → Blazor WebAssembly frontend
│   ├── Models/    → Strongly typed models (Product, Category)
│   ├── Services/  → ProductService (API calls and caching)
│   └── Pages/     → FetchProducts.razor (product list component)
├── ServerApp/     → ASP.NET Core Minimal API backend
└── FullStackSolution.sln
```

---

## 🚀 Features
- Front-end and back-end integration via HttpClient
- Structured nested JSON responses (Product with Category)
- Client-side caching to prevent redundant API calls
- Server-side response caching to minimise server load
- Robust error handling (timeouts, HTTP errors, unexpected exceptions)
- Separation of concerns via dedicated service layer

---

## ⚙️ Technologies Used
- .NET 8
- Blazor WebAssembly
- ASP.NET Core Minimal API
- System.Text.Json
- HttpClient with manual deserialization

---

## 📋 Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A modern browser (Chrome or Edge recommended for WebAssembly)

---

## 🔧 Setup Instructions

### Run the Server
```bash
cd ServerApp
dotnet run
```
Server endpoint: `http://localhost:5267`

### Run the Client
```bash
cd ClientApp
dotnet run
```
Client endpoint: `http://localhost:5116` (or as assigned)

---

## 🔌 API Configuration

### Server
CORS policy configured to allow cross-origin requests from the Blazor client:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
```

Response caching configured to minimise repeated server processing:
```csharp
builder.Services.AddResponseCaching();
app.UseResponseCaching();
```

### Client
ProductService handles all API communication and caching:
```csharp
private List<Product>? _cachedProducts;

public async Task<List<Product>?> GetProductsAsync()
{
    if (_cachedProducts != null)
        return _cachedProducts;
    // fetch, deserialize and cache
}
```

---

## 🧪 Usage
1. Run both ServerApp and ClientApp
2. Navigate to `/fetchproducts` in the browser
3. Product list with nested category data loads from the API
4. Navigate away and back — subsequent loads served from client cache

---

## ⚡ Technical Highlights

- **Full-stack integration**  
  Connected Blazor WebAssembly frontend to ASP.NET Core Minimal API using HttpClient with manual JSON deserialization

- **Structured JSON responses**  
  Implemented nested JSON objects (Product with Category) verified via Postman

- **Debugging integration issues**  
  Identified and resolved CORS misconfiguration, API route mismatch, and JSON deserialization casing issues independently

- **Performance optimisation**  
  Implemented both client-side in-memory caching and server-side response caching to reduce redundant processing

- **Separation of concerns**  
  Extracted API logic into a dedicated `ProductService`, keeping Razor components focused purely on UI concerns

- **Robust error handling**  
  Implemented specific exception handling for timeouts (`TaskCanceledException`), HTTP errors (`HttpRequestException`), and unexpected exceptions with appropriate UI state management

- **Defensive UI state management**  
  Implemented error, loading, and data states with priority-ordered conditional rendering

---

## 📚 Key Takeaways
- Built and debugged a full-stack .NET 8 application from scratch without AI code generation
- Gained practical understanding of cross-origin communication and why CORS is required
- Understood the difference between convenience methods (`GetFromJsonAsync`) and manual deserialization, and the trade-offs between them
- Strengthened understanding of separation of concerns applied to both frontend components and backend API design
- Developed a deliberate approach to AI-assisted development — building first, using AI to refine and verify rather than generate

---

## ⚠️ Known Limitations & Planned Improvements
This project intentionally follows the scope of the course module instructions. The following improvements are within current skillset and would be implemented in a production version:

- **Database integration** — replacing hardcoded data with Entity Framework Core and a proper database context
- **DTOs and shared models** — moving models to a shared project (`InventoryHub.Shared`) referenced by both front-end and back-end
- **Typed HttpClient** — replacing hardcoded URLs with properly configured typed clients registered in `Program.cs`
- **Authentication and middleware** — JWT or session based authentication with middleware handling auth, logging and request validation
- **Restrictive CORS policy** — limiting allowed origins to specific domains rather than `AllowAnyOrigin`
- **Cache invalidation strategy** — adding expiry and invalidation logic to the current caching implementation
- **Postman/Swagger documentation** — full API documentation for all endpoints

---

## 📄 License
This project is for educational and demonstration purposes.