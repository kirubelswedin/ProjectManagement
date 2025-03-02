import { FC, useState } from 'react'
import { NavLink } from 'react-router-dom'
import { RiSearchLine } from 'react-icons/ri'
import { SigninPanel } from '@/components/layout'
import { Button, SearchBar } from '@/components/common'
import '@/components/layout/Header.css'

interface HeaderProps {
  isLoginOpen: boolean
  setIsLoginOpen: (isOpen: boolean) => void
}

export const Header: FC<HeaderProps> = ({ isLoginOpen, setIsLoginOpen }) => {
  const [searchTerm, setSearchTerm] = useState('')

  return (
    <>
      <header className="header">
        <nav className="nav">
          <div className="nav-left">
            <NavLink to="/" className="logo">
              <span>XONTROF</span>
            </NavLink>
          </div>

          <div className="nav-middle">
            <SearchBar
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              placeholder="..."
              icon={<RiSearchLine size={20} color="#898a9b" />}
            />
          </div>

          <div className="nav-right">
            <Button
              variant="inverted"
              className="contact"
              onClick={() => {
                const contactSection = document.getElementById('contact')
                contactSection?.scrollIntoView({ behavior: 'smooth' })
              }}
            >
              Kontakt
            </Button>
            <Button variant="primary" className="signin" onClick={() => setIsLoginOpen(true)}>
              Logga in
            </Button>
          </div>
        </nav>
      </header>

      <SigninPanel isOpen={isLoginOpen} onClose={() => setIsLoginOpen(false)} />
    </>
  )
}
