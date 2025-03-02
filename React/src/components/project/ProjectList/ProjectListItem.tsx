import { FC } from 'react'
import { Link } from 'react-router-dom'
import { Project } from '@/types'
import { formatDate } from '@/utils'
import '@/components/project/ProjectList/ProjectListItem.css'

interface ProjectListItemProps {
  project: Project
  isSelected: boolean
  onToggleSelect: (id: number) => void
}

export const ProjectListItem: FC<ProjectListItemProps> = ({
  project,
  isSelected,
  onToggleSelect
}) => {
  const rowClass = `project-row ${isSelected ? 'selected-row' : ''}`

  // Convert status name to CSS class
  const statusClass = `status-${project.status.name.toLowerCase().replace(/\s+/g, '-')}`

  return (
    <tr key={project.id} className={rowClass}>
      <td className="checkbox-column">
        <input type="checkbox" checked={isSelected} onChange={() => onToggleSelect(project.id)} />
      </td>
      <td>
        <Link to={`/projects/${project.id}`} className="project-link">
          {project.projectNumber}
        </Link>
      </td>
      <td>
        <Link to={`/projects/${project.id}`} className="project-link">
          {project.projectName}
        </Link>
      </td>
      <td>{project.client ? project.client.name : '-'}</td>
      <td>{project.serviceType ? project.serviceType.name : '-'}</td>
      <td>
        {project.projectManager
          ? `${project.projectManager.firstName} ${project.projectManager.lastName}`
          : '-'}
      </td>
      <td>{formatDate(project.startDate)}</td>
      <td>{formatDate(project.endDate)}</td>
      <td>
        <span className={`status-badge ${statusClass}`}>{project.status.name}</span>
      </td>
    </tr>
  )
}
