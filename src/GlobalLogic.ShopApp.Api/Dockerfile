#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GlobalLogic.ShopApp.Api/GlobalLogic.ShopApp.Api.csproj", "GlobalLogic.ShopApp.Api/"]
RUN dotnet restore "GlobalLogic.ShopApp.Api/GlobalLogic.ShopApp.Api.csproj"
COPY . .
WORKDIR "/src/GlobalLogic.ShopApp.Api"
RUN dotnet build "GlobalLogic.ShopApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GlobalLogic.ShopApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GlobalLogic.ShopApp.Api.dll"]