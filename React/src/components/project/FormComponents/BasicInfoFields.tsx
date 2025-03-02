import { ChangeEvent, FC } from 'react'
import { FormData } from '@/contexts'
import { TextField } from './TextField'

interface BasicInfoFieldsProps {
  formData: FormData
  onChange: (e: ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>) => void
  mode: 'create' | 'edit'
}

export const BasicInfoFields: FC<BasicInfoFieldsProps> = ({ formData, onChange, mode }) => (
  <>
    <TextField
      label="Projektnr"
      name="projectNumber"
      value={formData.projectNumber}
      onChange={onChange}
      disabled={true}
      placeholder={mode === 'create' ? 'Genereras automatiskt' : ''}
    />

    <TextField
      label="Benämning"
      name="projectName"
      value={formData.projectName}
      onChange={onChange}
      required={true}
    />

    <TextField
      label="Startdatum"
      name="startDate"
      value={formData.startDate ? formData.startDate.split('T')[0] : ''}
      onChange={onChange}
      type="date"
      required={true}
    />

    <TextField
      label="Slutdatum"
      name="endDate"
      value={formData.endDate ? formData.endDate.split('T')[0] : ''}
      onChange={onChange}
      type="date"
    />
  </>
)
