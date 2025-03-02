import { useState } from 'react'
import { BankIDIcon } from '@/components/icons/iconsSVG'
import { Button } from '@/components/common'
import '@/components/layout/SigninPanel.css'

interface SigninPanelProps {
  isOpen: boolean
  onClose: () => void
}

export const SigninPanel = ({ isOpen, onClose }: SigninPanelProps) => {
  const [email, setEmail] = useState('')

  return (
    <div className={`signin-panel ${isOpen ? 'open' : ''}`}>
      <div className="signin-panel-content">
        <button className="close-button" onClick={onClose}>
          ✕
        </button>

        <h2>Sign in</h2>

        <Button variant="primary" className="bankid">
          <BankIDIcon />
          Mobile BankID
        </Button>
        <Button variant="secondary" className="device">
          BankID on this device
        </Button>

        <div className="divider">
          <span>OR</span>
        </div>
        {/* 
				<span>Use your XONTROF ID</span> */}
        <input
          type="email"
          placeholder="Personal identity number or email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />

        <Button variant="primary" className="next">
          Next
        </Button>
      </div>
    </div>
  )
}
