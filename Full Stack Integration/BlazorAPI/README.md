# BlazorAPI – Fetch Data from RESTful API

This project demonstrates a small **Blazor WebAssembly** application that fetches and displays data from a RESTful API. The focus of this lab is learning:

- Making HTTP requests with `HttpClient`
- Binding API response data to UI components
- Handling async lifecycle methods (`OnInitializedAsync`)
- Simple error handling for API failures

---

## 🧱 Tech Stack

- **Blazor WebAssembly**
- **C# / .NET 8**
- **HttpClient** for API calls
- **JSONPlaceholder API** ([https://jsonplaceholder.typicode.com/posts](https://jsonplaceholder.typicode.com/posts)) as mock data

---

## 📁 Project Structure

- `Program.cs` – Configures `HttpClient` and sets up root components.
- `FetchData.razor` – Main page for retrieving and displaying posts.
- `Post` class – Represents the API data model.

---

## ⚡ Features

- Fetch posts from a RESTful API using `GetFromJsonAsync`
- Display posts in a responsive HTML table
- Handle API failures with `try-catch`
- Display “Loading…” while data is being retrieved

---

## 📝 Usage

1. Open the project folder in **Visual Studio Code**.
2. Run the application using `dotnet run`, or for hot reload, use `dotnet watch run`.
3. Open the browser at the URL provided in the console.
4. Navigate to `/fetchdata` to view the posts table.

---

## 💡 Notes

- This lab uses a **mock API**; no backend setup is required.
- Error handling ensures the page won’t crash if the API request fails.
- `FetchData.razor` demonstrates proper binding of async data to the UI.

---

## 🔒 Security / Git Considerations

- No sensitive data or passwords are included in this lab.
- In production, always store secrets (e.g., JWT tokens) in environment variables or **User Secrets** instead of committing them.
