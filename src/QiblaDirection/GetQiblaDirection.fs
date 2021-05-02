module GetQiblaDirection
open CommonTypes
open DomainApi

let getQiblaDirection: GetQiblaDirection =
    fun geoCoordinates ->
        
        let cosineOfLat = 
            Latitude.value geoCoordinates.latitude 
            |> Radians.convert 
            |> Radians.value 
            |> cos

        let tangentOfLat = 
            Latitude.value Mecca.Kaaba.latitude 
            |> Radians.convert 
            |> Radians.value 
            |> tan

        let sineofLat = 
            Latitude.value geoCoordinates.latitude 
            |> Radians.convert 
            |> Radians.value 
            |> sin

        let cosineOfLon = 
            Longitude.subtract Mecca.Kaaba.longitude geoCoordinates.longitude 
            |> Radians.value 
            |> cos
        
        let top = 
            Longitude.subtract Mecca.Kaaba.longitude geoCoordinates.longitude 
            |> Radians.value |> sin

        let bottom = cosineOfLat * tangentOfLat - sineofLat * cosineOfLon
    
        let qibla = atan2 top bottom
        
        let degrees = qibla |> Degrees.convert
        
        { trueNorth = degrees }
