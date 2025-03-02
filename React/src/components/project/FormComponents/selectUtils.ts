import { Status, Client, ProjectManager, ServiceType } from '@/types'

// used in SelectField
export type SelectOptionType = Status | Client | ProjectManager | ServiceType

export interface HasId {
  id: number
}

// type checking
export const isProjectManager = (option: SelectOptionType): option is ProjectManager =>
  'firstName' in option && 'lastName' in option && 'email' in option

export const hasName = (option: SelectOptionType): option is Status | Client | ServiceType =>
  'name' in option

export const isServiceType = (option: SelectOptionType): option is ServiceType =>
  'name' in option && 'defaultHourlyRate' in option

export const isStatus = (option: SelectOptionType): option is Status =>
  'name' in option && 'type' in option && 'color' in option
