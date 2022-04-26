module QiblaDirection.GetQiblaDirection

open QiblaDirection.CommonTypes
open QiblaDirection.DomainApi

let getQiblaDirection: GetQiblaDirection =
    fun geoCoordinates ->
        
        let cosineOfLat = 
            Latitude.value geoCoordinates.latitude 
            |> Radians.fromDegrees
            |> Radians.value 
            |> cos

        let tangentOfLat = 
            Latitude.value Mecca.Kaaba.latitude 
            |> Radians.fromDegrees
            |> Radians.value 
            |> tan

        let sineOfLat = 
            Latitude.value geoCoordinates.latitude 
            |> Radians.fromDegrees
            |> Radians.value 
            |> sin

        let cosineOfLon = 
            Longitude.subtract Mecca.Kaaba.longitude geoCoordinates.longitude 
            |> Radians.value 
            |> cos
        
        let x = 
            Longitude.subtract Mecca.Kaaba.longitude geoCoordinates.longitude 
            |> Radians.value 
            |> sin

        let y = cosineOfLat * tangentOfLat - sineOfLat * cosineOfLon
        
        atan2 x y
            |> Degrees.fromRadians
            |> QiblaDirection.create