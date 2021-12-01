import { React } from 'react'
import styles from './VenueResult.module.scss'

const VenueResult = ({ 
    id, 
    name, 
    excerpt,
    twitter, 
    starsBeer, 
    starsAtmosphere, 
    starsAmenities,
    starsValue,
    distanceTo
}) => {
    return (
        <div className={styles.base}>
            <div>{name} | {`@${twitter}`}</div>
            <div>Beer: {starsBeer}, atmosphere: {starsAtmosphere}, amenities: {starsAmenities}, value: {starsValue}</div>
            <div>{excerpt}</div>
            {distanceTo && <div>{`${Math.round(distanceTo/1000)}km`}</div>}
        </div>
    )
}

export default VenueResult