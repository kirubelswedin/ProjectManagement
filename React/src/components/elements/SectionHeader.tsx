import { FC, ReactNode } from 'react'
import '@/components/elements/SectionHeader.css'

interface SectionHeaderProps {
  title: string
  subtitle?: string
  actionButton?: ReactNode
}

export const SectionHeader: FC<SectionHeaderProps> = ({ title, subtitle, actionButton }) => {
  return (
    <section className="section-header">
      <div className="section-header-text">
        <h2 className="section-title">{title}</h2>
        {subtitle && <p className="section-subtitle">{subtitle}</p>}
      </div>
      {actionButton && <div className="section-action">{actionButton}</div>}
    </section>
  )
}
