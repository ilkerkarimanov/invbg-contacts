#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/InvBG.Contacts.Backend/InvBG.Contacts.Backend.csproj", "src/InvBG.Contacts.Backend/"]
RUN dotnet restore "./src/InvBG.Contacts.Backend/InvBG.Contacts.Backend.csproj"
COPY . .
WORKDIR "/src/src/InvBG.Contacts.Backend"
RUN dotnet build "./InvBG.Contacts.Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InvBG.Contacts.Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvBG.Contacts.Backend.dll"]