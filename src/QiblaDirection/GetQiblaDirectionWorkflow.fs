module GetQiblaDirectionWorkflow
open CommonTypes
open DomainApi
open System
open GeoCoordinatesService

//atan2 
// top (sin (Qibla Longitude -  Longitude), 
// bottom = cos Latitude * tan Meccaa Latitude - Sin latitude * cos (Qibla longitude - longitude)

let qiblaDirection geoCoordinates =
    let top = Longitude.subtract Mecca.Kaaba.longitude geoCoordinates.longitude |> Radians.value |> sin
    let cosineOfLat = Latitude.value geoCoordinates.latitude |> Radians.convert |> Radians.value |> cos
    let tangentOfLat = Latitude.value Mecca.Kaaba.latitude |> Radians.convert |> Radians.value |> tan
    let sineofLat = Latitude.value geoCoordinates.latitude |> Radians.convert |> Radians.value |> sin
    let cosineOfLon = Longitude.subtract Mecca.Kaaba.longitude geoCoordinates.longitude |> Radians.value |> cos
    let bottom = cosineOfLat * tangentOfLat - sineofLat * cosineOfLon
    let qibla = atan2 top bottom
    let degrees = qibla |> Degrees.convert
    { trueNorth = degrees; magneticNorth = degrees }


