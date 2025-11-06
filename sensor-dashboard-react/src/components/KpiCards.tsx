
import { SensorDto } from '../types'

function statBox(label: string, value: string, sub?: string) {
  return (
    <div className="card p-5">
      <div className="card-header">{label}</div>
      <div className="card-value mt-1">{value}</div>
      {sub && <div className="text-slate-500 text-sm mt-1">{sub}</div>}
    </div>
  )
}

export default function KpiCards({ sensors }: { sensors: SensorDto[] }) {
  const count = sensors.length
  const temps = sensors.map(s => parseFloat(s.temperature)).filter(n => !isNaN(n))
  const hums = sensors.map(s => parseFloat(s.humidity)).filter(n => !isNaN(n))
  const avgT = temps.length ? (temps.reduce((a,b)=>a+b,0)/temps.length).toFixed(1) : '—'
  const avgH = hums.length ? (hums.reduce((a,b)=>a+b,0)/hums.length).toFixed(0) : '—'
  const maxT = temps.length ? Math.max(...temps).toFixed(1) : '—'

  return (
    <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
      {statBox('Total Sensors', String(count))}
      {statBox('Average Temp (°C)', String(avgT))}
      {statBox('Max Temp (°C)', String(maxT), `Avg Humidity: ${avgH}%`)}
    </div>
  )
}
