# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todo el código
COPY . .

# Restaurar dependencias
RUN dotnet restore

# Publicar el proyecto API
RUN dotnet publish isc.bempleo.be.api/isc.bempleo.be.api.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar el resultado del publish
COPY --from=build /app/publish .

# Exponer puerto
EXPOSE 8080

# Arranque de la aplicación
ENTRYPOINT ["dotnet", "isc.bempleo.be.api.dll"]
