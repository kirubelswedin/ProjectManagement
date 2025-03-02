import { ChangeEvent, FC } from 'react'
import { FormData } from '@/contexts/FormContext'
import { useReferenceData } from '@/contexts'
import {
  BasicInfoFields,
  StatusField,
  ClientField,
  ProjectManagerField,
  ServiceTypeField,
  BudgetField,
  DescriptionField
} from '@/components/project/FormComponents'

interface FieldProps {
  formData: FormData
  onChange: (e: ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>) => void
  mode: 'create' | 'edit'
}

export { BasicInfoFields, StatusField }

// fields client, project manager, service type, budget and description
export const AdditionalInfoFields: FC<FieldProps> = ({ formData, onChange }) => {
  const { clients, projectManagers, serviceTypes } = useReferenceData()

  return (
    <>
      <ClientField value={formData.clientId} onChange={onChange} clients={clients} />

      <ProjectManagerField
        value={formData.projectManagerId}
        onChange={onChange}
        projectManagers={projectManagers}
      />

      <ServiceTypeField
        value={formData.serviceTypeId}
        onChange={onChange}
        serviceTypes={serviceTypes}
      />

      <BudgetField formData={formData} onChange={onChange} />

      <DescriptionField value={formData.description} onChange={onChange} />
    </>
  )
}
