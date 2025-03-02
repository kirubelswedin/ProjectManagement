import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Layout from '@/components/layout/Layout'
import { HomePage, ProjectPage, ProjectsPage } from '@/pages'
import '@/styles/mediaqueries.css'
import '@/App.css'

function App() {
  return (
    <BrowserRouter>
      <Layout className="main-content">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/projects" element={<ProjectsPage />} />
          <Route path="/projects/create" element={<ProjectPage />} />
          <Route path="/projects/:id" element={<ProjectPage />} />
        </Routes>
      </Layout>
    </BrowserRouter>
  )
}

export default App
