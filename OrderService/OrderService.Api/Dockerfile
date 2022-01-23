#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OrderService.Domain/OrderService.Domain.csproj", "OrderService.Domain/"]
COPY ["OrderService.Api.Service/OrderService.Api.Service.csproj", "OrderService.Api.Service/"]
COPY ["OrderService.Api/OrderService.Api.csproj", "OrderService.Api/"]
COPY ["*.props", "./"]

RUN dotnet restore "OrderService.Domain/OrderService.Domain.csproj"
RUN dotnet restore "OrderService.Api.Service/OrderService.Api.Service.csproj"
RUN dotnet restore "OrderService.Api/OrderService.Api.csproj"
COPY . .
WORKDIR "/src/OrderService.Api"
RUN dotnet build "OrderService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderService.Api.dll"]