# Development Environment Instructions

Welcome to the `HotelAspnetCore` project! This project has been upgraded to `.NET 9` and contains a Docker-based development environment to make onboarding easy. 

## Prerequisites

To run this project, ensure you have the following installed on your host machine:
1. [Docker Desktop](https://www.docker.com/products/docker-desktop)
2. [Visual Studio Code](https://code.visualstudio.com/)
3. The [Dev Containers](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers) extension for VS Code.

## Getting Started

Because this project uses DevContainers, you **do not** need to install the .NET SDK or PostgreSQL locally on your host machine. Everything is contained within Docker.

### 1. Open in DevContainer (VS Code)

1. Open the project folder `HotelAspnetCore` in VS Code.
2. An alert should appear in the bottom-right corner: `Folder contains a Dev Container configuration file. Reopen to develop in a container.`
3. Click **"Reopen in Container"**. 
   *(Alternatively, open the Command Palette `Ctrl+Shift+P` or `Cmd+Shift+P` and type `Dev Containers: Reopen in Container`)*.
4. VS Code will now build the `.NET 9` Docker image and start the `postgres` database in the background using `docker-compose`. This might take a few minutes the first time.
5. Once complete, you will have a full `.NET 9` development environment in your VS Code terminal, with all necessary C# extensions already installed.

### 2. Database (PostgreSQL)

The database runs automatically alongside the application container. The details for the PostgreSQL database (as defined in `docker-compose.yml`) are as follows:

- **Host**: `db` (when connecting from the .NET backend inside the DevContainer), or `localhost:5432` from your host machine.
- **Port**: `5432`
- **Username**: `postgres`
- **Password**: `postgrespassword`
- **Database Name**: `hoteldb`

Example Connection String for `appsettings.json` (inside the DevContainer):
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=db;Port=5432;Database=hoteldb;Username=postgres;Password=postgrespassword"
}
```

### 3. Build and Run the App

Open a terminal inside the VS Code DevContainer (it should open in `/workspace`):

```bash
# To build all projects
dotnet build HotelAspnetCore.sln

# To navigate to the Api project and run it
cd Api
dotnet run
```

If Entity Framework migrations need to be applied (e.g., if you are setting up the project for the first time):
```bash
# Ensure EF tools are installed globally
dotnet tool install --global dotnet-ef

# Update your database schema
dotnet ef database update --project Data --startup-project Api
```

## Stopping the Environment

When you are done, simply close the VS Code window, or open the Command Palette and select `Dev Containers: Close Dev Container`. The docker-compose services will stop until you reopen the container.
