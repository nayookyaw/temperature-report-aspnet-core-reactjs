        Developer - Nay Oo Kyaw
        Email - nayookyaw.nok@gmail.com

# dependencies


# migrate db
- dotnet ef migrations add InitialCreate --project .
(This generates a Migrations/ folder with migration files.) <br>

- dotnet ef database update --project .
(This will create the SQLite database file app.db (or update it if it already exists).) <br>

# run the backend app
- dotnet run --project Backend.csproj
