
import { useEffect, useState } from 'react'
import { useSensors } from './api/sensors'
import KpiCards from './components/KpiCards'
import SensorTable from './components/SensorTable'

export default function App() {
  const { data, isLoading, error } = useSensors()
  const [tick, setTick] = useState(0)

  useEffect(() => {
    const interval = setInterval(() => {
      setTick(t => t + 1) // force UI refresh every 1s
    }, 1000)  
    return () => clearInterval(interval)
  }, [])

  return (
    <div className="min-h-screen">
      <header className="bg-brand-600 text-white">
        <div className="max-w-6xl mx-auto px-6 py-4 flex items-center justify-between">
          <h1 className="text-xl font-semibold">Temperature & Humidity Dashboard [Demo Purpose]</h1>
          <div className="text-brand-100 text-sm">Auto refresh every 1s</div>
        </div>
      </header>

      <main className="max-w-6xl mx-auto px-6 py-6 space-y-6">
        {isLoading && <div className="text-slate-600">Loading sensors…</div>}
        {error && <div className="text-red-600">Failed to load: {(error as Error).message}</div>}
        {data && <KpiCards sensors={data} />}
        {data && <SensorTable sensors={data} />}
      </main>

      <footer className="text-center text-slate-500 text-xs py-6">
        © {new Date().getFullYear()} Sensor Dashboard
      </footer>
    </div>
  )
}
