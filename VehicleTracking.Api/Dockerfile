#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["VehicleTracking.Api/VehicleTracking.Api.csproj", "VehicleTracking.Api/"]
COPY ["VehicleTracking.Infrastructure/VehicleTracking.Infrastructure.csproj", "VehicleTracking.Infrastructure/"]
COPY ["VehicleTracking.Utility/VehicleTracking.Utils.csproj", "VehicleTracking.Utility/"]
COPY ["VehicleTracking.Application/VehicleTracking.Application.csproj", "VehicleTracking.Application/"]
RUN dotnet restore "VehicleTracking.Api/VehicleTracking.Api.csproj"
COPY . .
WORKDIR "/src/VehicleTracking.Api"
RUN dotnet build "VehicleTracking.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VehicleTracking.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehicleTracking.Api.dll"]
