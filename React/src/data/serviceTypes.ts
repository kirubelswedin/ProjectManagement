import { ServiceType } from '@/types'

// Fallback data
export const serviceTypes: ServiceType[] = [
  {
    id: 1,
    name: 'Systemutveckling',
    description: 'Skräddarsydd systemutveckling för verksamhetens behov',
    defaultHourlyRate: 1300
  },
  {
    id: 2,
    name: 'Webbutveckling',
    description: 'Frontend och backend utveckling av webbplatser och -applikationer',
    defaultHourlyRate: 1200
  },
  {
    id: 3,
    name: 'Förvaltning',
    description: 'Löpande underhåll och förvaltning av system och webbplatser',
    defaultHourlyRate: 900
  },
  {
    id: 4,
    name: 'Projektledning',
    description: 'Ledning och koordinering av digitala projekt',
    defaultHourlyRate: 1600
  },
  {
    id: 5,
    name: 'Kommunikation',
    description: 'Strategi och produktion av digital kommunikation',
    defaultHourlyRate: 1100
  },
  {
    id: 6,
    name: 'Digital marknadsföring',
    description: 'SEO, SEM och andra digitala marknadsföringstjänster',
    defaultHourlyRate: 1200
  }
]
