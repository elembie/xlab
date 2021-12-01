const urlBase = process.env.REACT_APP_API_BASE

export const getVenueSearchResults = (query, lat = null, long = null) => {

    const searchParams = new URLSearchParams()
    searchParams.set('query', query)
    console.log(lat, long)
    if (lat && long) {
        searchParams.set('lat', lat)
        searchParams.set('lng', long) 
    }
    return fetch(`/api/venues/search?${searchParams.toString()}`)

}