#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Whatch.DbMigrator/Whatch.DbMigrator.csproj", "src/Whatch.DbMigrator/"]
COPY ["src/Whatch.Application.Contracts/Whatch.Application.Contracts.csproj", "src/Whatch.Application.Contracts/"]
COPY ["src/Whatch.Domain.Shared/Whatch.Domain.Shared.csproj", "src/Whatch.Domain.Shared/"]
COPY ["src/Whatch.EntityFrameworkCore/Whatch.EntityFrameworkCore.csproj", "src/Whatch.EntityFrameworkCore/"]
COPY ["src/Whatch.Domain/Whatch.Domain.csproj", "src/Whatch.Domain/"]
RUN dotnet restore "src/Whatch.DbMigrator/Whatch.DbMigrator.csproj"
COPY . .
WORKDIR "/src/src/Whatch.DbMigrator"
RUN dotnet build "Whatch.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Whatch.DbMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Whatch.DbMigrator.dll"]