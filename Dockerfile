# Get base SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy the project files and build our release
COPY ./Commander/*.csproj ./
RUN dotnet restore

# Copy the project files and build our release
COPY ./Commander ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "Commander.dll" ]