#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/CurrencyConverter.API/CurrencyConverter.API.csproj", "src/CurrencyConverter.API/"]
COPY ["src/CurrencyConverter.Application/CurrencyConverter.Application.csproj", "src/CurrencyConverter.Application/"]
COPY ["src/CurrencyConverter.Domain/CurrencyConverter.Domain.csproj", "src/CurrencyConverter.Domain/"]
RUN dotnet restore "src/CurrencyConverter.API/CurrencyConverter.API.csproj"
COPY . .
WORKDIR "/src/src/CurrencyConverter.API"
RUN dotnet build "CurrencyConverter.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CurrencyConverter.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CurrencyConverter.API.dll"]