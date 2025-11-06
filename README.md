   Nay Oo Kyaw
   nayookyaw.nok@gmail.com

# Temperature Report 
# React + ASP.NET (.NET Framework Core 9) + MS SQL Starter

# Backend

* Migration EF Core Migration
`dotnet ef migrations add InitialCreate`
`dotnet ef database update`

* Run the backend
`dotnet build`
`dotnet run`

# Dependencies
- Testing - Moq + xUnit
- Fluent API for migration order
- Validation - FluentValidation [used], Optional - Data Annotations

## Notes

- LINQ sorting/paging is implemented in `UsersController`
