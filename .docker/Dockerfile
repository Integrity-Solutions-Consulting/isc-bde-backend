# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

# Restaurar usando la solución
RUN dotnet restore isc.bempleo.be.sln

# Publicar la API
RUN dotnet publish isc.bempleo.be.api/isc.bempleo.be.api.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "isc.bempleo.be.api.dll"]
