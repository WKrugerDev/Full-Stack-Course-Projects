# Real-Time Chat App (Blazor WebAssembly + SignalR)

## 📌 Overview
This project is a real-time chat application built using **Blazor WebAssembly** for the client and **ASP.NET Core with SignalR** for the backend.  
It demonstrates low-latency, bidirectional communication between distributed components, enabling instant message synchronisation across connected users.

---

## 🏗️ Architecture
```
Blazor WebAssembly Client  <---->  SignalR Hub (ASP.NET Core)
```

### Project Structure
```
RealTimeChatApp/
│
├── Client/     → Blazor WebAssembly frontend
├── Server/     → ASP.NET Core backend (SignalR host)
├── Shared/     → Shared models (e.g., ChatMessage)
```

---

## 🚀 Features
- Real-time messaging via SignalR
- Automatic reconnection handling for unstable connections
- Shared contract models between client and server
- Input validation and message constraints
- Lightweight, responsive UI

---

## ⚙️ Technologies Used
- .NET 8
- Blazor WebAssembly
- ASP.NET Core
- SignalR (WebSockets with LongPolling fallback)

---

## �prerequisites Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A modern browser (Chrome or Edge recommended for WebAssembly)

---

## 🔧 Setup Instructions

### Run the Server
```bash
cd Server
dotnet run
```
Server endpoint: `http://localhost:5076`

### Run the Client
```bash
cd Client
dotnet run
```
Client endpoint: `http://localhost:5218`

---

## 🔌 SignalR Configuration

### Server
SignalR services registered:
```csharp
builder.Services.AddSignalR();
```

Hub endpoint mapping:
```csharp
app.MapHub<ChatHub>("/chathub");
```

CORS policy configured for cross-origin SignalR communication:
```csharp
policy.WithOrigins("http://localhost:5218")
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials();
```

### Client
SignalR connection configuration:
```csharp
_hubConnection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5076/chathub")
    .WithAutomaticReconnect()
    .Build();
```

---

## 🧪 Usage
1. Enter a username
2. Type a message
3. Click **Send Message**
4. Messages propagate instantly to all connected clients — open multiple tabs to observe real-time sync

---

## ⚡ Technical Highlights

- **Real-time communication architecture**  
  Implemented a SignalR Hub to manage client connections and broadcast messages in real time

- **Connection lifecycle management**  
  Integrated automatic reconnection (`WithAutomaticReconnect`) to handle transient network failures

- **Cross-origin communication (CORS)**  
  Configured explicit origin policies with credential support for secure client-server interaction

- **Shared contract design**  
  Centralised message models in a shared project to enforce consistency across client and server boundaries

- **Asynchronous programming patterns**  
  Used `async/await` throughout for non-blocking UI updates and network operations

- **Client-side event handling**  
  Implemented event-driven UI updates using SignalR callbacks and Blazor's `StateHasChanged` pattern

- **Blazor WebAssembly initialisation debugging**  
  Diagnosed and resolved a silent startup failure caused by a misplaced `@layout` directive in `_Imports.razor` — a .NET 8 specific pitfall that prevents component discovery without any visible error output

---

## 📚 Key Takeaways
- Built and debugged a real-time system using modern .NET 8 technologies
- Gained practical experience with SignalR connection management and lifecycle
- Improved ability to diagnose silent failures in Blazor WebAssembly applications
- Strengthened understanding of client-server boundaries and cross-origin communication patterns

---

## ⚠️ Known Limitations & Scaling Considerations
SignalR maintains persistent connections to a **specific server instance**. In a high-availability (HA) environment with multiple VMs or containers, this creates a challenge — clients on different instances won't receive each other's messages without additional infrastructure.

**Production solutions include:**
- **Redis backplane** — synchronises messages across SignalR instances
- **Azure SignalR Service** — fully managed, handles scaling automatically

This is a known trade-off when choosing SignalR for real-time communication at scale, and worth considering when evaluating architecture for production systems.

---

## 📌 Future Improvements
- Authentication and user identity
- Persistent message storage (database integration)
- Chat rooms and private messaging
- Typing indicators and presence tracking
- UI/UX improvements
- Production scaling via Redis backplane or Azure SignalR Service

---

## 📄 License
This project is for educational and demonstration purposes.