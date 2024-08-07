# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project files and restore dependencies
COPY Blog.sln .
COPY src/api/blog.api/blog.api.csproj ./src/api/blog.api/
COPY src/application/blog.application/blog.application.csproj ./src/application/blog.application/
COPY src/domain/blog.domain/blog.domain.csproj ./src/domain/blog.domain/
COPY src/infrastructure/blog.infrastructure/blog.infrastructure.csproj ./src/infrastructure/blog.infrastructure/

RUN dotnet restore

# Copy the rest of the project files
COPY . .

# Build the project
RUN dotnet build -c Release -o out

# Use the official ASP.NET Core runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the built files from the build stage
COPY --from=build /app/out .

# Expose the port on which the app will run
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "blog.api.dll"]
