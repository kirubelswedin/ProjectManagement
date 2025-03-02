import { ChangeEvent, FC, useState, useEffect } from 'react'
import { FormData } from '@/contexts'

interface BudgetFieldProps {
  formData: FormData
  onChange: (e: ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>) => void
}

export const BudgetField: FC<BudgetFieldProps> = ({ formData, onChange }) => {
  const [formattedBudget, setFormattedBudget] = useState('')

  useEffect(() => {
    if (formData.budget) {
      setFormattedBudget(new Intl.NumberFormat('sv-SE').format(Number(formData.budget)))
    } else {
      setFormattedBudget('')
    }
  }, [formData.budget])

  const handleBudgetChange = (e: ChangeEvent<HTMLInputElement>) => {
    const rawValue = e.target.value.replace(/\D/g, '')
    const limitedValue = rawValue.slice(0, 7)

    onChange({
      ...e,
      target: { ...e.target, name: 'budget', value: limitedValue }
    } as ChangeEvent<HTMLInputElement>)
  }

  return (
    <div className="form-group">
      <label htmlFor="budget">Budget (SEK)</label>
      <input
        type="text"
        id="budget"
        name="budget"
        value={formattedBudget}
        onChange={handleBudgetChange}
        placeholder="0"
      />
    </div>
  )
}
