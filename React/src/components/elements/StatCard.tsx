import { FC, ReactNode } from 'react'
import '@/components/elements'

interface StatCardProps {
  value: string | number
  label: string
  colorClass?: string
  icon?: ReactNode
}

export const StatCard: FC<StatCardProps> = ({ value, label, colorClass = '', icon }) => {
  return (
    <div className="stat-card">
      {icon && <div className="stat-icon">{icon}</div>}
      <div className="stat-content">
        <span className={`stat-value ${colorClass}`}>{value}</span>
        <span className="stat-label">{label}</span>
      </div>
    </div>
  )
}
