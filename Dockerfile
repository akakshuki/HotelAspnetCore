# ==============================
# Stage 1: Build
# ==============================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files first (for layer caching)
COPY HotelAspnetCore.sln ./
COPY Api/Api.csproj Api/
COPY AppAdmin/AppAdmin.csproj AppAdmin/
COPY Data/Data.csproj Data/
COPY UnitOfWork/UnitOfWork.csproj UnitOfWork/
COPY MomoConnector/MomoConnector.csproj MomoConnector/

# Restore dependencies
RUN dotnet restore HotelAspnetCore.sln

# Copy everything else
COPY . .

# ==============================
# Stage 2a: Publish Api
# ==============================
FROM build AS publish-api
RUN dotnet publish Api/Api.csproj -c Release -o /app/api --no-restore

# ==============================
# Stage 2b: Publish AppAdmin
# ==============================
FROM build AS publish-appadmin
RUN dotnet publish AppAdmin/AppAdmin.csproj -c Release -o /app/appadmin --no-restore

# ==============================
# Stage 3a: Runtime — Api
# ==============================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS api
WORKDIR /app
COPY --from=publish-api /app/api .
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 5000
ENTRYPOINT ["dotnet", "Api.dll"]

# ==============================
# Stage 3b: Runtime — AppAdmin
# ==============================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS appadmin
WORKDIR /app
COPY --from=publish-appadmin /app/appadmin .
ENV ASPNETCORE_URLS=http://+:4434
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 4434
ENTRYPOINT ["dotnet", "AppAdmin.dll"]
