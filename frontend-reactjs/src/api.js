
const BASE = import.meta.env.VITE_API_BASE || ''

export async function listUsers({ page = 1, pageSize = 10, sortBy = 'CreatedAt', sortDir = 'desc' } = {}) {
  const url = new URL('/api/users', BASE || window.location.origin)
  url.searchParams.set('page', page)
  url.searchParams.set('pageSize', pageSize)
  url.searchParams.set('sortBy', sortBy)
  url.searchParams.set('sortDir', sortDir)
  const res = await fetch(url.toString())
  if (!res.ok) throw new Error(`Failed to list users: ${res.status}`)
  return res.json()
}

export async function createUser(payload) {
  const res = await fetch((BASE || '') + '/api/users', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(payload)
  })
  if (!res.ok) throw new Error(`Failed to create user: ${res.status}`)
  return res.json()
}
