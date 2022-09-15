export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'https://localhost:5001' : ''
export const useSockets = false
export const domain = 'jonmcnamara.us.auth0.com'
export const clientId = 'yCkx457MBqe9B4kW7LJOWhFUgU4LPjIk'
export const audience = 'https://jonmcnamara.us.auth0.com/api/v2/'
