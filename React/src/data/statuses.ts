import { Status } from '@/types'

// fallback-data
export const statuses: Status[] = [
  {
    id: 1,
    name: 'Ej påbörjad',
    type: 'Project',
    description: 'Projektet har inte startats än',
    sortOrder: 1,
    color: '#808080'
  },
  {
    id: 2,
    name: 'Pågående',
    type: 'Project',
    description: 'Projektet är aktivt',
    sortOrder: 2,
    color: '#0000FF'
  },
  {
    id: 3,
    name: 'Pausad',
    type: 'Project',
    description: 'Projektet är tillfälligt pausat',
    sortOrder: 3,
    color: '#FFA500'
  },
  {
    id: 4,
    name: 'Avslutad',
    type: 'Project',
    description: 'Projektet är färdigt',
    sortOrder: 4,
    color: '#008000'
  },
  {
    id: 5,
    name: 'Avbruten',
    type: 'Project',
    description: 'Projektet har avbrutits',
    sortOrder: 5,
    color: '#FF0000'
  }
]
