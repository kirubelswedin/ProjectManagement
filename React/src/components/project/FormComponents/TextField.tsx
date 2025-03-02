import { ChangeEvent, FC } from 'react'

interface TextFieldProps {
  label: string
  name: string
  value: string | number | undefined
  onChange: (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => void
  required?: boolean
  disabled?: boolean
  type?: 'text' | 'number' | 'date' | 'textarea'
  placeholder?: string
  min?: number
  max?: number
  step?: number
  rows?: number
}

export const TextField: FC<TextFieldProps> = ({
  label,
  name,
  value,
  onChange,
  required = false,
  disabled = false,
  type = 'text',
  placeholder = '',
  min,
  max,
  step,
  rows = 4
}) => (
  <div className="form-group">
    <label htmlFor={name}>
      {label}
      {required ? ' *' : ''}
    </label>

    {type === 'textarea' ? (
      <textarea
        id={name}
        name={name}
        value={value || ''}
        onChange={onChange}
        required={required}
        disabled={disabled}
        placeholder={placeholder}
        rows={rows}
      />
    ) : (
      <input
        type={type}
        id={name}
        name={name}
        value={value || ''}
        onChange={onChange}
        required={required}
        disabled={disabled}
        placeholder={placeholder}
        min={min}
        max={max}
        step={step}
      />
    )}
  </div>
)
