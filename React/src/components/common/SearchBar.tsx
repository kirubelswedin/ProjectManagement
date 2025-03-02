import { ChangeEvent, FC, KeyboardEvent, ReactNode } from 'react'
import '@/components/common/SearchBar.css'

interface SearchBarProps {
  value?: string
  onChange?: (e: ChangeEvent<HTMLInputElement>) => void
  placeholder?: string
  icon?: ReactNode
  onSearch?: () => void
  className?: string
  inputClassName?: string
  buttonClassName?: string
}

export const SearchBar: FC<SearchBarProps> = ({
  value = '',
  onChange,
  placeholder = '...',
  icon,
  onSearch,
  className = '',
  inputClassName = '',
  buttonClassName = ''
}) => {
  const handleKeyDown = (e: KeyboardEvent<HTMLInputElement>) => {
    if (e.key === 'Enter' && onSearch) {
      e.preventDefault()
      onSearch()
    }
  }

  return (
    <div className={`search-bar ${className}`}>
      <input
        type="text"
        placeholder={placeholder}
        value={value}
        onChange={onChange}
        onKeyDown={handleKeyDown}
        className={`search-input ${inputClassName}`}
      />
      {(icon || onSearch) && (
        <button className={`search-icon ${buttonClassName}`} onClick={onSearch} type="button">
          {icon}
        </button>
      )}
    </div>
  )
}
