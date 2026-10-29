# CIB-Payment

A VB.NET / ASP.NET **payment gateway** built on a classic multi-tier
architecture, with a public customer site, a merchant admin portal and a WCF
integration service. An older project (circa 2013) kept for reference.

## Solution layout (`CIB_PaymentGateway/PaymentGateway.sln`)

**Class libraries (the tiers)**
- **Model** — entity classes (`MERCHANTS`, `SystemUser`).
- **DAL** — data access over ADO.NET (`System.Data.SqlClient`). `clsDAL`,
  `DataAccess`, `DBConnect` and `DataObject` run SQL Server **stored procedures**
  (e.g. `sp_userinformation`, `CIB_MERCHANTS_INSERT`, `CIB_MERCHANTS_UpdateByID`)
  with parameterised commands.
- **BLL** — business logic. `MerchantBLL` provides merchant CRUD and lookups
  (`GetMerchantByEmail`, `GetMerchantList`, `Insert`, `Update`); `clsBLL` holds
  shared logic.
- **Controller** — orchestration. `ControlEngine` handles user validation and
  password/status updates, `SessionManager` holds the logged-in session,
  `SystemUserBLL` manages admin users, `clsContract` carries credential DTOs.
  Includes wrong-attempt tracking and account lockout.

**Web applications**
- **www** — the public ASP.NET Web Forms site: account register / login /
  logout / change-password / reset, manual payment page
  (`Payments/PayMannual.aspx`), landing pages and master page.
- **PISAdmin** — the merchant/admin back-office portal (Web Forms): login,
  system-user management, file upload (jQuery MultiFile) and jQuery UI widgets
  with full datepicker i18n.
- **Payment** — the payment-processing web project.
- **MerchantIntegration** — a **WCF service** (`Service1.svc` / `IService1`)
  exposing operations for merchants to integrate with the gateway.

## Tech

VB.NET, ASP.NET Web Forms, WCF, ADO.NET + SQL Server stored procedures,
jQuery / jQuery UI. Licensed under **GPL-2.0** (see `LICENSE`).

## Configuration

Connection strings and settings live in each project's `Web.config` / `App.config`.
Provide your own SQL Server instance and the stored procedures the DAL calls.

## Status

A legacy reference project. Not maintained for production use.
