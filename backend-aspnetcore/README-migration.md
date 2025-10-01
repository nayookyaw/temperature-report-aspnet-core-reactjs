# ASP.NET Core Migration Starter (net8.0)

This folder contains a clean ASP.NET Core Web API you can drop-in as a replacement for your classic ASP.NET Web API.

## Why this template
- Uses .NET 8 (LTS), SDK-style project
- Built-in CORS
- Swagger (OpenAPI) enabled in Development
- EF Core with SQLite for quick local setup (swap to SQL Server easily)

# dependencies 
- dotnet tool install --global dotnet-ef

## Run it
```bash
cd backend-aspnetcore
dotnet restore Backend.csproj

dotnet ef database update --project .
dotnet run --project Backend.csproj

# opens https://localhost:5001 and http://localhost:5000
```

> If `dotnet-ef` isn't installed: `dotnet tool install --global dotnet-ef`

## Switch to SQL Server
1. Add the provider:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   ```
2. Change `Program.cs` registration:
   ```csharp
   builder.Services.AddDbContext<AppDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
   ```
3. Update `appsettings.json` connection string:
   ```json
   {
     "ConnectionStrings": {
       "Default": "Server=localhost;Database=AppDb;Trusted_Connection=True;TrustServerCertificate=True"
     }
   }
   ```
4. Create / apply migrations:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

## CORS
- Preconfigured `AllowFrontend` policy for `http://localhost:5173` / `3000`. Adjust origins as needed in `Program.cs`.

## Swagger
- Available at `/swagger` in Development.

## Porting tips from classic Web API
- Controllers now inherit from `ControllerBase` and use attributes like `[ApiController]` and `[Route("api/[controller]")]`.
- Replace `System.Web` constructs with ASP.NET Core equivalents (middleware for message handlers, filters become attributes/middleware).
- Model binding/validation is built-in; use `DataAnnotations` on your models as needed.
