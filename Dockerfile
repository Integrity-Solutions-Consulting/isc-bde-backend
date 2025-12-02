# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Permite forzar recompilación de caché si cambian dependencias
ARG CACHE_BREAKER=1

# Copiar solución y proyectos
COPY isc.bempleo.be.sln .

COPY isc.bempleo.be.api/isc.bempleo.be.api.csproj isc.bempleo.be.api/
COPY isc.bempleo.be.application/isc.bempleo.be.application.csproj isc.bempleo.be.application/
COPY isc.bempleo.be.domain/isc.bempleo.be.domain.csproj isc.bempleo.be.domain/
COPY isc.bempleo.be.infrastructure/isc.bempleo.be.infrastructure.csproj isc.bempleo.be.infrastructure/

# Restaurar dependencias
RUN dotnet restore isc.bempleo.be.sln

# Copiar todo el código fuente
COPY . .

# Compilar y publicar
RUN dotnet build isc.bempleo.be.sln -c Release -o /app/build
RUN dotnet publish isc.bempleo.be.api/isc.bempleo.be.api.csproj -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar artefactos publicados desde la etapa build
COPY --from=build /app/publish .

# Exponer el puerto interno
EXPOSE 8080

# Configurar variable de entorno por defecto (puede ser sobrescrita por docker-compose)
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

# Comando de inicio
ENTRYPOINT ["dotnet", "isc.bempleo.be.api.dll"]
