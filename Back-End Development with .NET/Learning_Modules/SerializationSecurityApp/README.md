# SerializationSecurityApp

A minimal .NET console project demonstrating **serialization and deserialization** of a `User` class with **sensitive data protection**.  

This project focuses on **safe handling of sensitive information** by incorporating **validation, encryption, hashing**, and **trusted source verification**.

---

## 🚀 Features

- **Serialization of `User` object** into JSON format
- **Encryption of sensitive fields** (password) before serialization
- **Hash generation** (SHA256) to verify data integrity
- **Deserialization only from trusted sources**
- **Input validation** to ensure required properties are present and valid

---

## 🧱 Tech Stack

- .NET 8  
- System.Text.Json  
- System.Security.Cryptography  

---

## ✅ Key Details

- **Validation**
  - Checks that `Name`, `Email`, and `Password` are not empty or null before serialization
- **Encryption**
  - Password is encrypted using Base64 encoding (demo; placeholder for real encryption)
- **Hashing**
  - SHA256 hash generated for the serialized object
  - Ensures data integrity and detects tampering
- **Trusted Source Verification**
  - Deserialization is allowed only from verified/trusted sources

---

## 🧠 Key Learning Points

- How **serialization and deserialization** works in JSON format
- How **sensitive data can be protected** using encryption
- How **hashing ensures integrity** of serialized data
- Importance of **trusted source checks** when deserializing
- Best practices for **clean separation of concerns** between domain and service logic

---

## 📌 Notes

- This project demonstrates encryption and hashing for **educational purposes**
  - Base64 encryption is **not secure**; real applications should use proper cryptography
- Printing passwords and hashes in the console is for demonstration only and **should not be done in production**
- Validation is performed in the domain class to ensure the object is always in a valid state
- Serialization, hashing, and trusted source verification could be moved to a **dedicated service** in a production-level project

---

## ▶️ Running the Application

1. Open the project in Visual Studio or VS Code  
2. Run the console application  
3. Observe the console output for:
   - Serialized JSON data with **encrypted password**
   - Generated hash for integrity verification
   - Successful deserialization from a trusted source
4. Verify that the deserialized `User` object matches the original (encrypted) data

---

## 💡 Future Improvements

- Move serialization, encryption, and hashing into a **UserSerializerService** for clean architecture
- Replace Base64 encryption with **secure hashing/encryption algorithms**
- Store and compare hashes for **real integrity verification** in production systems
- Extend validation to include:
  - Proper email format
  - Password strength rules
  - Business logic invariants (roles, age, etc.)
