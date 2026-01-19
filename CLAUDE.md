# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build Commands

```bash
# Build entire solution (requires Visual Studio or MSBuild)
msbuild CIB_PaymentGateway/PaymentGateway.sln /p:Configuration=Release

# Build specific project
msbuild CIB_PaymentGateway/www/www.vbproj /p:Configuration=Debug

# Clean and rebuild
msbuild CIB_PaymentGateway/PaymentGateway.sln /t:Clean,Build /p:Configuration=Release
```

## Technology Stack

- **Language**: VB.NET
- **Framework**: .NET Framework 4.0
- **Web Framework**: ASP.NET Web Forms
- **Database**: SQL Server (uses stored procedures)
- **IDE**: Visual Studio 2010+ (solution format version 11.00)

## Architecture

This is a payment gateway system using a classic N-tier architecture:

```
┌─────────────────────────────────────────────────────────────┐
│                    Web Applications                          │
├──────────────┬──────────────┬───────────────┬───────────────┤
│     www      │   PISAdmin   │    Payment    │ MerchantInteg │
│ (User Portal)│ (Admin Panel)│  (Web App)    │  (WCF Service)│
└──────┬───────┴──────┬───────┴───────┬───────┴───────┬───────┘
       │              │               │               │
       └──────────────┴───────┬───────┴───────────────┘
                              │
                    ┌─────────▼─────────┐
                    │    Controller     │
                    │  (Business Logic) │
                    └─────────┬─────────┘
                              │
              ┌───────────────┼───────────────┐
              │               │               │
       ┌──────▼──────┐ ┌──────▼──────┐ ┌──────▼──────┐
       │    Model    │ │     BLL     │ │     DAL     │
       │ (Entities)  │ │(Bus. Layer) │ │(Data Access)│
       └─────────────┘ └─────────────┘ └──────┬──────┘
                                              │
                                       ┌──────▼──────┐
                                       │  SQL Server │
                                       │ (Stored Procs)│
                                       └─────────────┘
```

### Projects

| Project | Type | Purpose |
|---------|------|---------|
| **www** | ASP.NET Web Forms | Main user-facing portal (login, signup, payments) |
| **PISAdmin** | ASP.NET Web Forms | Admin panel for system user management |
| **Payment** | ASP.NET Web Forms | Payment processing pages |
| **MerchantIntegration** | WCF Service | API for merchant integration |
| **Controller** | Class Library | Business logic, user validation, session management |
| **BLL** | Class Library | Business logic layer |
| **DAL** | Class Library | Data access layer with `DBConnect` and `clsDAL` |
| **Model** | Class Library | Entity classes (`MERCHANTS`, `SystemUser`) |

### Key Classes

- `DAL/DBConnect.vb` - Database connection wrapper with `ExecuteReader`, `ExecuteScalar`, `ExecuteNonQuery` methods
- `DAL/clsDAL.vb` - Data access methods for user operations (stored procedure calls)
- `Controller/ControlEngine.vb` - User authentication and registration logic
- `Controller/SessionManager.vb` - User session state management
- `Controller/clsContract.vb` - Data contract for user details

### Database

- Uses SQL Server with stored procedures: `sp_userinformation`, `sp_IsValidUser`, `sp_GetUser`, `sp_UpdateStatus`, `sp_UpdatePassword`
- Database backup file: `CIB_PaymentGateway/cib.bak`
- Connection strings configured in `DAL/clsDAL.vb` and `DAL/DBConnect.vb`

### Authentication

- Forms authentication configured in `www/Web.config`
- Login flow in `www/Login.aspx` and `www/Account/Login.aspx`
- Account lockout after wrong attempts tracked via `WRONGATTAMPTS` and `STATUSID` fields
