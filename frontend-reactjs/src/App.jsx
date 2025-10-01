
import React from 'react'
import Users from './Users.jsx'

export default function App() {
  return (
    <div style={{ fontFamily: 'system-ui, -apple-system, Segoe UI, Roboto, Ubuntu, Cantarell, Noto Sans, Arial, sans-serif', padding: 24 }}>
      <h1 style={{ marginBottom: 8 }}>Users</h1>
      <p style={{ color: '#555', marginTop: 0 }}>React frontend talking to ASP.NET Web API + MS SQL.</p>
      <Users />
    </div>
  )
}
