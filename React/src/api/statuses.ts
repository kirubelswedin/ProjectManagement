import { Status } from '@/types'
import { fetchApi } from '@/api/core'
import { statuses } from '@/data/statuses'

export const getStatuses = (): Promise<Status[]> => {
  return fetchApi<Status[]>('/Status').catch(() => Promise.resolve(statuses))
}
