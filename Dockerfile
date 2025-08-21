# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BlogV3.Api/BlogV3.Api.csproj", "BlogV3.Api/"]
COPY ["BlogV3.Application/BlogV3.Application.csproj", "BlogV3.Application/"]
COPY ["BlogV3.Domain/BlogV3.Domain.csproj", "BlogV3.Domain/"]
COPY ["BlogV3.Common/BlogV3.Common.csproj", "BlogV3.Common/"]
COPY ["BlogV3.Infrastructure/BlogV3.Infrastructure.csproj", "BlogV3.Infrastructure/"]
RUN dotnet restore "./BlogV3.Api/BlogV3.Api.csproj"
COPY . .
WORKDIR "/src/BlogV3.Api"
RUN dotnet build "./BlogV3.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BlogV3.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogV3.Api.dll"]
