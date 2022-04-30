#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Smitenight/Smitenight.Server/Smitenight.Server.csproj", "Smitenight/Smitenight.Server/"]
COPY ["Smitenight/Smitenight.Shared/Smitenight.Shared.csproj", "Smitenight/Smitenight.Shared/"]
COPY ["Smitenight/Smitenight.Client/Smitenight.Client.csproj", "Smitenight/Smitenight.Client/"]
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