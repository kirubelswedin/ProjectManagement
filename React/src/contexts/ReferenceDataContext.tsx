/* eslint-disable react-refresh/only-export-components */
import { ReactNode, useState, useEffect, useCallback, createContext, useContext } from 'react'
import { Client, ProjectManager, ServiceType, Status } from '@/types'
import { getClients, getProjectManagers, getServiceTypes, getStatuses } from '@/api'

// Cache för referensdata
let clientsCache: Client[] | null = null
let projectManagersCache: ProjectManager[] | null = null
let serviceTypesCache: ServiceType[] | null = null
let statusesCache: Status[] | null = null

interface ReferenceDataContextType {
  clients: Client[]
  projectManagers: ProjectManager[]
  serviceTypes: ServiceType[]
  statuses: Status[]
  loading: boolean
  error: string | null
  refetch: () => Promise<void>
}

export const ReferenceDataContext = createContext<ReferenceDataContextType | undefined>(undefined)

interface ReferenceDataProviderProps {
  children: ReactNode
}

// generic type for data configuration
interface DataConfig<T> {
  fetch: () => Promise<T[]>
  path: string
  key: string
  setter: (data: T[]) => void
  cache: (data: T[]) => void
}

// Took some help from gpt to implement this reference data provider
// manages the reference data, makes data available to the app
export const ReferenceDataProvider = ({ children }: ReferenceDataProviderProps) => {
  const [clients, setClients] = useState<Client[]>(clientsCache || [])
  const [projectManagers, setProjectManagers] = useState<ProjectManager[]>(
    projectManagersCache || []
  )
  const [serviceTypes, setServiceTypes] = useState<ServiceType[]>(serviceTypesCache || [])
  const [statuses, setStatuses] = useState<Status[]>(statusesCache || [])
  const [loading, setLoading] = useState(
    !clientsCache || !projectManagersCache || !serviceTypesCache || !statusesCache
  )
  const [error, setError] = useState<string | null>(null)

  const fetchReferenceData = useCallback(async () => {
    if (clientsCache && projectManagersCache && serviceTypesCache && statusesCache) {
      setClients(clientsCache)
      setProjectManagers(projectManagersCache)
      setServiceTypes(serviceTypesCache)
      setStatuses(statusesCache)
      setLoading(false)
      return
    }

    setLoading(true)
    setError(null)

    // function for fetching data with fallback
    const fetchWithFallback = async <T,>(config: DataConfig<T>): Promise<boolean> => {
      try {
        const data = await config.fetch()
        config.setter(data)
        config.cache(data)
        return true
      } catch {
        try {
          const module = await import(/* @vite-ignore */ config.path)
          const fallbackData = module[config.key]
          config.setter(fallbackData)
          config.cache(fallbackData)
          return true
        } catch {
          console.error(`Kunde inte ladda fallback-data från ${config.path}`)
          config.setter([])
          return false
        }
      }
    }

    // Configure data fetching
    const statusConfig: DataConfig<Status> = {
      fetch: getStatuses,
      path: '@/data/statuses',
      key: 'statuses',
      setter: setStatuses,
      cache: (data) => {
        statusesCache = data
      }
    }

    const serviceTypeConfig: DataConfig<ServiceType> = {
      fetch: getServiceTypes,
      path: '@/data/serviceTypes',
      key: 'serviceTypes',
      setter: setServiceTypes,
      cache: (data) => {
        serviceTypesCache = data
      }
    }

    const clientConfig: DataConfig<Client> = {
      fetch: getClients,
      path: '@/data/clients',
      key: 'clients',
      setter: setClients,
      cache: (data) => {
        clientsCache = data
      }
    }

    const projectManagerConfig: DataConfig<ProjectManager> = {
      fetch: getProjectManagers,
      path: '@/data/employees',
      key: 'employees',
      setter: setProjectManagers,
      cache: (data) => {
        projectManagersCache = data
      }
    }

    // Fetch all data in parallel
    const results = await Promise.all([
      fetchWithFallback(statusConfig),
      fetchWithFallback(serviceTypeConfig),
      fetchWithFallback(clientConfig),
      fetchWithFallback(projectManagerConfig)
    ])

    if (!results.some((result) => result)) {
      setError('Kunde inte ladda referensdata')
    }

    setLoading(false)
  }, [])

  useEffect(() => {
    fetchReferenceData()
  }, [fetchReferenceData])

  return (
    <ReferenceDataContext.Provider
      value={{
        clients,
        projectManagers,
        serviceTypes,
        statuses,
        loading,
        error,
        refetch: fetchReferenceData
      }}
    >
      {children}
    </ReferenceDataContext.Provider>
  )
}
// Hook for using the reference data context
export const useReferenceData = () => {
  const context = useContext(ReferenceDataContext)
  if (!context) {
    throw new Error('useReferenceData måste användas inom en ReferenceDataProvider')
  }
  return context
}
