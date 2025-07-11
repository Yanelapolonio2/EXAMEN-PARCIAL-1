# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EXAMEN PARCIAL.csproj", "./"]  # Cambié el nombre del archivo .csproj
RUN dotnet restore "./EXAMEN PARCIAL.csproj"  # Restauramos dependencias
COPY . .
WORKDIR "/src/."
RUN dotnet build "EXAMEN PARCIAL.csproj" -c Release -o /app/build  # Cambié el nombre del proyecto
RUN dotnet publish "EXAMEN PARCIAL.csproj" -c Release -o /app/publish  # Cambié el nombre del proyecto

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EXAMEN PARCIAL.dll"]  # Cambié el nombre del archivo .dll
