import { Project } from '@/types'
import { fetchApi } from './core'

export const getProjects = (): Promise<Project[]> => {
  return fetchApi<Project[]>('/Projects')
}

export const getProject = (id: number): Promise<Project> => {
  return fetchApi<Project>(`/Projects/${id}`)
}

export const createProject = (project: Omit<Project, 'id' | 'projectNumber'>): Promise<Project> => {
  return fetchApi<Project>('/Projects', {
    method: 'POST',
    body: JSON.stringify(project)
  })
}

export const updateProject = (id: number, project: Partial<Project>): Promise<Project> => {
  return fetchApi<Project>(`/Projects/${id}`, {
    method: 'PUT',
    body: JSON.stringify(project)
  })
}

export const deleteProject = (id: number): Promise<void> => {
  return fetchApi<void>(`/Projects/${id}`, {
    method: 'DELETE'
  })
}
