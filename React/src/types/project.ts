import { Status, Client, ProjectManager, ServiceType } from '@/types'

export interface Project {
  id: number
  projectNumber: number
  projectName: string
  description?: string
  startDate: string
  endDate?: string
  budget: number

  status: Status
  client: Client
  projectManager: ProjectManager
  serviceType: ServiceType

  createdAt?: string
  updatedAt?: string
}
