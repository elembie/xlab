import { configureStore } from '@reduxjs/toolkit';
import { getVenueSearchResults } from './api';

// actions (in one file for simplicity)
const VENUE_FETCHING_SEARCH = 'VENUE_FETCHING_SEARCH'
const VENUE_FETCHED_SEARCH = 'VENUE_FETCHED_SEARCH'
const VENUE_CLEAR_RESULTS = 'VENUE_CLEAR_RESULTS'

export const venueFetchingSearch = () => ({
  type: VENUE_FETCHING_SEARCH
})

export const venueFetchedSearch = results => ({
  type: VENUE_FETCHED_SEARCH,
  results,
})

export const venueClearResults = () => ({
  type: VENUE_CLEAR_RESULTS,
})

export const venueSearch = (query, lat = null, lng = null) => {
  return (dispatch) => {
    dispatch(venueFetchingSearch())
    getVenueSearchResults(query, lat, lng)
      .then(result => result.json())
      .then(data => dispatch(venueFetchedSearch(data)))
  }
}

// reducer (in one file for simplicity)
const initialState = {
  venueSearch: {
    isSearching: false,
    results: [],
  },
}

const venueReducer = (state = initialState, action) => {
  switch (action.type) {

      case VENUE_FETCHING_SEARCH: 
        return {
          ...state,
          venueSearch: {
            isSearching: true,
          }
        }

      case VENUE_FETCHED_SEARCH:
        return {
          ...state,
          venueSearch: {
            isSearching: false,
            results: action.results,
          }
        }

      case VENUE_CLEAR_RESULTS:
        return {
          ...state,
          venueSearch: {
            isSearching: false,
            results: [],
          }
        }

      default:
        return state

  }
}

export const store = configureStore({
  reducer: {
    venue: venueReducer,
  },
});
