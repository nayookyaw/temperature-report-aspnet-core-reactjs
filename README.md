
# React + ASP.NET (.NET Framework) + MS SQL Starter

A minimal full-stack example:
- **Frontend:** React (Vite)
- **Backend:** ASP.NET Web API 2 on .NET Framework 4.8
- **ORM:** Entity Framework 6 with LINQ
- **DB:** MS SQL LocalDB

## Prereqs

- Windows + **Visual Studio 2019/2022** with .NET Framework dev tools
- **SQL Server Express LocalDB** (ships with VS) or full SQL Server
- **Node.js 18+** and **pnpm/npm/yarn**

## Backend Setup (Visual Studio)

1. In VS: File → New → Project → ASP.NET Web Application (.NET Framework).
2. Choose **Empty** template, check **Web API**.
3. Manage NuGet Packages:
   - Install `EntityFramework` (6.x)
   - Install `Microsoft.AspNet.WebApi.Cors`
4. Add/replace the files from `./backend` into your project.
5. Update `Web.config` connection string if necessary.
6. Run (IIS Express). Test: `GET http://localhost:5000/api/users` (your port may differ).

## Frontend Setup (Vite)

```bash
cd frontend
npm install
# optional: copy .env.example to .env and set VITE_API_BASE to your backend URL
npm run dev
```

The dev server proxies `/api/*` to your backend (see `vite.config.js`).

## API

- `GET /api/users?page=1&pageSize=10&sortBy=CreatedAt&sortDir=desc`
- `POST /api/users` with JSON `{ "name": "Jane", "email": "jane@example.com" }`

## Notes

- LINQ sorting/paging is implemented in `UsersController`.
- EF6 Code-First creates DB on first run (`AppDbInitializer`). Seed data is included.
- For production, add proper migrations and tighten CORS.
- If you prefer full MVC views instead of Web API, you can add MVC controllers/views.
