
# Sensor Dashboard (React + TypeScript + Vite + Tailwind)

A beautiful, auto‑refreshing dashboard to display your API response from `/api/v1/sensor/list`.

## 1) Quick Start
```bash
# 1. Extract
unzip sensor-dashboard-react.zip && cd sensor-dashboard-react

# 2. Configure API base URL
cp .env.example .env
# Edit .env and set VITE_API_BASE_URL to your backend (e.g. http://192.168.68.59:5151)

# 3. Install & run
npm i
npm run dev
```

Open http://localhost:5173

## 2) API Contract
The frontend expects:
```json
{
  "data": [
    {
      "macAddress": "e4:5f:01:0a:79:bf",
      "temperature": "25.3",
      "humidity": "50",
      "lastUpdatedUtc": "2025-11-06T08:15:43.650663+00:00"
    }
  ],
  "statusCode": 200,
  "isSuccess": true,
  "message": "Sensor list has been retrieved"
}
```

## 3) Tech
- Vite + React + TypeScript
- Tailwind CSS for a modern look
- React Query for data fetching/auto‑refresh
- Axios
- date‑fns for relative time
- Recharts available for future charts

## 4) CORS
If you see CORS errors, enable CORS in your ASP.NET backend:
```csharp
builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod()));
app.UseCors();
```

## 5) Environment
- `.env` → put your base URL
```env
VITE_API_BASE_URL=http://192.168.68.59:5151
```
