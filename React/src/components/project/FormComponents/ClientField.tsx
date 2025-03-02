import { ChangeEvent, FC } from 'react'
import { Client } from '@/types'
import { SelectField } from './SelectField'

interface ClientFieldProps {
  value: number | string | undefined
  onChange: (e: ChangeEvent<HTMLSelectElement>) => void
  clients: Client[]
}

export const ClientField: FC<ClientFieldProps> = ({ value, onChange, clients }) => {
  return (
    <SelectField
      label="Kund"
      name="clientId"
      value={value}
      onChange={onChange}
      options={clients}
      required={true}
    />
  )
}
