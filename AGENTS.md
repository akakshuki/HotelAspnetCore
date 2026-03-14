# AGENTS.md — HotelAspnetCore

> This file provides context for AI coding agents (Copilot, Gemini, Cursor, etc.)
> working on this repository. It describes the architecture, conventions, and
> development workflow so agents can produce accurate, idiomatic code changes.

---

## Project Overview

**HotelAspnetCore** is a hotel management system built with **ASP.NET Core 9.0** and **PostgreSQL 16**. It consists of two web applications and three shared libraries, all hosted in a single solution.

| Component | Type | Purpose |
|-----------|------|---------|
| **Api** | ASP.NET Core Web API | RESTful backend serving hotel data (rooms, bookings, services, guests, checkout) via Swagger |
| **AppAdmin** | ASP.NET Core MVC | Server-rendered admin dashboard that consumes the Api over HTTP |
| **Data** | Class Library | Entity Framework Core 9 data layer — entities, configurations, migrations, DbContext |
| **UnitOfWork** | Class Library | Repository + Unit of Work pattern wrapping `HotelDataContext` |
| **MomoConnector** | Class Library | MoMo payment gateway integration (RSA encryption, HMAC signing, HTTP requests) |
| **DemoPaypal-CSharp-API** | _(empty)_ | Placeholder for future PayPal integration |

---

## Architecture

```
┌──────────────┐      HTTP       ┌──────────────┐
│   AppAdmin   │ ──────────────► │     Api      │
│  (MVC Views) │                 │  (REST/JSON) │
└──────────────┘                 └──────┬───────┘
                                        │
                                        │ EF Core
                                        ▼
                                 ┌──────────────┐
                                 │  Data Layer  │
                                 │ (DbContext)  │
                                 └──────┬───────┘
                                        │
                                        │ UnitOfWork
                                        ▼
                                 ┌──────────────┐
                                 │  PostgreSQL  │
                                 │   (Docker)   │
                                 └──────────────┘
```

### Key Patterns

- **Unit of Work + Repository**: All database access goes through `IUnitOfWork` and `IRepository<T>`. Never use `HotelDataContext` directly in controllers.
- **StructureMap DI**: The Api project uses StructureMap for IoC (`DefaultRegistry.cs`). Standard ASP.NET DI is also configured in `Startup.cs`.
- **AutoMapper**: DTOs in `Api/Models/DTOs/` are mapped to/from entities via AutoMapper profiles in `Api/Models/Mappings/`.
- **Fluent API Configuration**: Entity configurations live in `Data/Configurations/` (one file per entity, implementing `IEntityTypeConfiguration<T>`).

---

## Domain Entities

| Entity | Description |
|--------|-------------|
| `Guest` | Hotel guest (name, phone, email, address, ID card) |
| `CategoryRoom` | Room category (Single, Double, Suite, etc.) |
| `Room` | Individual room linked to a category |
| `Booking` | A guest's booking with check-in/out dates and status |
| `BookRoom` | Junction table: Booking ↔ Room (many-to-many) |
| `CategoryService` | Service category (Food, Laundry, etc.) |
| `Service` | Individual hotel service with price |
| `Order` | A guest's service order during their stay |
| `OrderDetail` | Line item: Order ↔ Service (many-to-many) |

### Enums
- `BookedStatus` — Booking lifecycle states
- `Status` — Generic Active/Inactive flag
- `Payment` — Payment method types

---

## Project Structure

```
HotelAspnetCore/
├── .devcontainer/          # VS Code DevContainer config
│   └── devcontainer.json
├── Api/                    # REST API (Web API project)
│   ├── Configuration/      # StructureMap registry, CORS config
│   ├── Controllers/        # API controllers (one per resource)
│   ├── Models/
│   │   ├── DAOs/           # Data access objects
│   │   ├── DTOs/           # Data transfer objects (request/response)
│   │   └── Mappings/       # AutoMapper profiles
│   ├── Startup.cs          # Service & middleware configuration
│   ├── Program.cs          # Entry point
│   └── appsettings.json    # Connection strings, app config
├── AppAdmin/               # Admin MVC Dashboard
│   ├── Controllers/        # MVC controllers
│   ├── Models/             # ViewModels, DTOs, Enums
│   ├── Services/           # ApiService.cs — HTTP client to Api
│   ├── Views/              # Razor views
│   ├── wwwroot/            # Static assets (CSS, JS, Bootstrap)
│   ├── Startup.cs          # MVC service config
│   └── Program.cs          # Entry point
├── Data/                   # EF Core data layer
│   ├── Configurations/     # Fluent API entity configs
│   ├── EF/                 # HotelDataContext, DesignTimeFactory
│   ├── Entities/           # Domain entity classes
│   ├── Enums/              # Status, BookedStatus, Payment
│   └── Migrations/         # EF Core migrations (PostgreSQL)
├── UnitOfWork/             # Repository & Unit of Work pattern
│   ├── IRepository.cs      # Generic repository interface
│   ├── BaseRepository.cs   # Generic repository implementation
│   ├── IUnitOfWork.cs      # Unit of work interface
│   └── UnitOfWork .cs      # Unit of work implementation
├── MomoConnector/          # MoMo payment integration
│   ├── Model/              # MoMoSecurity, PaymentRequest
│   └── DTO/                # MoMo DTOs
├── Dockerfile              # Multi-stage build (targets: api, appadmin)
├── docker-compose.yml      # Production services (db, api, appadmin)
├── run-all.sh              # Dev helper: runs both apps simultaneously
├── data.base.sql           # Legacy SQL Server seed data (reference only)
└── HotelAspnetCore.sln     # Solution file
```

