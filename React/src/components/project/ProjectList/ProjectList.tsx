import React, { ChangeEvent, useState } from 'react'
import { Link } from 'react-router-dom'
import { Project } from '@/types'
import { ProjectListItem } from '@/components/project/ProjectList/ProjectListItem'
import '@/components/project/ProjectList/ProjectList.css'

interface ProjectListProps {
  projects: Project[]
  loading: boolean
}

export const ProjectList: React.FC<ProjectListProps> = ({ projects, loading }) => {
  const [selectedProjects, setSelectedProjects] = useState<number[]>([])

  if (loading) {
    return (
      <div className="project-list-loading">
        <p>Laddar projekt...</p>
      </div>
    )
  }

  if (!projects || projects.length === 0) {
    return (
      <div className="project-list-empty">
        <p>Inga projekt hittades</p>
        <Link to="/projects/create" className="button button-primary">
          Skapa nytt projekt
        </Link>
      </div>
    )
  }

  const toggleSelectAll = (e: ChangeEvent<HTMLInputElement>) => {
    if (e.target.checked) {
      setSelectedProjects(projects.map((p) => p.id))
    } else {
      setSelectedProjects([])
    }
  }

  const toggleSelectProject = (id: number) => {
    setSelectedProjects((prev) =>
      prev.includes(id) ? prev.filter((projectId) => projectId !== id) : [...prev, id]
    )
  }

  return (
    <div className="project-list-container">
      <table className="project-list-table">
        <thead>
          <tr>
            <th className="checkbox-column">
              <input
                type="checkbox"
                onChange={toggleSelectAll}
                checked={selectedProjects.length === projects.length && projects.length > 0}
              />
            </th>
            <th>Projektnr</th>
            <th>Benämning</th>
            <th>Klient</th>
            <th>Tjänst</th>
            <th>Projektledare</th>
            <th>Start</th>
            <th>Slut</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {projects.map((project) => (
            <ProjectListItem
              key={project.id}
              project={project}
              isSelected={selectedProjects.includes(project.id)}
              onToggleSelect={toggleSelectProject}
            />
          ))}
        </tbody>
      </table>

      {selectedProjects.length > 0 && (
        <div className="selected-projects-info">
          <span>({selectedProjects.length} markerade)</span>
          <button className="unselect-all" onClick={() => setSelectedProjects([])}>
            Avmarkera alla
          </button>
        </div>
      )}
    </div>
  )
}
