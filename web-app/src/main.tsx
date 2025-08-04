import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import MyUI from './App.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <MyUI />
  </StrictMode>,
)
