module QiblaDirection.GetQiblaDirection

open QiblaDirection.CommonTypes
open QiblaDirection.DomainApi

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
        
        let x = 
            Longitude.subtract Mecca.Kaaba.longitude geoCoordinates.longitude 
            |> Radians.value 
            |> sin

        let y = cosineOfLat * tangentOfLat - sineofLat * cosineOfLon
        
        atan2 x y
            |> Degrees.convert
            |> QiblaDirection.create