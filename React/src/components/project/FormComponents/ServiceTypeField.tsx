import { ChangeEvent, FC } from 'react'
import { ServiceType } from '@/types'
import { formatCurrency } from '@/utils/formatters'
import { SelectField } from '@/components/project/FormComponents'
import { isServiceType, SelectOptionType, HasId } from '@/components/project/FormComponents'

interface ServiceTypeFieldProps {
  value: number | string | undefined
  onChange: (e: ChangeEvent<HTMLSelectElement>) => void
  serviceTypes: ServiceType[]
}

export const ServiceTypeField: FC<ServiceTypeFieldProps> = ({ value, onChange, serviceTypes }) => {
  const getServiceTypeLabel = (serviceType: ServiceType): string => {
    return `${serviceType.name} - ${formatCurrency(serviceType.defaultHourlyRate, false)} kr/h`
  }

  return (
    <SelectField
      label="Tjänst"
      name="serviceTypeId"
      value={value}
      onChange={onChange}
      options={serviceTypes}
      getOptionLabel={(option: SelectOptionType) => {
        if (isServiceType(option)) {
          return getServiceTypeLabel(option)
        }
        return String((option as HasId).id)
      }}
    />
  )
}
