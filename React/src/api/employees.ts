import { ProjectManager } from '@/types'
import { fetchApi } from './core'
import { employees } from '@/data/employees'

export const getProjectManagers = (): Promise<ProjectManager[]> =>
  fetchApi<ProjectManager[]>('/Employees').catch(() => Promise.resolve(employees))
