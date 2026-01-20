# ErrorHandlingAndLogging

A minimal ASP.NET Core (.NET 8) Web API project demonstrating **controller-based routing**, **structured error handling**, and **logging with Serilog** to both the console and rolling log files.

This project focuses on **correct exception handling patterns** and **logging behavior**, rather than business logic complexity.

---

## 🚀 Features

- ASP.NET Core **MVC controller** with attribute routing  
- Safe **integer division endpoint** with `try/catch`  
- Proper HTTP responses (`200 OK`, `400 Bad Request`)  
- **Serilog** configured via `appsettings.json`  
- Logs written to:
  - Console  
  - Rolling log files (`Logs/log-YYYYMMDD.txt`)  
- Demonstrates:
  - Controller-level exception handling  
  - Global middleware exception handling  
  - Dependency Injection for `ILogger<T>`

---

## 🧱 Tech Stack

- .NET 8  
- ASP.NET Core Web API  
- Serilog  
- Serilog.Sinks.Console  
- Serilog.Sinks.File  

---

## Logging

Logging is implemented using **Serilog**, configures via `appsettings.json`
and wired into the application in `Program.cs`.

The setup demonstrates:
- Console logging for development
- Rolling daily log files (`Logs/log-YYYYMMDD.txt`)
- Reduced noise from framework logs (`Microsoft`, `System` set to `Warning`)

This reflects a common production-style logging approach.

---

## ▶️ Running the Application

- dotnet run
- application will start on configures port: http://localhost:5273
- divide suburl with the following setup: /api/ErrorHandling/division?numerator=10&denominator=2
- divide by zero test url: /api/ErrorHandling/division?numerator=10&denominator=0
- error is logged in console and logfile

---

## 🧠 Key Learning Points

- Why integer division is used for reliable exception handling
- Why double division does not throw and must be handled differently
- Difference between:
    - Controller-level exception handling
    - Global middleware exception handling
- How ASP.NET Core continues running after handled exceptions
- How Serilog integrates with ILogger<T>

---

## 📌 Notes

- Successful requests are not logged by default
- Only errors are logged (LogError)
- This is intentional and reflects common production practices