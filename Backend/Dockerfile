# Base image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Set up SDK build environment
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Copy entire backend into build context
COPY . ./

# Restore the solution — this gets all NuGet packages across all layers
RUN dotnet restore LibrarySystem.sln

# Publish the WebAPI project specifically
RUN dotnet publish Presentation/Library.WebAPI/Library.WebAPI.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
# Makes .NET listen on all interfaces, port 80.
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "Library.WebAPI.dll"]