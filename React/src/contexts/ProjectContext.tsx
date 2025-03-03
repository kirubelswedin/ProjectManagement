import { ReactNode, useState, useEffect, useCallback, createContext, useContext } from 'react'
import { Project } from '@/types'
import { getProjects, getProject, createProject, updateProject, deleteProject } from '@/api'
import { useForm } from './FormContext'

// Cache for projects
let projectsCache: Project[] | null = null

export interface ProjectOperationResult {
  success: boolean
}

interface ProjectContextType {
  projects: Project[]
  selectedProject: Project | null
  loading: boolean
  error: string | null
  fetchProjects: (forceRefresh?: boolean) => Promise<void>
  fetchProject: (id: number) => Promise<void>
  addProject: (project: Omit<Project, 'id' | 'projectNumber'>) => Promise<ProjectOperationResult>
  editProject: (id: number, project: Partial<Project>) => Promise<ProjectOperationResult>
  removeProject: (id: number) => Promise<void>
  getNextProjectNumber: () => string
}

const ProjectContext = createContext<ProjectContextType | undefined>(undefined)

interface ProjectProviderProps {
  children: ReactNode
}

// Took help from gpt to implement this project context
// manages the project data and project related operations
export const ProjectProvider = ({ children }: ProjectProviderProps) => {
  const [projects, setProjects] = useState<Project[]>(projectsCache || [])
  const [selectedProject, setSelectedProject] = useState<Project | null>(null)
  const [loading, setLoading] = useState<boolean>(!projectsCache)
  const [error, setError] = useState<string | null>(null)
  const { setFormDataFromProject } = useForm()

  const fetchProjects = useCallback(async (forceRefresh = false) => {
    if (projectsCache && !forceRefresh) {
      setProjects(projectsCache)
      setLoading(false)
      return
    }

    try {
      setLoading(true)
      setError(null)
      const data = await getProjects()
      setProjects(data)
      projectsCache = data
    } catch {
      setError('Kunde inte hämta projekt')
    } finally {
      setLoading(false)
    }
  }, [])

  const fetchProject = useCallback(
    async (id: number) => {
      try {
        setLoading(true)
        setError(null)

        const cachedProject = projectsCache?.find((p) => p.id === id)
        if (cachedProject) {
          setSelectedProject(cachedProject)
          setFormDataFromProject(cachedProject)
          setLoading(false)
          return
        }

        const data = await getProject(id)
        setSelectedProject(data)
        setFormDataFromProject(data)
      } catch {
        setError('Kunde inte hämta projekt')
      } finally {
        setLoading(false)
      }
    },
    [setFormDataFromProject]
  )

  const addProject = useCallback(
    async (project: Omit<Project, 'id' | 'projectNumber'>) => {
      try {
        setLoading(true)
        setError(null)
        await createProject(project)
        await fetchProjects(true)
        return { success: true }
      } catch (err) {
        setError('Kunde inte skapa projekt')
        throw err
      } finally {
        setLoading(false)
      }
    },
    [fetchProjects]
  )

  const editProject = useCallback(
    async (id: number, project: Partial<Project>) => {
      try {
        setLoading(true)
        setError(null)
        await updateProject(id, project)
        await fetchProjects(true)

        if (selectedProject?.id === id) {
          await fetchProject(id)
        }

        return { success: true }
      } catch (err) {
        setError('Kunde inte uppdatera projekt')
        throw err
      } finally {
        setLoading(false)
      }
    },
    [fetchProjects, fetchProject, selectedProject]
  )

  const removeProject = useCallback(
    async (id: number) => {
      try {
        setLoading(true)
        setError(null)
        await deleteProject(id)

        const updatedProjects = projects.filter((p) => p.id !== id)
        setProjects(updatedProjects)
        projectsCache = updatedProjects

        if (selectedProject?.id === id) {
          setSelectedProject(null)
          setFormDataFromProject(null) // Reset form
        }
      } catch (err) {
        setError('Kunde inte ta bort projekt')
        throw err
      } finally {
        setLoading(false)
      }
    },
    [projects, selectedProject, setFormDataFromProject]
  )

  const getNextProjectNumber = useCallback((): string => {
    if (projects.length === 0) return '101'
    const maxProjectNumber = Math.max(...projects.map((p) => parseInt(p.projectNumber.toString())))
    return (maxProjectNumber + 1).toString()
  }, [projects])

  useEffect(() => {
    fetchProjects()
  }, [fetchProjects])

  // Update form when a project is selected
  useEffect(() => {
    setFormDataFromProject(selectedProject)
  }, [selectedProject, setFormDataFromProject])

  return (
    <ProjectContext.Provider
      value={{
        projects,
        selectedProject,
        loading,
        error,
        fetchProjects,
        fetchProject,
        addProject,
        editProject,
        removeProject,
        getNextProjectNumber
      }}
    >
      {children}
    </ProjectContext.Provider>
  )
}
// Hook for using the project context
export const useProjects = () => {
  const context = useContext(ProjectContext)
  if (!context) {
    throw new Error('useProjects måste användas inom en ProjectProvider')
  }
  return context
}
