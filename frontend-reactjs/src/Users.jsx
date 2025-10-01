
import React from 'react'
import { listUsers, createUser } from './api.js'

function Modal({ open, title, children, onClose }) {
  if (!open) return null
  return (
    <div aria-modal="true" role="dialog" onClick={onClose} style={{
      position: 'fixed', inset: 0, background: 'rgba(0,0,0,.2)', display: 'grid', placeItems: 'center', padding: 24
    }}>
      <div onClick={e => e.stopPropagation()} style={{
        width: 'min(560px, 96vw)', background: 'white', borderRadius: 16, boxShadow: '0 10px 30px rgba(0,0,0,.15)',
        padding: 20
      }}>
        <header style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
          <h3 style={{ margin: 0 }}>{title}</h3>
          <button onClick={onClose} aria-label="Close" style={{
            background: 'transparent', border: 0, fontSize: 20, cursor: 'pointer'
          }}>×</button>
        </header>
        <div style={{ marginTop: 12 }}>{children}</div>
      </div>
    </div>
  )
}

export default function Users() {
  const [data, setData] = React.useState({ items: [], total: 0 })
  const [page, setPage] = React.useState(1)
  const [pageSize, setPageSize] = React.useState(10)
  const [sortBy, setSortBy] = React.useState('CreatedAt')
  const [sortDir, setSortDir] = React.useState('desc')
  const [loading, setLoading] = React.useState(false)
  const [error, setError] = React.useState('')
  const [open, setOpen] = React.useState(false)
  const [form, setForm] = React.useState({ name: '', email: '' })
  const pages = Math.max(1, Math.ceil(data.total / pageSize))

  async function refetch() {
    try {
      setLoading(true)
      setError('')
      const res = await listUsers({ page, pageSize, sortBy, sortDir })
      setData(res)
    } catch (e) {
      setError(String(e.message || e))
    } finally {
      setLoading(false)
    }
  }

  React.useEffect(() => { refetch() }, [page, pageSize, sortBy, sortDir])

  async function onSubmit(e) {
    e.preventDefault()
    if (!form.name.trim()) return alert('Name is required')
    if (!/^[^@\s]+@[^@\s]+\.[^@\s]+$/.test(form.email)) return alert('Valid email required')
    try {
      await createUser({ name: form.name.trim(), email: form.email.trim() })
      setOpen(false)
      setForm({ name: '', email: '' })
      setPage(1)
      await refetch()
    } catch (e) {
      alert('Failed: ' + e.message)
    }
  }

  function header(label, key) {
    const active = sortBy === key
    const dir = active ? sortDir : 'asc'
    return (
      <th style={{ textAlign: 'left', padding: '10px 12px', fontWeight: 600, cursor: 'pointer' }}
        onClick={() => {
          if (active) setSortDir(dir === 'asc' ? 'desc' : 'asc')
          else { setSortBy(key); setSortDir('asc') }
        }}>
        {label} {active ? (dir === 'asc' ? '▲' : '▼') : ''}
      </th>
    )
  }

  return (
    <div>
      <div style={{ display: 'flex', gap: 12, alignItems: 'center', marginBottom: 12 }}>
        <button onClick={() => setOpen(true)} style={{
          background: 'linear-gradient(180deg, #4f46e5, #4338ca)',
          color: 'white', border: 0, padding: '10px 14px', borderRadius: 12, boxShadow: '0 6px 20px rgba(79,70,229,.3)',
          cursor: 'pointer', fontWeight: 600
        }}>+ Add User</button>

        <select value={pageSize} onChange={e => setPageSize(Number(e.target.value))}>
          {[5,10,20,50].map(n => <option key={n} value={n}>{n} / page</option>)}
        </select>

        <span style={{ marginLeft: 'auto', color: '#666' }}>
          {loading ? 'Loading…' : `${data.total} total`}
        </span>
      </div>

      {error && <div style={{ background: '#fee2e2', color: '#991b1b', padding: 12, borderRadius: 8, marginBottom: 12 }}>{error}</div>}

      <div style={{ overflow: 'auto', border: '1px solid #eee', borderRadius: 12 }}>
        <table style={{ width: '100%', borderCollapse: 'collapse' }}>
          <thead style={{ background: '#f8fafc', borderBottom: '1px solid #eee' }}>
            <tr>
              {header('ID', 'Id')}
              {header('Name', 'Name')}
              {header('Email', 'Email')}
              {header('Created', 'CreatedAt')}
            </tr>
          </thead>
          <tbody>
            {data.items.map(row => (
              <tr key={row.Id} style={{ borderTop: '1px solid #f1f5f9' }}>
                <td style={{ padding: '10px 12px' }}>{row.Id}</td>
                <td style={{ padding: '10px 12px' }}>{row.Name}</td>
                <td style={{ padding: '10px 12px' }}>{row.Email}</td>
                <td style={{ padding: '10px 12px' }}>{new Date(row.CreatedAt).toLocaleString()}</td>
              </tr>
            ))}
            {!data.items.length && !loading && (
              <tr><td colSpan="4" style={{ padding: 16, textAlign: 'center', color: '#666' }}>No data</td></tr>
            )}
          </tbody>
        </table>
      </div>

      <div style={{ display: 'flex', alignItems: 'center', gap: 8, marginTop: 12 }}>
        <button disabled={page<=1} onClick={() => setPage(p => Math.max(1, p-1))}>Prev</button>
        <span>Page {page} / {pages}</span>
        <button disabled={page>=pages} onClick={() => setPage(p => Math.min(pages, p+1))}>Next</button>
      </div>

      <Modal open={open} title="Add User" onClose={() => setOpen(false)}>
        <form onSubmit={onSubmit}>
          <div style={{ display: 'grid', gap: 10 }}>
            <label>
              <div>Name</div>
              <input value={form.name} onChange={e => setForm(f => ({...f, name: e.target.value}))}
                     placeholder="Jane Doe" style={{ width: '100%', padding: 10, borderRadius: 10, border: '1px solid #ddd' }}/>
            </label>
            <label>
              <div>Email</div>
              <input value={form.email} onChange={e => setForm(f => ({...f, email: e.target.value}))}
                     placeholder="jane@example.com" style={{ width: '100%', padding: 10, borderRadius: 10, border: '1px solid #ddd' }}/>
            </label>
            <div style={{ display: 'flex', gap: 10, justifyContent: 'flex-end', marginTop: 8 }}>
              <button type="button" onClick={() => setOpen(false)} style={{ background: 'transparent', border: '1px solid #ddd', padding: '10px 14px', borderRadius: 10, cursor: 'pointer' }}>Cancel</button>
              <button type="submit" style={{ background: '#16a34a', color: 'white', border: 0, padding: '10px 14px', borderRadius: 10, cursor: 'pointer' }}>Save</button>
            </div>
          </div>
        </form>
      </Modal>
    </div>
  )
}
