FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Core/Tourism.Domain/Tourism.Domain.csproj", "src/Core/Tourism.Domain/"]
COPY ["src/Core/Tourism.Application/Tourism.Application.csproj", "src/Core/Tourism.Application/"]
COPY ["src/External/Tourism.Infrastructure/Tourism.Infrastructure.csproj", "src/External/Tourism.Infrastructure/"]
COPY ["src/External/Public/Tourism.API/Tourism.API.csproj", "src/External/Public/Tourism.API/"]

RUN dotnet restore "src/External/Public/Tourism.API/Tourism.API.csproj"
COPY . .

RUN dotnet build "src/External/Public/Tourism.API/Tourism.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "src/External/Public/Tourism.API/Tourism.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Tourism.API.dll"]