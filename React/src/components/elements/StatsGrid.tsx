import { FC, ReactNode } from 'react'
import '@/components/elements/StatsGrid.css'

interface StatsGridProps {
  children: ReactNode
  title?: string
  columns?: number
}

export const StatsGrid: FC<StatsGridProps> = ({ children, title, columns = 3 }) => {
  return (
    <div className="stats-grid-container">
      {title && <h2 className="stats-grid-title">{title}</h2>}
      <div className="stats-grid" style={{ gridTemplateColumns: `repeat(${columns}, 1fr)` }}>
        {children}
      </div>
    </div>
  )
}
