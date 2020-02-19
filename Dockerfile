FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Management-Partner/Management-Partner.csproj", "Management-Partner/"]
COPY ["mp-Domain/mp-Domain.csproj", "mp-Domain/"]
COPY ["mp-ServiceFactory/mp-ServiceFactory.csproj", "mp-ServiceFactory/"]
COPY ["mp-RepositoryFactory/mp-RepositoryFactory.csproj", "mp-RepositoryFactory/"]
COPY ["mp-Service/mp-Service.csproj", "mp-Service/"]
COPY ["mp-DataTransferObject/mp-DataTransferObject.csproj", "mp-DataTransferObject/"]
COPY ["mp-Infrastructure/mp-Infrastructure.csproj", "mp-Infrastructure/"]
RUN dotnet restore "Management-Partner/Management-Partner.csproj"
COPY . .
WORKDIR "/src/Management-Partner"
RUN dotnet build "Management-Partner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Management-Partner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Management-Partner.dll"]