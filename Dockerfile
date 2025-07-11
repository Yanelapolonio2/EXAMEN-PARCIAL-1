# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80  # Solo exponemos el puerto 8080 en producción

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EXAMEN PARCIAL.csproj", "./"]  # Asegúrate de que el nombre del proyecto sea correcto
RUN dotnet restore "./EXAMEN PARCIAL.csproj"  # Restauramos dependencias
COPY . .  # Copiamos el código fuente
WORKDIR "/src/."
RUN dotnet build "./EXAMEN PARCIAL.csproj" -c $BUILD_CONFIGURATION -o /app/build  # Compilamos el proyecto
RUN dotnet publish "./EXAMEN PARCIAL.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false  # Publicamos el proyecto

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .  # Copiamos los archivos generados por la fase de publicación
ENTRYPOINT ["dotnet", "EXAMEN PARCIAL.dll"]  # Asegúrate de que el nombre del DLL sea correcto
