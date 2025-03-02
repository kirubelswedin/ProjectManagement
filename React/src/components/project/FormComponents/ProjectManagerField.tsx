import { ChangeEvent, FC } from 'react'
import { ProjectManager } from '@/types'
import { SelectField } from './SelectField'
import { isProjectManager, SelectOptionType, HasId } from './selectUtils'

interface ProjectManagerFieldProps {
  value: number | string | undefined
  onChange: (e: ChangeEvent<HTMLSelectElement>) => void
  projectManagers: ProjectManager[]
}

export const ProjectManagerField: FC<ProjectManagerFieldProps> = ({
  value,
  onChange,
  projectManagers
}) => {
  return (
    <SelectField
      label="Projektledare"
      name="projectManagerId"
      value={value}
      onChange={onChange}
      options={projectManagers}
      getOptionLabel={(option: SelectOptionType) => {
        if (isProjectManager(option)) {
          return `${option.firstName} ${option.lastName}`
        }
        return String((option as HasId).id)
      }}
    />
  )
}
