# HowToMakeCodeFirst
A step-by-step guide on how to implement the **Entity Framework Core (Code-First)** approach in a .NET project.
##  Prerequisites
Before you begin, make sure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine. You will also need the EF Core CLI tools.
---
##  Step-by-Step Guide
### Step 1: Install Required NuGet Packages
First, install the necessary Entity Framework Core packages that match your .NET version. You can do this via the NuGet Package Manager or the terminal. 
For SQL Server, install the following packages:
- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microsoft.EntityFrameworkCore.Design`
- `Microsoft.EntityFrameworkCore.SqlServer` 
*(Note: If you are using a different database like PostgreSQL or MySQL, make sure to install the corresponding package instead of SqlServer).*
### Step 2: Create Models and DataContext
1. Create a `Models` folder in your project and define your entity classes inside it.
2. Create a `DataContext` class (inheriting from `DbContext`) for database operations.
3. Add the constructor and define your tables using `DbSet`:
```csharp
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    // Example table definition
    public DbSet<Customer> Customers { get; set; }
}
```
### Step 3: Configure the Connection String
Open your `appsettings.json` file and add the database connection string. Set your server and database names accordingly:
```csharp

builder.Services.AddDbContext<DataContext>(options => 
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});
````
### Step 4: Register DataContext in `Program.cs`
Go to your Program.cs file to register your DataContext and pass the connection string from the configuration:
```csharp

builder.Services.AddDbContext<DataContext>(options => 
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});
```
### Step 5: Build and Apply Migrations
Before creating a migration, it's a good practice to build your project and fix any compilation errors:
```terminal
dotnet build
```
Once the build is successful, open your terminal and run the following command to create your first migration (this will create a `Migrations` folder in your project):
```
dotnet ef migrations add InitialCreate
```
Finally, apply this migration to create your physical database:
```
dotnet ef database update
```







