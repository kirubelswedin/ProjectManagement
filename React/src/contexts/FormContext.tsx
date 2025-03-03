import {
  ReactNode,
  useState,
  useCallback,
  createContext,
  useContext,
  FormEvent,
  ChangeEvent
} from 'react'
import { Client, Project, ProjectManager, ServiceType, Status } from '@/types'
import { useReferenceData } from './ReferenceDataContext'

export interface FormData extends Partial<Project> {
  clientId?: number
  statusId?: number
  projectManagerId?: number
  serviceTypeId?: number
}

interface FormContextType {
  formData: FormData
  isSubmitting: boolean
  handleFormChange: (
    e: ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>
  ) => void
  resetForm: () => void
  setFormDataFromProject: (project: Project | null) => void
  validateForm: () => string[]
}

export interface ProjectSubmissionData {
  projectName?: string
  description?: string
  startDate?: string
  endDate?: string
  budget?: number
  statusId?: number
  clientId?: number
  projectManagerId?: number
  serviceTypeId?: number
}

const FormContext = createContext<FormContextType | undefined>(undefined)

interface FormProviderProps {
  children: ReactNode
}

// Took help from gpt to implement this form context
export const FormProvider = ({ children }: FormProviderProps) => {
  const [formData, setFormData] = useState<FormData>({})
  const [isSubmitting, setIsSubmitting] = useState(false)
  const { clients, projectManagers, serviceTypes, statuses } = useReferenceData()

  const handleFormChange = useCallback(
    (e: ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>) => {
      setIsSubmitting(false)
      const { name, value } = e.target
      const numValue = value ? parseInt(value) : undefined

      switch (name) {
        case 'statusId': {
          const selectedStatus = statuses.find((s: Status) => s.id === numValue)
          setFormData((prev) => ({ ...prev, statusId: numValue, status: selectedStatus }))
          break
        }
        case 'clientId': {
          const selectedClient = clients.find((c: Client) => c.id === numValue)
          setFormData((prev) => ({ ...prev, clientId: numValue, client: selectedClient }))
          break
        }
        case 'projectManagerId': {
          const selectedManager = projectManagers.find((m: ProjectManager) => m.id === numValue)
          setFormData((prev) => ({
            ...prev,
            projectManagerId: numValue,
            projectManager: selectedManager
          }))
          break
        }
        case 'serviceTypeId': {
          const selectedServiceType = serviceTypes.find((s: ServiceType) => s.id === numValue)
          setFormData((prev) => ({
            ...prev,
            serviceTypeId: numValue,
            serviceType: selectedServiceType
          }))
          break
        }
        default:
          setFormData((prev) => ({
            ...prev,
            [name]: name === 'budget' ? (value ? Number(value) : undefined) : value
          }))
      }
    },
    [clients, projectManagers, serviceTypes, statuses]
  )

  const resetForm = useCallback(() => {
    setFormData({})
    setIsSubmitting(false)
  }, [])

  const setFormDataFromProject = useCallback(
    (project: Project | null) => {
      if (!project) {
        resetForm()
        return
      }

      setFormData({
        ...project,
        clientId: project.client?.id,
        statusId: project.status?.id,
        projectManagerId: project.projectManager?.id,
        serviceTypeId: project.serviceType?.id
      })
    },
    [resetForm]
  )

  const validateForm = useCallback((): string[] => {
    const errors = []

    if (!formData.projectName) errors.push('Projektnamn är obligatoriskt')
    else if (formData.projectName.length > 100)
      errors.push('Projektnamn får inte vara längre än 100 tecken')

    if (!formData.description) errors.push('Beskrivning är obligatoriskt')
    else if (formData.description.length > 500)
      errors.push('Beskrivning får inte vara längre än 500 tecken')

    if (!formData.startDate) errors.push('Startdatum är obligatoriskt')
    if (!formData.budget || formData.budget <= 0) errors.push('Budget måste vara större än 0')
    if (!formData.statusId) errors.push('Status är obligatoriskt')
    if (!formData.clientId) errors.push('Kund är obligatoriskt')
    if (!formData.projectManagerId) errors.push('Projektledare är obligatoriskt')
    if (!formData.serviceTypeId) errors.push('Tjänstetyp är obligatoriskt')

    return errors
  }, [formData])

  return (
    <FormContext.Provider
      value={{
        formData,
        isSubmitting,
        handleFormChange,
        resetForm,
        setFormDataFromProject,
        validateForm
      }}
    >
      {children}
    </FormContext.Provider>
  )
}

// Helper hook for handling form submission
export const useProjectForm = (onSubmit: (formData: ProjectSubmissionData) => Promise<void>) => {
  const { formData, handleFormChange, validateForm } = useForm()

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault()

    const validationErrors = validateForm()
    if (validationErrors.length > 0) {
      alert(`Vänligen åtgärda följande fel:\n${validationErrors.join('\n')}`)
      return
    }

    const submissionData: ProjectSubmissionData = {
      projectName: formData.projectName,
      description: formData.description,
      startDate: formData.startDate,
      endDate: formData.endDate,
      budget: formData.budget,
      statusId: formData.statusId,
      clientId: formData.clientId,
      projectManagerId: formData.projectManagerId,
      serviceTypeId: formData.serviceTypeId
    }

    await onSubmit(submissionData)
  }

  return {
    formData,
    handleChange: handleFormChange,
    handleSubmit
  }
}

// Hook for using the form context
export const useForm = () => {
  const context = useContext(FormContext)
  if (!context) {
    throw new Error('useForm måste användas inom en FormProvider')
  }
  return context
}
