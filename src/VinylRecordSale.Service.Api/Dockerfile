FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/VinylRecordSale.Service.Api/VinylRecordSale.Service.Api.csproj", "src/VinylRecordSale.Service.Api/"]
RUN dotnet restore "src/VinylRecordSale.Service.Api/VinylRecordSale.Service.Api.csproj"
COPY . .
WORKDIR "/src/src/VinylRecordSale.Service.Api"
RUN dotnet build "VinylRecordSale.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VinylRecordSale.Service.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VinylRecordSale.Service.Api.dll"]