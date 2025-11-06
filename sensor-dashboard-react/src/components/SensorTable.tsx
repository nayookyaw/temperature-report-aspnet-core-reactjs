
import { SensorDto } from '../types'
import { tempColor, humidColor, relativeTime } from '../utils'
import clsx from 'clsx'

export default function SensorTable({ sensors }: { sensors: SensorDto[] }) {
  return (
    <div className="card overflow-hidden">
      <div className="px-5 pt-5">
        <h2 className="text-lg font-semibold text-slate-800">Sensors</h2>
        <p className="text-slate-500 text-sm">Live list with auto-refresh.</p>
      </div>
      <div className="overflow-x-auto">
        <table className="min-w-full text-sm">
          <thead className="bg-slate-100">
            <tr className="text-left">
              <th className="px-5 py-3 font-medium text-slate-600">MAC Address</th>
              <th className="px-5 py-3 font-medium text-slate-600">Temperature</th>
              <th className="px-5 py-3 font-medium text-slate-600">Humidity</th>
              <th className="px-5 py-3 font-medium text-slate-600">Last Updated</th>
            </tr>
          </thead>
          <tbody>
            {sensors.map((s, i) => {
              const t = parseFloat(s.temperature)
              const h = parseFloat(s.humidity)
              return (
                <tr key={s.macAddress + i} className={i % 2 ? 'bg-white' : 'bg-slate-50'}>
                  <td className="px-5 py-3 font-mono text-slate-800">{s.macAddress}</td>
                  <td className="px-5 py-3">
                    <span className={clsx('px-2 py-1 rounded-md ring-1', tempColor(t))}>
                      {isNaN(t) ? '—' : `${t.toFixed(1)} °C`}
                    </span>
                  </td>
                  <td className="px-5 py-3">
                    <span className={clsx('px-2 py-1 rounded-md ring-1', humidColor(h))}>
                      {isNaN(h) ? '—' : `${h.toFixed(0)} %`}
                    </span>
                  </td>
                  <td className="px-5 py-3 text-slate-600">{relativeTime(s.lastUpdatedUtc)}</td>
                </tr>
              )
            })}
          </tbody>
        </table>
      </div>
    </div>
  )
}