---

## Development Setup

### Prerequisites
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [VS Code](https://code.visualstudio.com/) with [Dev Containers](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers) extension

### Quick Start (Docker Compose — Production Mode)
```bash
docker compose up --build -d
```
| Service | URL |
|---------|-----|
| Api (Swagger) | http://localhost:5010/swagger |
| AppAdmin | http://localhost:4434 |
| PostgreSQL | localhost:5432 |

### Quick Start (DevContainer — Development Mode)
1. Open directory in VS Code
2. Click "Reopen in Container"
3. In the terminal: `./run-all.sh`

### Database
- **Provider**: Npgsql (PostgreSQL)
- **Connection string** (in container): `Host=db;Port=5432;Database=hoteldb;Username=postgres;Password=postgrespassword`
- **Migrations**: `dotnet ef migrations add <Name> --project Data --startup-project Api`
- **Apply**: `dotnet ef database update --project Data --startup-project Api`

---

## Coding Conventions

### General
- **Target framework**: `net9.0` for all projects
- **Namespaces**: Match folder structure (`Data.Entities`, `Api.Controllers`, etc.)
- **One class per file**, filename matches class name

### Api Controllers
- Inherit from `ControllerBase`
- Use `[ApiController]` and `[Route("api/[controller]")]` attributes
- Inject `IUnitOfWork` via constructor
- Return `IActionResult` or `ActionResult<T>`
- Use DTOs for request/response bodies, never expose entities directly

### Data Layer
- Add new entities in `Data/Entities/`
- Add corresponding Fluent API configuration in `Data/Configurations/` implementing `IEntityTypeConfiguration<T>`
- Register the `DbSet<T>` in `HotelDataContext`
- Register the `IRepository<T>` in `IUnitOfWork` and `UnitOfWork`
- Generate a migration after schema changes

### AppAdmin
- Uses MVC pattern with Razor views
- Communicates with the Api via `ApiService` (HTTP client), **not** directly with the database
- Default route: `{controller=Manage}/{action=Home}`

### Docker
- `Dockerfile` uses multi-stage builds with named targets (`api`, `appadmin`)
- Build context is always the repo root
- Environment variables override `appsettings.json` using the `__` separator (e.g., `ConnectionStrings__HotelDB`)

---

## Common Tasks

### Add a new entity
1. Create entity class in `Data/Entities/NewEntity.cs`
2. Create config in `Data/Configurations/NewEntityConfig.cs`
3. Add `DbSet<NewEntity>` to `HotelDataContext`
4. Add `IRepository<NewEntity>` to `IUnitOfWork` interface
5. Add `BaseRepository<NewEntity>` field and property to `UnitOfWork .cs`
6. Run: `dotnet ef migrations add AddNewEntity --project Data --startup-project Api`

### Add a new API endpoint
1. Create DTO in `Api/Models/DTOs/`
2. Create AutoMapper profile in `Api/Models/Mappings/`
3. Create controller in `Api/Controllers/` injecting `IUnitOfWork` and `IMapper`

### Add a new admin page
1. Create controller action in `AppAdmin/Controllers/`
2. Create Razor view in `AppAdmin/Views/<ControllerName>/`
3. Use `ApiService` to call the backend API

---

## Testing

> ⚠️ No test projects exist yet. When adding tests:
> - Create `Tests/` directory with an xUnit project targeting `net9.0`
> - Reference `Data`, `UnitOfWork`, and `Api` projects
> - Use in-memory database (`UseInMemoryDatabase`) for unit tests
> - Add test service to `docker-compose.yml` for integration tests

---

## Known Limitations
- `AppAdmin/Services/ApiService.cs` has a hardcoded base URL (`https://localhost:5001`). In Docker, the Api runs on `http://api:5000`. This should be made configurable via `appsettings.json` or environment variables.
- `MomoConnector` uses legacy `WebRequest` API. Should be migrated to `HttpClient`.
- The `DemoPaypal-CSharp-API` directory is empty and unused.
- The `data.base.sql` file contains legacy SQL Server seed data and is not compatible with PostgreSQL.
