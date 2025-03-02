import { ChangeEvent, FC, useState, useEffect } from 'react'
import { Status } from '@/types'
import { FormData } from '@/contexts'

interface StatusFieldProps {
  formData: FormData
  onChange: (e: ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>) => void
  mode: 'create' | 'edit'
  statuses: Status[]
}

export const StatusField: FC<StatusFieldProps> = ({ formData, onChange, statuses }) => {
  const [selectedStatus, setSelectedStatus] = useState<Status | null>(null)
  const projectStatuses = statuses.filter((status) => status.type === 'Project')

  useEffect(() => {
    if (formData.statusId && projectStatuses.length > 0) {
      setSelectedStatus(projectStatuses.find((s) => s.id === Number(formData.statusId)) || null)
    } else {
      setSelectedStatus(null)
    }
  }, [formData.statusId, projectStatuses])

  const handleStatusChange = (e: ChangeEvent<HTMLSelectElement>) => {
    onChange(e)
    setSelectedStatus(projectStatuses.find((s) => s.id === Number(e.target.value)) || null)
  }

  return (
    <div className="form-group">
      <label htmlFor="statusId">Status *</label>
      <div className="status-select-container">
        <select
          id="statusId"
          name="statusId"
          value={formData.statusId || ''}
          onChange={handleStatusChange}
          required
        >
          <option value="">Välj status</option>
          {projectStatuses.map((status) => (
            <option key={status.id} value={status.id}>
              {status.name}
            </option>
          ))}
        </select>
        {selectedStatus && <div />}
      </div>
    </div>
  )
}
