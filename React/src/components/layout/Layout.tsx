import { ReactNode, useState } from 'react'
import { Header, Footer, SigninPanel } from '@/components/layout'
import '@/components/layout/Layout.css'

interface LayoutProps {
  children: ReactNode
  className?: string
}

function LayoutContent({ children, className }: LayoutProps) {
  const [isLoginOpen, setIsLoginOpen] = useState(false)

  return (
    <>
      <div // Overlay login panel
        className={`signin-overlay ${isLoginOpen ? 'open' : ''}`}
        onClick={() => setIsLoginOpen(false)}
      />

      <div className="layout">
        <Header isLoginOpen={isLoginOpen} setIsLoginOpen={setIsLoginOpen} />
        <main className={className}>{children}</main>
        <Footer />
        <SigninPanel isOpen={isLoginOpen} onClose={() => setIsLoginOpen(false)} />
      </div>
    </>
  )
}

export default function Layout(props: LayoutProps) {
  return <LayoutContent {...props} />
}
