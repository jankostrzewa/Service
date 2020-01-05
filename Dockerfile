#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["src/Service.API/Service.API.csproj", "src/Service.API/"]
COPY ["src/Service.Application/Service.Application.csproj", "src/Service.Application/"]
COPY ["src/Service.Infrastructure/Service.Infrastructure.csproj", "src/Service.Infrastructure/"]
COPY ["src/Service.Domain/Service.Domain.csproj", "src/Service.Domain/"]
RUN dotnet restore "src/Service.API/Service.API.csproj"
COPY . .
WORKDIR "/src/src/Service.API"
RUN dotnet build "Service.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Service.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service.API.dll"]