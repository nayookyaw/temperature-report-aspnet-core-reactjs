
import { intervalToDuration, parseISO } from 'date-fns'

export function tempColor(t: number) {
  if (t >= 35) return 'text-red-600 bg-red-50 ring-red-200'
  if (t >= 30) return 'text-orange-600 bg-orange-50 ring-orange-200'
  if (t >= 25) return 'text-amber-600 bg-amber-50 ring-amber-200'
  if (t >= 18) return 'text-emerald-600 bg-emerald-50 ring-emerald-200'
  return 'text-sky-700 bg-sky-50 ring-sky-200'
}

export function humidColor(h: number) {
  if (h >= 80) return 'text-blue-700 bg-blue-50 ring-blue-200'
  if (h >= 60) return 'text-cyan-700 bg-cyan-50 ring-cyan-200'
  if (h >= 40) return 'text-emerald-700 bg-emerald-50 ring-emerald-200'
  return 'text-slate-700 bg-slate-50 ring-slate-200'
}

export function relativeTime(iso?: string) {
  if (!iso) return '—'
  try {
    const now = new Date()
    const date = parseISO(iso)

    const duration = intervalToDuration({ start: date, end: now })

    const { days, hours, minutes, seconds } = duration
    const parts = []

    if (days && days > 0) parts.push(`${days}d`)
    if (hours && hours > 0) parts.push(`${hours}h`)
    
    // Always show minutes and seconds even if zero
    parts.push(`${minutes ?? 0}m`)
    parts.push(`${seconds ?? 0}s`)

    return parts.join(' ') + ' ago'
  } catch {
    return '—'
  }
}

