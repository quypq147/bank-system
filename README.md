# Bank Sample: BankApi (.NET 8 Web API) + BankApp (WinForms .NET Framework 4.8)

Compact demo of a small core banking back-end with JWT auth + admin & customer WinForms client.

## Solution Layout
```
BankApi/      ASP.NET Core 8 Web API (EF Core + Identity + JWT)
BankApp/      WinForms client (Admin & Customer modes)
```

## Core Features
- Authentication & Authorization (ASP.NET Core Identity + JWT) ([`BankApi.Controllers.AuthController`](BankApi/Controllers/AuthController.cs), [`BankApi/Program.cs`](BankApi/Program.cs))
- Roles: Admin, Customer (seeded)
- Customer management ([`BankApi.Controllers.CustomersController`](BankApi/Controllers/CustomersController.cs))
- Accounts (Checking, Saving w/ term & payout) ([`BankApi.Controllers.AccountsController`](BankApi/Controllers/AccountsController.cs), [`BankApi.Services.AccountService`](BankApi/Services/AccountService.cs))
- Transactions: Deposit, Withdraw, Transfer, Interest credit, Adjustment ([`BankApi.Models.TransactionEntry`](BankApi/Models/TransactionEntry.cs))
- Interest engine: daily accrual + maturity processing ([`BankApi.Services.InterestEngine`](BankApi/Services/InterestEngine.cs), endpoints in [`InterestController`](BankApi/Controllers/InterestController.cs))
- Rates: Demand rates, Saving interest rules, FX mid rates ([`RatesController`](BankApi/Controllers/RatesController.cs))
- Reporting: transactions, accounts by type, daily balances ([`ReportsController`](BankApi/Controllers/ReportsController.cs))
- Statement endpoint returning transaction history ([`StatementQueryDto`](BankApi/Contracts/StatementDtos.cs))
- WinForms client:
  - Admin UI (`MainForm`) for ops
  - Customer UI (`UserForm`) auto-binds own account
  - JWT parsing & role-based form selection ([`BankApp.Program`](BankApp/Program.cs), [`LoginForm`](BankApp/LoginForm.cs))

## Data Model (selected)
Entity | Notes
-------|------
Customer ([`Customer`](BankApi/Models/Customer.cs)) | Basic KYC fields
Account ([`Account`](BankApi/Models/Account.cs)) | Checking/Saving, optional term, maturity
TransactionEntry ([`TransactionEntry`](BankApi/Models/TransactionEntry.cs)) | Ledger-like entries
DemandRate / InterestRule / FxRate | Time‐effective rate tables
DailyAccrual / DailyBalance | Support interest & reporting

Migrations: see initial migration [`20251001065128_Init`](BankApi/Migrations/20251001065128_Init.cs).

## Seed Data
Inserted in [`AppDbContext.OnModelCreating`](BankApi/Data/AppDbContext.cs):
- DemandRates (VND, USD)
- InterestRules (Saving 1–3M, 6–12M)
- FxRate (VND/USD mid)
- Roles + default admin user (in [`Program`](BankApi/Program.cs))

Admin credentials:
```
Email: admin@bank.local
Password: P@ssw0rd!
```

## JWT Claims
- `sub` = user id
- `customer_id` (if linked to a customer)
- `role` claims (multiple) for ASP.NET `[Authorize(Roles="...")]`
Parsing logic client-side: [`BankApp.Program.ExtractRoles`](BankApp/Program.cs), [`LoginForm.TryExtractRoles`](BankApp/LoginForm.cs)

## Key API Endpoints
Auth:
- POST `/api/auth/login`
- POST `/api/auth/register` (Admin)
- GET  `/api/auth/me`

Customers:
- POST `/api/customers`
- GET  `/api/customers/{id}`
- GET  `/api/customers?q=...`

Accounts:
- POST `/api/accounts/open` (Admin)
- GET  `/api/accounts/{accountNo}`
- POST `/api/accounts/deposit`
- POST `/api/accounts/withdraw`
- POST `/api/accounts/transfer`
- POST `/api/accounts/statement`

Interest batch (Admin):
- POST `/api/interest/accrue?date=YYYY-MM-DD`
- POST `/api/interest/mature-due?date=YYYY-MM-DD`

