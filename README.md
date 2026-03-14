# HotelAspnetCore

A hotel management system built with **ASP.NET Core 9.0**, **Entity Framework Core 9**, and **PostgreSQL 16**. Fully dockerized with a one-command startup.

---

## Architecture

| Component | Description |
|-----------|-------------|
| **Api** | REST API (Swagger at `/swagger`) — rooms, bookings, services, guests, checkout |
| **AppAdmin** | MVC admin dashboard — consumes the Api via HTTP |
| **Data** | EF Core data layer (entities, configs, migrations, DbContext) |
| **UnitOfWork** | Repository + Unit of Work abstraction |
| **MomoConnector** | MoMo payment gateway integration |

---

## Quick Start (Docker Compose)

```bash
# Start everything: PostgreSQL + Api + AppAdmin
docker compose up --build -d
```

| Service | URL |
|---------|-----|
| **Api** (Swagger) | http://localhost:5010/swagger |
| **AppAdmin** | http://localhost:4434 |
| **PostgreSQL** | localhost:5432 |

To stop:
```bash
docker compose down
```

---

## Development (DevContainer)

### Prerequisites
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [VS Code](https://code.visualstudio.com/) + [Dev Containers](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers) extension

### Steps
1. Open the project in VS Code
2. Click **"Reopen in Container"** (or `Cmd+Shift+P` → `Dev Containers: Reopen in Container`)
3. Run both apps:
   ```bash
   ./run-all.sh
   ```

---

## Database

- **Provider**: Npgsql (PostgreSQL)
- **Connection string**: `Host=db;Port=5432;Database=hoteldb;Username=postgres;Password=postgrespassword`

### Migrations
```bash
# Install EF tools (first time only)
dotnet tool install --global dotnet-ef

# Create a new migration
dotnet ef migrations add <MigrationName> --project Data --startup-project Api

# Apply migrations
dotnet ef database update --project Data --startup-project Api
```

---

## Project Structure

```
HotelAspnetCore/
├── Api/                    # REST API
├── AppAdmin/               # MVC Admin Dashboard
├── Data/                   # EF Core (Entities, Configs, Migrations)
├── UnitOfWork/             # Repository + UoW pattern
├── MomoConnector/          # MoMo payment integration
├── Dockerfile              # Multi-stage build (targets: api, appadmin)
├── docker-compose.yml      # PostgreSQL + Api + AppAdmin
├── .devcontainer/          # VS Code DevContainer config
├── run-all.sh              # Dev helper script
├── AGENTS.md               # AI agent instructions
└── HotelAspnetCore.sln     # Solution file
```

---

## For AI Agents

See [AGENTS.md](AGENTS.md) for detailed architecture, coding conventions, and step-by-step guides for common tasks like adding entities, API endpoints, and admin pages.
