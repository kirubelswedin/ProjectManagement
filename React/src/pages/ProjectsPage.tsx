import { useState, useEffect, FC, useMemo, ChangeEvent } from 'react'
import { Link } from 'react-router-dom'
import { ProjectList, StatusFilter } from '@/components/project'
import { SearchBar } from '@/components/common/SearchBar'
import { Button } from '@/components/common'
import { useProjects } from '@/contexts'
import '@/pages/ProjectsPage.css'

export const ProjectsPage: FC = () => {
  const { projects, loading, error, fetchProjects } = useProjects()
  const [activeStatus, setActiveStatus] = useState('all')
  const [searchQuery, setSearchQuery] = useState('')

  useEffect(() => {
    fetchProjects()
  }, [fetchProjects])

  const filteredProjects = useMemo(() => {
    let filtered = [...projects]

    // Filter by status
    if (activeStatus !== 'all') {
      filtered = filtered.filter((project) => {
        switch (activeStatus) {
          case 'not-started':
            return project.status.name === 'Ej påbörjad'
          case 'in-progress':
            return project.status.name === 'Pågående'
          case 'paused':
            return project.status.name === 'Pausad'
          case 'completed':
            return project.status.name === 'Avslutad'
          case 'cancelled':
            return project.status.name === 'Avbruten'
          default:
            return true
        }
      })
    }

    // Took help from gpt to implement this filter by search query
    if (searchQuery) {
      const query = searchQuery.toLowerCase()
      filtered = filtered.filter(
        (project) =>
          project.projectNumber.toString().toLowerCase().includes(query) ||
          project.projectName.toLowerCase().includes(query) ||
          (project.projectManager &&
            `${project.projectManager.firstName} ${project.projectManager.lastName}`
              .toLowerCase()
              .includes(query)) ||
          (project.client && project.client.name.toLowerCase().includes(query)) ||
          project.status.name.toLowerCase().includes(query) ||
          project.serviceType.name.toLowerCase().includes(query)
      )
    }

    return filtered
  }, [projects, activeStatus, searchQuery])

  const handleStatusChange = (status: string) => {
    setActiveStatus(status)
  }

  const handleSearch = (e: ChangeEvent<HTMLInputElement>) => {
    setSearchQuery(e.target.value)
  }

  const handleSearchSubmit = () => {}

  return (
    <div className="projects-page">
      <div className="projects-header">
        <h1>Projekt - Översikt</h1>
        <Link to="/projects/create" className="create-project-link">
          <Button variant="primary" className="create-new">
            Skapa nytt
          </Button>
        </Link>
      </div>

      <div className="projects-toolbar">
        <div className="search-bar">
          <SearchBar
            value={searchQuery}
            onChange={handleSearch}
            onSearch={handleSearchSubmit}
            placeholder="Projektnamn, Projektnr, Projektledare..."
          />
        </div>
        <StatusFilter activeStatus={activeStatus} onStatusChange={handleStatusChange} />
      </div>

      {error && <div className="error-message">{error}</div>}

      <ProjectList projects={filteredProjects} loading={loading} />
    </div>
  )
}
