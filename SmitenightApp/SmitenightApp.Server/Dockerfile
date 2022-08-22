FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SmitenightApp/SmitenightApp.Server/SmitenightApp.Server.csproj", "SmitenightApp/SmitenightApp.Server/"]
COPY ["SmitenightApp/SmitenightApp.Client/SmitenightApp.Client.csproj", "SmitenightApp/SmitenightApp.Client/"]
COPY ["SmitenightApp/SmitenightApp.CompositionRoot/SmitenightApp.CompositionRoot.csproj", "SmitenightApp/SmitenightApp.CompositionRoot/"]
COPY ["SmitenightApp/SmitenightApp.Application/SmitenightApp.Application.csproj", "SmitenightApp/SmitenightApp.Application/"]
COPY ["SmitenightApp/SmitenightApp.Abstractions.Application/SmitenightApp.Abstractions.Application.csproj", "SmitenightApp/SmitenightApp.Abstractions.Application/"]
COPY ["SmitenightApp/SmitenightApp.Domain/SmitenightApp.Domain.csproj", "SmitenightApp/SmitenightApp.Domain/"]
COPY ["SmitenightApp/SmitenightApp.Abstractions.Infrastructure/SmitenightApp.Abstractions.Infrastructure.csproj", "SmitenightApp/SmitenightApp.Abstractions.Infrastructure/"]
COPY ["SmitenightApp/SmitenightApp.Persistence/SmitenightApp.Persistence.csproj", "SmitenightApp/SmitenightApp.Persistence/"]
COPY ["SmitenightApp/SmitenightApp.Infrastructure.Keyvault/SmitenightApp.Infrastructure.KeyVault.csproj", "SmitenightApp/SmitenightApp.Infrastructure.Keyvault/"]
COPY ["SmitenightApp/SmitenightApp.Infrastructure.SmiteClient/SmitenightApp.Infrastructure.SmiteClient.csproj", "SmitenightApp/SmitenightApp.Infrastructure.SmiteClient/"]
RUN dotnet restore "SmitenightApp/SmitenightApp.Server/SmitenightApp.Server.csproj"
COPY . .
WORKDIR "/src/SmitenightApp/SmitenightApp.Server"
RUN dotnet build "SmitenightApp.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmitenightApp.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmitenightApp.Server.dll"]