Rates:
- GET  `/api/rates/demand?currency=VND`
- GET  `/api/rates/saving-rules?class=Saving&term=6`
- POST `/api/rates/demand` (Admin)
- POST `/api/rates/saving-rules` (Admin)
- POST `/api/rates/fx` (Admin)

Reports (Admin or owning customer filtered):
- GET `/api/reports/transactions?from=&to=&accountNo=&type=&currency=`
- GET `/api/reports/accounts-by-type?class=&term=`
- GET `/api/reports/daily-balance?date=&currency=`

DTO references:  
- Accounts: [`AccountDtos`](BankApi/Contracts/AccountDtos.cs)  
- Statements: [`StatementDtos`](BankApi/Contracts/StatementDtos.cs)  
- Rates: [`RateDtos`](BankApi/Contracts/RateDtos.cs)  
- Reports: [`ReportDtos`](BankApi/Contracts/ReportDtos.cs)  

## WinForms Client (BankApp)
Key files:
- HTTP layer: [`ApiClient`](BankApp/Api/ApiClient.cs), [`BankApi`](BankApp/Api/BankApi.cs)
- Forms: [`MainForm`](BankApp/MainForm.cs), [`UserForm`](BankApp/UserForm.cs), [`LoginForm`](BankApp/LoginForm.cs)
- Shared DTO enums aligned with server: [`AccountDtos`](BankApp/Models/AccountDtos.cs)

Flow:
1. Launch BankApi.
2. Run BankApp → Login (admin shows MainForm, customer shows UserForm).
3. Admin:
   - Create customer
   - Create login user for customer
   - Open account
   - Perform transactions / query statements
4. Customer:
   - Auto-detected account
   - Deposit / Withdraw / Transfer (from owned account)
   - View statement

## Run Instructions
1. Prerequisites: .NET 8 SDK, SQL Server (LocalDB or instance).
2. Configure connection string in `BankApi/appsettings.Development.json`.
3. From `BankApi/`:
   ```
   dotnet restore
   dotnet ef database update   # if needed; migration present
   dotnet run
   ```
4. Browse Swagger: https://localhost:xxxx/swagger
5. Start `BankApp` (open `BankApp.sln` in Visual Studio or run).
6. Login using seeded admin; create customer + user; login as that user to test customer mode.

## Interest Batch Example
```
POST /api/interest/accrue?date=2025-01-05   (Admin)
POST /api/interest/mature-due?date=2025-04-05
```

## Transaction Types
Defined in [`TransactionEntry`](BankApi/Models/TransactionEntry.cs) and mirrored in client: Deposit, Withdraw, TransferIn, TransferOut, Fee, Interest, InterestCredit, Adjustment.

## Concurrency & Integrity
- Account balance updated inside explicit DB transactions (`DepositAsync`, `WithdrawAsync`, `TransferAsync` in [`AccountService`](BankApi/Services/AccountService.cs))
- RowVersion configured (optimistic concurrency placeholder)
- Indices: account no unique, composite indices for rates & accrual tables (see [`AppDbContext`](BankApi/Data/AppDbContext.cs))

## Security Notes
- JWT symmetric key from configuration (`Jwt:Key`)
- Role-based protection on admin-only endpoints
- Customer ownership enforcement in [`AccountsController`](BankApi/Controllers/AccountsController.cs) & reports

## Extensibility Ideas
- Add pagination to reports
- Add audit logging
- Implement optimistic concurrency checks using `RowVersion`
- Add refresh token handling
- Separate public vs admin subdomains

## Quick Test (cURL)
```
# Login
curl -X POST https://localhost:5001/api/auth/login ^
  -H "Content-Type: application/json" ^
  -d "{\"email\":\"admin@bank.local\",\"password\":\"P@ssw0rd!\"}"

# Create customer
curl -X POST https://localhost:5001/api/customers ^
  -H "Authorization: Bearer <TOKEN>" ^
  -H "Content-Type: application/json" ^
  -d "{\"fullName\":\"Alice\",\"email\":\"alice@test.local\",\"phone\":\"0900\",\"address\":\"HN\"}"
```

## License
For educational/demo use.

---
Generated referencing core source files: [`BankApi.Program`](BankApi/Program.cs), [`BankApi.Services.AccountService`](BankApi/Services/AccountService.cs), [`BankApi.Services.InterestEngine`](BankApi/Services/InterestEngine.cs).