FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Antlr4Lang1/Antlr4Lang1.csproj", "Antlr4Lang1/"]
RUN dotnet restore "Antlr4Lang1/Antlr4Lang1.csproj"
COPY . .
WORKDIR "/src/Antlr4Lang1"
RUN dotnet build "Antlr4Lang1.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Antlr4Lang1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Antlr4Lang1.dll"]
