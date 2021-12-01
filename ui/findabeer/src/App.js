import { Autocomplete, TextField } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import './App.css';
import VenueResult from './app/components/VenueResult';
import { venueClearResults, venueSearch } from './app/store';

function App() {

  const dispatch = useDispatch()
  const [timeoutId, setTimeoutId] = useState(null)
  const results = useSelector(state => state.venue.venueSearch.results) || []

  const [userLocation, setUserLocation] = useState(null)
  useEffect(() => {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(location => setUserLocation({
        lat: location.coords.latitude,
        long: location.coords.longitude,
      }))
    }
  }, setUserLocation)

  const handleSearch = query => {
    if (query.length >= 3) {
      clearTimeout(timeoutId)
      setTimeoutId(
        setTimeout(() => dispatch(venueSearch(query, userLocation.lat, userLocation.long)), 700)
      )
    } else {
      dispatch(venueClearResults())
      clearTimeout(timeoutId)
    }
  }

  return (
    <div className="App">
      <h1>Find-A-Beer</h1>
      <TextField 
        id="find-a-beer-search" 
        label="Search by name, postcode or tags" 
        variant="outlined"
        onChange={event => handleSearch(event.target.value)}
      />

      <div>
        {results.map(r => <VenueResult key={r.id} {...r} />)}
      </div>
    </div>
  );
}

export default App;
