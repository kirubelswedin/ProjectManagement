import { FC, FormEvent } from 'react'
import { Project } from '@/types'
import { Button } from '@/components/common'
import {
  BasicInfoFields,
  StatusField,
  AdditionalInfoFields
} from '@/components/project/ProjectForm/ProjectFormFields'
import { useReferenceData, useForm } from '@/contexts'
import '@/components/project/ProjectForm/ProjectForm.css'

interface ProjectFormProps {
  onSubmit: (formData: Partial<Project>) => Promise<void>
  onCancel: () => void
  isLoading?: boolean
  mode: 'create' | 'edit'
}

export const ProjectForm: FC<ProjectFormProps> = ({
  onSubmit,
  onCancel,
  isLoading = false,
  mode
}) => {
  const { statuses, loading: referenceDataLoading, error: referenceDataError } = useReferenceData()

  const { formData, handleFormChange, validateForm } = useForm()

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault()

    const validationErrors = validateForm()
    if (validationErrors.length > 0) {
      alert(`Vänligen åtgärda följande fel:\n${validationErrors.join('\n')}`)
      return
    }

    await onSubmit(formData)
  }

  if (referenceDataLoading) {
    return <div className="form-loading">Laddar formulärdata...</div>
  }

  if (referenceDataError) {
    return (
      <div className="form-error">
        <p>Ett fel uppstod när formulärdata skulle laddas:</p>
        <p>{referenceDataError}</p>
      </div>
    )
  }

  return (
    <div className="project-form-container">
      <form onSubmit={handleSubmit}>
        <div className="form-grid">
          <BasicInfoFields formData={formData} onChange={handleFormChange} mode={mode} />
          <StatusField
            formData={formData}
            onChange={handleFormChange}
            mode={mode}
            statuses={statuses}
          />
          <AdditionalInfoFields formData={formData} onChange={handleFormChange} mode={mode} />
        </div>

        <div className="form-actions">
          <Button className="cancel" variant="inverted" type="button" onClick={onCancel}>
            Avbryt
          </Button>
          <Button className="save" variant="primary" type="submit" disabled={isLoading}>
            {isLoading ? 'Sparar...' : mode === 'create' ? 'Skapa projekt' : 'Spara ändringar'}
          </Button>
        </div>
      </form>
    </div>
  )
}
