#!/bin/bash
# Install dotnet-ef if not already installed
export PATH="$PATH:/root/.dotnet/tools"
dotnet tool install --global dotnet-ef 2>/dev/null || true

# Apply database migrations
echo "--- applying migrations ---"
dotnet ef database update --project Data --startup-project Api

# Start Api on port 5000 (HTTP) and 5001 (HTTPS)
echo "--- starting Api on http://0.0.0.0:5000 ---"
ASPNETCORE_URLS="http://0.0.0.0:5000" dotnet run --project Api --no-launch-profile &

# Start AppAdmin on port 4434 (HTTP) and 4433 (HTTPS)
echo "--- starting AppAdmin on http://0.0.0.0:4434 ---"
ASPNETCORE_URLS="http://0.0.0.0:4434" dotnet run --project AppAdmin --no-launch-profile &

# Wait for background processes
wait
