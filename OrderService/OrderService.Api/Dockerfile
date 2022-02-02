FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY ./bin/Release/net5.0/publish/ /app
ENTRYPOINT ["dotnet", "OrderService.Api.dll"]