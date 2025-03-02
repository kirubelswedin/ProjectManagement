export const API_URL = import.meta.env.VITE_API_URL || 'http://localhost:5092/api'

export async function fetchApi<T>(endpoint: string, options?: RequestInit): Promise<T> {
  const url = `${API_URL}${endpoint}`

  try {
    const response = await fetch(url, {
      headers: { 'Content-Type': 'application/json', ...(options?.headers || {}) },
      ...options
    })

    if (!response.ok) throw new Error(`API error: ${response.status}`)

    const contentType = response.headers.get('content-type')

    return contentType?.includes('application/json')
      ? await response.json()
      : ((await response.text()) as unknown as T)
  } catch (error) {
    console.error(`Error: ${url}`, error)
    throw error
  }
}
