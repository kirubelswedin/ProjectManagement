import { ChangeEvent, FC } from 'react'
import { TextField } from './TextField'

interface DescriptionFieldProps {
  value: string | undefined
  onChange: (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => void
}

export const DescriptionField: FC<DescriptionFieldProps> = ({ value, onChange }) => {
  return (
    <TextField
      label="Beskrivning"
      name="description"
      value={value}
      onChange={onChange}
      type="textarea"
      rows={4}
    />
  )
}
