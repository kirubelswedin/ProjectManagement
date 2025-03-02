import { ServiceType } from '@/types'
import { fetchApi } from './core'
import { serviceTypes } from '@/data/serviceTypes'

export const getServiceTypes = (): Promise<ServiceType[]> => {
  return fetchApi<ServiceType[]>('/ServiceTypes').catch(() => Promise.resolve(serviceTypes))
}
