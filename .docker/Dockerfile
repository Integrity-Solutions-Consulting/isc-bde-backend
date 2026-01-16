FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copiamos solo el csproj
COPY isc.bempleo.be.api/isc.bempleo.be.api.csproj isc.bempleo.be.api/

# 2. Restore (RUTA CORRECTA)
RUN dotnet restore isc.bempleo.be.api/isc.bempleo.be.api.csproj

# 3. Copiamos todo el código
COPY . .

# 4. Publicamos
WORKDIR /src/isc.bempleo.be.api
RUN dotnet publish isc.bempleo.be.api.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "isc.bempleo.be.api.dll"]
