import { ButtonHTMLAttributes, ReactNode } from 'react'
import '@/components/common/Button.css'

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
  children: ReactNode
  variant?: 'primary' | 'secondary' | 'inverted'
  icon?: ReactNode
  // onClick?: () => void;
  className?: string
}

export const Button = ({
  children,
  variant = 'primary',
  icon,
  // onClick,
  className = '',
  ...props
}: ButtonProps) => (
  <button
    // onClick={onClick}
    className={`base-button ${variant}-button ${className}`}
    {...props}
  >
    {icon && <span className="button-icon">{icon}</span>}
    {children}
  </button>
)
