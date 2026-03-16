# Async API Data Fetching – Blazor

## Overview

This project demonstrates how to fetch data from an external API in a Blazor application using asynchronous programming.

The main goal of this lab was to practice using **async/await** and **Task-based programming** to retrieve external data without blocking the UI.

User data is retrieved from:

https://jsonplaceholder.typicode.com/users

The retrieved data is displayed dynamically in a table inside a Razor component.

---

# Main Learning Objective: Asynchronous Programming

The primary focus of this lab was understanding how **asynchronous programming works in Blazor**.

Key concepts explored:

- async / await
- Task-based programming
- Non-blocking UI operations
- Fetching data from external APIs
- Handling loading states
- Handling API errors safely

Using asynchronous programming allows the application to retrieve data without freezing the user interface.

---

# Data Model

A model was created to match the JSON structure returned by the API.

Example:

namespace AsyncApi.Models

public class User  
{  
    public required int Id { get; set; }  
    public required string Name { get; set; }  
    public required string Email { get; set; }  
    public required Address Address { get; set; }  
}

public class Address  
{  
    public required string Street { get; set; }  
    public required string Suite { get; set; }  
    public required string City { get; set; }  
    public required string Zipcode { get; set; }  
}

Using **required properties** ensures necessary data is always initialized.

---

# Fetching Data Asynchronously

User data is retrieved using `HttpClient` and the method:

GetFromJsonAsync<List<User>>()

This method asynchronously downloads JSON data and converts it directly into C# objects.

Example:

Users = await http.GetFromJsonAsync<List<User>>("https://jsonplaceholder.typicode.com/users");

Because the call is asynchronous, the UI remains responsive while the request completes.

---

# Loading State Handling

A loading state was implemented using a boolean variable.

bool isLoading = false;

This allows the UI to display a message while the data is being retrieved.

Example UI logic:

@if (isLoading)
{
    <p>Loading Users...</p>
}

This improves the user experience by showing that the application is actively processing a request.

---

# Error Handling

A variable was used to store possible API errors.

string? ErrorMessage;

The API request is wrapped inside a try/catch block.

try
{
    Users = await http.GetFromJsonAsync<List<User>>(...);
}
catch(Exception ex)
{
    ErrorMessage = ex.Message;
}

If an error occurs, the application displays the message instead of crashing.

---

# Why OnAfterRenderAsync Was Used

During testing it was discovered that calling the API directly inside `OnInitializedAsync` prevented the loading indicator from being displayed.

Blazor does not render the component until `OnInitializedAsync` finishes executing. Because of this, the UI never had a chance to show the loading state before the async request began.

To solve this, the API request was triggered inside:

OnAfterRenderAsync(bool firstRender)

Example:

protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {
        await FetchUser();
    }
}

This ensures the component renders once first, allowing the loading indicator to appear before the asynchronous operation begins.

This behavior was particularly noticeable when using:

@rendermode InteractiveServer

which runs the component interactively on the server.

---

# Fetching Data on Demand

A button was added to allow the user to manually request updated data.

<button @onclick="FetchUser">Fetch New Users</button>

This demonstrates how user interaction can trigger asynchronous operations in Blazor.

---

# Rendering Data in a Table

The fetched user data is displayed using a table and a foreach loop.

@foreach (var user in Users)
{
    <tr>
        <td>@user.Id</td>
        <td>@user.Name</td>
        <td>@user.Email</td>
        <td>@user.Address.Street, @user.Address.Suite, @user.Address.City, @user.Address.Zipcode</td>
    </tr>
}

Blazor automatically re-renders the UI when the data changes.

---

# Key Takeaways

- Asynchronous programming prevents UI blocking
- async/await allows efficient API communication
- Loading states improve user experience
- Proper error handling prevents crashes
- Blazor lifecycle methods affect rendering behavior
- OnAfterRenderAsync can be used when UI must render before starting async operations

---

# Possible Future Improvements

- Move API logic into a dedicated service layer
- Add cancellation tokens for API calls
- Implement retry logic
- Add pagination for large datasets
- Improve UI styling

---

# Technologies Used

- .NET 8
- Blazor
- C#
- HttpClient
- JSON APIs
- Async/Await programming
