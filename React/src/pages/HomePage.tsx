import { useNavigate } from 'react-router-dom'
import { StatCard, StatsGrid, SectionHeader } from '@/components/elements'
import { RiAddLine, RiUserLine, RiTeamLine } from 'react-icons/ri'
import { LuGrip } from 'react-icons/lu'
import { useProjects } from '@/contexts'
import '@/pages/HomePage.css'

export const HomePage = () => {
  const navigate = useNavigate()
  const { projects, loading } = useProjects()

  const projectStats = {
    total: projects.length,
    notStarted: projects.filter((p) => p.status?.name === 'Ej påbörjad').length,
    inProgress: projects.filter((p) => p.status?.name === 'Pågående').length,
    paused: projects.filter((p) => p.status?.name === 'Pausad').length,
    completed: projects.filter((p) => p.status?.name === 'Avslutad').length,
    cancelled: projects.filter((p) => p.status?.name === 'Avbruten').length
  }

  return (
    <div className="home-page">
      <div className="welcome-section">
        <h1>Välkommen till XONTROF</h1>
        <p>Hantera dina projekt enkelt och effektivt</p>
      </div>

      <SectionHeader title="Snabbåtgärder" subtitle="Välj en åtgärd för att komma igång" />
      <div className="quick-actions">
        <button className="action-button" onClick={() => navigate('/projects')}>
          <LuGrip size={24} />
          Visa alla projekt
        </button>
        <button className="action-button" onClick={() => navigate('/projects/create')}>
          <RiAddLine size={24} />
          Skapa nytt projekt
        </button>
        <button className="action-button" onClick={() => navigate('/clients')}>
          <RiUserLine size={24} />
          Hantera kunder
        </button>
        <button className="action-button" onClick={() => navigate('/employees')}>
          <RiTeamLine size={24} />
          Hantera anställda
        </button>
      </div>

      <SectionHeader title="Projektöversikt" subtitle="Status för dina pågående projekt" />

      {loading ? (
        <div className="loading-indicator">Laddar projektdata...</div>
      ) : (
        <StatsGrid columns={4}>
          <StatCard
            value={projectStats.total}
            label="Totalt antal projekt"
            icon={<LuGrip size={24} />}
          />
          <StatCard
            value={projectStats.notStarted}
            label="Ej påbörjade"
            colorClass="status-not-started"
            icon={<LuGrip size={24} />}
          />
          <StatCard
            value={projectStats.inProgress}
            label="Pågående"
            colorClass="status-in-progress"
            icon={<LuGrip size={24} />}
          />
          <StatCard
            value={projectStats.paused}
            label="Pausade"
            colorClass="status-paused"
            icon={<LuGrip size={24} />}
          />
          <StatCard
            value={projectStats.completed}
            label="Avslutade"
            colorClass="status-completed"
            icon={<LuGrip size={24} />}
          />
          <StatCard
            value={projectStats.cancelled}
            label="Avbrutna"
            colorClass="status-cancelled"
            icon={<LuGrip size={24} />}
          />
        </StatsGrid>
      )}
    </div>
  )
}
