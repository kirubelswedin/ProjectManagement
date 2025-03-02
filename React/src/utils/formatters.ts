// Format number,"1 234 567 kr"
export const formatCurrency = (amount: number, includeCurrency = true): string => {
  const formatted = new Intl.NumberFormat('sv-SE', {
    style: includeCurrency ? 'currency' : 'decimal',
    currency: 'SEK',
    minimumFractionDigits: 0,
    maximumFractionDigits: 0
  }).format(amount)

  return formatted
}

// Format date (YYYY-MM-DD)
export const formatDate = (dateString: string | null | undefined): string => {
  if (!dateString) return '-'

  try {
    const date = new Date(dateString)
    return date.toLocaleDateString('sv-SE', {
      day: '2-digit',
      month: '2-digit',
      year: 'numeric'
    })
  } catch (error) {
    console.error('Error formatting date:', error)
    return '-'
  }
}
