# Getting Started

## Prerequisites

- Docker installed and running on your machine
- .NET Core SDK installed on your machine

### Steps

#### 1. Run Docker Compose for PostgreSQL Database
```bash 
docker compose up
```

#### 2. Install Required Tools
```bash 
dotnet tool install --global dotnet-ef
```

#### 3. Verify EF Core Tools Installation
```bash 
dotnet ef
```

### 4. Apply EF Core Migrations
- Add the initial migration

	```bash 
	dotnet ef migrations add InitialCreate
	```
- Apply the migrations to the database

	```bash 
	dotnet ef database update
	```

#### 5. Run the .NET Project
```bash 
dotnet run
```