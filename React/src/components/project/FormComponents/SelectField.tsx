import { ChangeEvent, FC } from 'react'
import {
  SelectOptionType,
  HasId,
  isProjectManager,
  isServiceType,
  isStatus,
  hasName
} from './selectUtils'

interface SelectFieldProps {
  label: string
  name: string
  value: number | string | undefined
  onChange: (e: ChangeEvent<HTMLSelectElement>) => void
  options: SelectOptionType[]
  required?: boolean
  getOptionLabel?: (option: SelectOptionType) => string
}

export const SelectField: FC<SelectFieldProps> = ({
  label,
  name,
  value,
  onChange,
  options,
  required = false,
  getOptionLabel = (option: SelectOptionType) => {
    if (isStatus(option)) return option.name
    if (isServiceType(option)) return option.name
    if (isProjectManager(option)) return `${option.firstName} ${option.lastName}`
    if (hasName(option)) return option.name
    return String((option as HasId).id)
  }
}) => (
  <div className="form-group">
    <label htmlFor={name}>
      {label}
      {required ? ' *' : ''}
    </label>
    <div className="select-container">
      <select
        id={name}
        name={name}
        value={value || ''}
        onChange={onChange}
        required={required}
        className="form-select"
      >
        <option value="">Välj {label.toLowerCase()}</option>
        {options.map((option) => (
          <option key={(option as HasId).id} value={(option as HasId).id}>
            {getOptionLabel(option)}
          </option>
        ))}
      </select>
    </div>
  </div>
)
