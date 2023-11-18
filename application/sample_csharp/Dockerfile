# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the project files to the container
COPY . .

# Restore dependencies and build the application
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the built application from the build image
COPY --from=build /app/out ./

# Expose the port the application will run on
EXPOSE 80

# Command to run the application
ENTRYPOINT ["dotnet", "sample_csharp.dll"]
