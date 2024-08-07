# Blog API

## Architecture

The project follows a 5-layer architecture:
1. **API**: Web API controllers.
2. **Application**: Business logic and services.
3. **Domain**: Domain models.
4. **Infrastructure**: Data access, repositories, and migrations.
5. **Test**: Unit tests.

## Setup

### Prerequisites

- .NET 5 SDK
- Docker
- SQL Server

### Running the Application

1. Clone the repository:
    ```bash
    git clone <repository-url>    
    ```

2. Build and run the application with Docker:
    ```bash
    docker-compose up --build
    ```
3. Migrate database to target db
   The API will be available at `http://localhost:8080`.
 

## Design Pattern

The repository pattern is used to abstract data access logic, allowing the application to interact with the database in a clean and maintainable way.

## Unit Tests

Unit tests are written using the xUnit framework. To run the tests, use the following command:
```bash
dotnet test

## Note
I didn’t use AutoMapper because of performance issues. I also avoided using a generic repository due to concerns about extensibility and readability.
