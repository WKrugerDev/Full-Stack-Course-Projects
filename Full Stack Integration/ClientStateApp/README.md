# Client-Side State Management – Blazor

## Overview

This project demonstrates how to manage **client-side state** in a Blazor WebAssembly application.

The main goal of this lab was to understand how to persist data on the client using:

- Local Storage
- Session Storage

These techniques allow applications to improve user experience by maintaining state across page reloads and navigation without requiring constant server interaction.

---

# Main Learning Objective: Client-Side State Management

The primary focus of this lab was understanding how **state can be stored and retrieved on the client side**.

Key concepts explored:

- Local storage persistence
- Session storage persistence
- Saving and retrieving data asynchronously
- Managing UI state across page reloads
- Understanding storage scope (tab vs browser)
- Clearing stored data

Client-side storage allows data to persist without needing a database for temporary or user-preference data.

---

# Local Storage Implementation (Theme Preference)

A theme toggle feature was implemented using **local storage**.

Local storage persists data even after:

- Page reloads
- Browser restarts
- Application restarts

Example:

```csharp
@inject Blazored.LocalStorage.ILocalStorageService localStorageService

string theme = "light";

private async Task ToggleTheme()
{
    theme = theme == "light" ? "dark" : "light";
    await localStorageService.SetItemAsync("user-theme", theme);
}

protected override async Task OnInitializedAsync()
{
    theme = await localStorageService.GetItemAsync<string>("user-theme") ?? "light";
}
```

### Key Concepts

- `"user-theme"` acts as a **key** to store and retrieve data
- `SetItemAsync` saves data to local storage
- `GetItemAsync` retrieves stored data
- `?? "light"` ensures a **default value** if no data exists

---

# Session Storage Implementation (Shopping Cart)

A shopping cart feature was implemented using **session storage**.

Session storage persists data only for the duration of a **single browser tab session**.

Example:

```csharp
@inject Blazored.SessionStorage.ISessionStorageService sessionStorageService

private string NewItem = string.Empty;
private List<string> CartItems = new();

private async Task AddItem()
{
    CartItems.Add(NewItem);
    await sessionStorageService.SetItemAsync("cart", CartItems);
    NewItem = string.Empty;
}

protected override async Task OnInitializedAsync()
{
    CartItems = await sessionStorageService.GetItemAsync<List<string>>("cart") ?? new List<string>();
}
```

### Key Concepts

- `"cart"` is the storage key
- Data persists across:
  - Page reloads
  - Navigation within the same tab
- Data is lost when:
  - The tab is closed
  - The browser session ends

---

# Local Storage vs Session Storage

| Feature | Local Storage | Session Storage |
|--------|-------------|----------------|
| Persistence | Long-term | Tab session only |
| Survives reload | Yes | Yes |
| Survives tab close | Yes | No |
| Use case | Preferences (theme) | Temporary data (cart, forms) |

---

# Clearing Stored Data

A feature was added to clear all stored data from both local and session storage.

Example:

```csharp
private async Task ClearAllStorage()
{
    await localStorageService.ClearAsync();
    await sessionStorageService.ClearAsync();
}
```

UI Trigger:

```html
<button @onclick="ClearAllStorage">Clear All Storage</button>
```

### Behavior

- Clears all stored keys and values
- Applies to both storage types
- Immediately affects application state

---

# Blazor Lifecycle Integration

Both storage mechanisms rely on:

```csharp
protected override async Task OnInitializedAsync()
```

This ensures:

- Stored data is retrieved when the component loads
- UI reflects persisted state immediately

---

# Important Concepts Learned

- Client-side storage is **not a source of truth**
- Data stored in local/session storage can be:
  - Modified
  - Deleted
  - Lost
- Secure or critical data should always be validated against a **backend/database**

---

# Practical Use Cases

### Local Storage
- Theme preferences
- UI settings
- Remembered user choices

### Session Storage
- Shopping carts (non-logged-in users)
- Multi-step forms
- Temporary session data

---

# Key Takeaways

- Local storage persists long-term across sessions
- Session storage is limited to a single browser tab
- Both use key-value storage
- Async methods are required for storing/retrieving data
- Default values prevent null issues
- Client-side storage improves UX but is not secure storage

---

# Possible Future Improvements

- Persist cart data to a database for logged-in users
- Sync local storage with backend validation
- Add expiration logic to stored data
- Encrypt sensitive client-side data
- Implement authentication-based storage handling

---

# Technologies Used

- .NET 8
- Blazor WebAssembly
- C#
- Blazored.LocalStorage
- Blazored.SessionStorage
- Async/Await programming
