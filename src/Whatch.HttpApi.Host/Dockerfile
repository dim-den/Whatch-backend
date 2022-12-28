#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Whatch.HttpApi.Host/Whatch.HttpApi.Host.csproj", "src/Whatch.HttpApi.Host/"]
COPY ["src/Whatch.Application/Whatch.Application.csproj", "src/Whatch.Application/"]
COPY ["src/Whatch.Domain/Whatch.Domain.csproj", "src/Whatch.Domain/"]
COPY ["src/Whatch.Domain.Shared/Whatch.Domain.Shared.csproj", "src/Whatch.Domain.Shared/"]
COPY ["src/Whatch.Application.Contracts/Whatch.Application.Contracts.csproj", "src/Whatch.Application.Contracts/"]
COPY ["src/Whatch.EntityFrameworkCore/Whatch.EntityFrameworkCore.csproj", "src/Whatch.EntityFrameworkCore/"]
COPY ["src/Whatch.HttpApi/Whatch.HttpApi.csproj", "src/Whatch.HttpApi/"]
RUN dotnet restore "src/Whatch.HttpApi.Host/Whatch.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Whatch.HttpApi.Host"
RUN dotnet tool install -g Volo.Abp.Cli
RUN npm install
RUN dotnet build "Whatch.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Whatch.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Whatch.HttpApi.Host.dll"]