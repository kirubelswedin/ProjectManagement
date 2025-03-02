import { FC } from 'react'
import '@/components/project/StatusFilter.css'

interface StatusFilterProps {
  activeStatus: string
  onStatusChange: (status: string) => void
}

export const StatusFilter: FC<StatusFilterProps> = ({ activeStatus, onStatusChange }) => {
  return (
    <div className="status-filter">
      <button
        className={`status-filter-button ${activeStatus === 'all' ? 'active' : ''}`}
        onClick={() => onStatusChange('all')}
      >
        Alla
      </button>
      <button
        className={`status-filter-button ${activeStatus === 'not-started' ? 'active' : ''}`}
        onClick={() => onStatusChange('not-started')}
      >
        Ej påbörjade
      </button>
      <button
        className={`status-filter-button ${activeStatus === 'in-progress' ? 'active' : ''}`}
        onClick={() => onStatusChange('in-progress')}
      >
        Pågående
      </button>
      <button
        className={`status-filter-button ${activeStatus === 'paused' ? 'active' : ''}`}
        onClick={() => onStatusChange('paused')}
      >
        Pausade
      </button>
      <button
        className={`status-filter-button ${activeStatus === 'completed' ? 'active' : ''}`}
        onClick={() => onStatusChange('completed')}
      >
        Avslutade
      </button>
      <button
        className={`status-filter-button ${activeStatus === 'cancelled' ? 'active' : ''}`}
        onClick={() => onStatusChange('cancelled')}
      >
        Avbrutna
      </button>
    </div>
  )
}
