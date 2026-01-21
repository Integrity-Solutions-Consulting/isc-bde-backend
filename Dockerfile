FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copiamos SOLO el csproj de la API
COPY ["isc.bempleo.be.api/isc.bempleo.be.api.csproj", "isc.bempleo.be.api/"]

# 2. Restauramos dependencias (RUTA CORRECTA)
RUN dotnet restore "isc.bempleo.be.api/isc.bempleo.be.api.csproj"

# 3. Copiamos todo el resto del código
COPY . .

# 4. Nos movemos al directorio del proyecto API
WORKDIR /src/isc.bempleo.be.api

# 5. Publicamos
RUN dotnet publish "isc.bempleo.be.api.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# --- Etapa Final ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "isc.bempleo.be.api.dll"]
