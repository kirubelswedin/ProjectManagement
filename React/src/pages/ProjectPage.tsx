import { FC, useEffect, useState } from 'react'
import { Project } from '@/types'
import { useLocation, useNavigate, useParams } from 'react-router-dom'
import { ProjectForm } from '@/components/project'
import { Button } from '@/components/common'
import { useProjects, useForm } from '@/contexts'
import '@/pages/ProjectPage.css'

export const ProjectPage: FC = () => {
  const { id } = useParams<{ id: string }>()
  const navigate = useNavigate()
  const location = useLocation()
  const isCreateMode = location.pathname === '/projects/create'

  const { selectedProject, loading, error, fetchProject, addProject, editProject } = useProjects()

  const { resetForm } = useForm()

  const [isSubmitting, setIsSubmitting] = useState(false)
  const [formError, setFormError] = useState<string | null>(null)

  useEffect(() => {
    if (!isCreateMode && id) {
      fetchProject(parseInt(id))
    } else {
      // reset form when creating a new project
      resetForm()
    }
  }, [isCreateMode, id, fetchProject, resetForm])

  const handleSubmit = async (formData: Partial<Project>) => {
    try {
      setIsSubmitting(true)
      setFormError(null)

      // console.log('Submitting form data:', formData)

      if (isCreateMode) {
        const result = await addProject(formData as Omit<Project, 'id' | 'projectNumber'>)
        if (result.success) {
          navigate('/projects')
        }
      } else if (id) {
        const result = await editProject(parseInt(id), formData)
        if (result.success) {
          navigate('/projects')
        }
      }
    } catch {
      // console.error('Error submitting form:', err)

      setTimeout(() => {
        navigate('/projects', { replace: true })
      }, 3000)
    } finally {
      setIsSubmitting(false)
    }
  }

  const handleCancel = () => {
    navigate('/projects')
  }

  const pageTitle = isCreateMode
    ? 'Projekt - Skapa Nytt'
    : `Projekt ${selectedProject?.projectNumber} - ${selectedProject?.projectName || ''}`

  const isLoading = loading && !isCreateMode

  return (
    <div className="project-page">
      <div className="project-page-header">
        <h1>{pageTitle}</h1>
        <div className="header-actions">
          <Button variant="inverted" onClick={handleCancel} className="show-list">
            Visa lista
          </Button>
          {!isCreateMode && (
            <Button
              variant="primary"
              className="create-new"
              onClick={() => navigate('/projects/create')}
            >
              Skapa nytt
            </Button>
          )}
        </div>
      </div>

      {error && <div className="error-message">{error}</div>}
      {formError && <div className="error-message">{formError}</div>}

      {isLoading ? (
        <div className="loading-container">
          <p>Laddar projekt...</p>
        </div>
      ) : (
        <ProjectForm
          onSubmit={handleSubmit}
          onCancel={handleCancel}
          isLoading={isSubmitting}
          mode={isCreateMode ? 'create' : 'edit'}
        />
      )}
    </div>
  )
}
