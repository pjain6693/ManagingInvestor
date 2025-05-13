# InvestorManagementApi

This is a simple .NET Web API for managing investors and the funds they are invested in. This version uses **mocked in-memory data** without SQL Server or Entity Framework database connections. It's ideal for demos, prototypes, or front-end integration testing.

---

## 📁 Project Structure

```
InvestorManagementApi/
│
├── Controllers/
│   └── InvestorsController.cs
│
├── Data/
│   ├── InvestorDbContext.cs        // Mocked in-memory context
│   └── DbInitializer.cs            // Seeds sample investors and funds
│
├── Models/
│   ├── Investor.cs                 // Investor model
│   ├── Fund.cs                     // Fund model
│   └── InvestorFund.cs             // Join model for many-to-many
│
├── Program.cs / Startup.cs         // API setup
└── README.md                       // This file
```

---

## 🔧 How to Run

1. **Clone the repository:**

   ```bash
   git clone https://github.com/your-repo/InvestorManagementApi.git
   cd InvestorManagementApi
   ```

2. **Run the project:**

   Use Visual Studio or CLI:

   ```bash
   dotnet run
   ```

3. **Swagger UI:**

   Navigate to:

   ```
   https://localhost:<port>/swagger
   ```

   Here you can test API endpoints interactively.

---

## 🧪 API Endpoints

### 1. Get all investors with funds

```
GET /api/investors
```

### 2. Get a single investor by name

```
GET /api/investors/{name}
```

### 3. Create a new investor

```
POST /api/investors
```

**Sample JSON:**

```json
{
  "name": "Pooja Smith",
  "phone": "(684) 842-2371",
  "email": "non.lacinia@outlook.org",
  "country": "Spain",
  "investorFunds": [
    {
      "fund": {
        "name": "Mauris LLP"
      }
    },
    {
      "fund": {
        "name": "Nullam Velit Fund"
      }
    }
  ]
}
```

> 💡 The controller will assign IDs and handle back-references automatically.

---

### 4. Add a fund to an existing investor

```
POST /api/investors/{investorName}/addfund?fundName=FundNameHere
```

### 5. Delete an investor

```
DELETE /api/investors/{name}
```

---

## 📌 Notes

- This project does **not use a real database**. All data is stored in memory and reset on each restart.
- Ideal for testing, prototyping, and front-end integration with static mock data.

---

## ✨ Future Enhancements

- Replace mock data with real database (e.g., EF Core + SQL Server)
- Add authentication/authorization
- Add pagination and filtering
- Add unit tests

---

## 📃 License

MIT License (or your preferred license)
