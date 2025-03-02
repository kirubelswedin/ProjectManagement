import { Client } from '@/types'
import { fetchApi } from './core'
import { clients } from '@/data/clients'

export const getClients = (): Promise<Client[]> => {
  return fetchApi<Client[]>('/Clients').catch(() => Promise.resolve(clients))
}
