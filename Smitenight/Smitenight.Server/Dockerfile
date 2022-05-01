#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Smitenight/Smitenight.Server/Smitenight.Server.csproj", "Smitenight/Smitenight.Server/"]
COPY ["Smitenight/Smitenight.CompositionRoot/Smitenight.CompositionRoot.csproj", "Smitenight/Smitenight.CompositionRoot/"]
COPY ["Smitenight/Smitenight.Application/Smitenight.Application.csproj", "Smitenight/Smitenight.Application/"]
COPY ["Smitenight/Smitenight.Abstractions.Infrastructure/Smitenight.Abstractions.Infrastructure.csproj", "Smitenight/Smitenight.Abstractions.Infrastructure/"]
COPY ["Smitenight/Smitenight.Domain/Smitenight.Domain.csproj", "Smitenight/Smitenight.Domain/"]
COPY ["Smitenight/Smitenight.Abstractions.Application/Smitenight.Abstractions.Application.csproj", "Smitenight/Smitenight.Abstractions.Application/"]
COPY ["Smitenight/Smitenight.Infrastructure.Keyvault/Smitenight.Infrastructure.KeyVault.csproj", "Smitenight/Smitenight.Infrastructure.Keyvault/"]
COPY ["Smitenight/Smitenight.Client/Smitenight.Client.csproj", "Smitenight/Smitenight.Client/"]
COPY ["Smitenight/Smitenight.Shared/Smitenight.Shared.csproj", "Smitenight/Smitenight.Shared/"]
RUN dotnet restore "Smitenight/Smitenight.Server/Smitenight.Server.csproj"
COPY . .
WORKDIR "/src/Smitenight/Smitenight.Server"
RUN dotnet build "Smitenight.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Smitenight.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Smitenight.Server.dll"]