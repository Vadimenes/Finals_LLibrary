FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG CONFIGURATION=Release
WORKDIR /src

COPY ["LLibrary.csproj", "./"]
RUN dotnet restore "LLibrary.csproj"

COPY . .
RUN dotnet build "LLibrary.csproj" -c $CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "LLibrary.csproj" -c $CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY --from=publish /app/publish .

# Healthcheck (опционально, но круто для курсовой)
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*
HEALTHCHECK --interval=30s --timeout=10s --retries=3 CMD curl -f http://localhost:8080/ || exit 1

ENTRYPOINT ["dotnet", "LLibrary.dll"]