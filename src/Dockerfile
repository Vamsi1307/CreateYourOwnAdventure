#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CreateYourOwnAdventure.Api/CreateYourOwnAdventure.Api.csproj", "CreateYourOwnAdventure.Api/"]
COPY ["CreateYourOwnAdventure.Infrastructure/CreateYourOwnAdventure.Infrastructure.csproj", "CreateYourOwnAdventure.Infrastructure/"]
COPY ["CreateYourOwnAdventure.Core/CreateYourOwnAdventure.Core.csproj", "CreateYourOwnAdventure.Core/"]
RUN dotnet restore "CreateYourOwnAdventure.Api/CreateYourOwnAdventure.Api.csproj"
COPY . .
WORKDIR "/src/CreateYourOwnAdventure.Api"
RUN dotnet build "CreateYourOwnAdventure.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CreateYourOwnAdventure.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CreateYourOwnAdventure.Api.dll"]