# Server-Side Blazor: Session Storage and Caching

## Overview

This project demonstrates server-side state management in a Blazor Server application. The focus is on:

- Session storage for per-session user data  
- Caching frequently accessed data  
- Persisting simple data during a user session  
- Proper registration of services for Blazor Server

---

# Main Learning Objectives: Server-Side State Management

Key goals:

- Understand Blazor Server component lifecycles  
- Implement session storage for user-specific data  
- Use memory caching to optimize repeated data retrieval  
- Learn best practices for async programming in components and services

---

# Program Setup

To handle caching and session storage in server-side Blazor, services must be registered:

- Memory caching service is added to the dependency injection container.  
- A singleton CacheService is registered to manage cached data throughout the application.  
- Blazored.SessionStorage service is registered to handle session-specific data for the current user.  
- HttpContextAccessor is added to allow session storage to access the current SignalR circuit tied to the user session.

This setup ensures that both cached data and per-session data can be injected into components across the application.

---

# CacheService Methodology

The caching service provides a method to **get a cached item by key or create it if it does not exist**. 

- If the key exists in memory, the cached value is returned.  
- If the key does not exist, a new value is generated using a provided function, stored in memory with optional expiration, and then returned.  
- This pattern reduces repeated expensive operations such as API calls or database queries.

**Best practices:**

- Use async-aware methods if the item generation requires I/O (API calls, database queries).  
- Set expiration times to prevent stale data.  
- Avoid storing sensitive information in memory if it is user-specific without proper security.

---

# FetchData Component Methodology

The FetchData component demonstrates using caching for frequently accessed data:

- On initialization, the component requests data through the CacheService.  
- If the cache contains the data, it is returned immediately, ensuring fast UI response.  
- If not, a value is created and cached with a set expiration time.  
- Async methods should be used when fetching real data to prevent UI blocking.

This approach ensures efficient data handling while keeping the user interface responsive.

---

# Counter Component Methodology with Session Storage

The Counter component demonstrates per-session persistence:

- The current count is stored in session storage, associated with the user’s SignalR circuit.  
- On first render, the component retrieves the stored value.  
- Every increment updates the session storage, ensuring state is maintained across page navigation and refreshes.  
- Session storage persists only for the current tab/session and is cleared when the tab is closed.

**Key considerations:**

- Session storage works across different pages in the same session.  
- Awaiting async storage calls ensures data is consistent before the next operation.  
- The type used in session storage retrieval must match the stored data type.

---

# Session and Cache Behavior

| Feature                  | Scope / Lifetime | Notes |
|---------------------------|-----------------|-------|
| Session Storage           | Current user session | Persists data for the tab/session, cleared on tab close |
| Memory Cache (CacheService)| Application lifetime | Shared across users, expires per cache entry policy |

---

# Key Takeaways

- Server-side Blazor uses SignalR circuits to manage state per user.  
- CacheService allows efficient reuse of data while avoiding repeated expensive operations.  
- Session storage improves user experience by maintaining state within the current session.  
- Async programming is important when data generation involves I/O.  
- Proper service registration is crucial for server-side state management.

---

# Possible Future Improvements

- Convert CacheService to async for real API or database calls.  
- Combine session and persistent storage for cross-tab or long-term storage.  
- Implement secure storage for sensitive user data.  
- Add expiration policies and automatic cache refresh for dynamic data.  
- Include UI loading indicators for asynchronous fetch operations.

---

# Technologies Used

- .NET 8  
- Blazor Server  
- C#  
- Blazored.SessionStorage  
- IMemoryCache  
- Async/Await programming  