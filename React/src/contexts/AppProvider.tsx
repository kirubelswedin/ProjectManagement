import { ReactNode } from 'react'
import { ReferenceDataProvider } from './ReferenceDataContext'
import { FormProvider } from './FormContext'
import { ProjectProvider } from './ProjectContext'

interface AppProviderProps {
  children: ReactNode
}

export const AppProvider = ({ children }: AppProviderProps) => {
  return (
    <ReferenceDataProvider>
      <FormProvider>
        <ProjectProvider>{children}</ProjectProvider>
      </FormProvider>
    </ReferenceDataProvider>
  )
}
