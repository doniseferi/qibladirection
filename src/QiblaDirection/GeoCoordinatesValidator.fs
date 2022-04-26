module QiblaDirection.GeoCoordinatesValidator

open QiblaDirection.CommonTypes
open QiblaDirection.DomainApi

let latitudeError = { invalidField = "latitude"; message = "Please provide a latitude value between -90 to 90" }
let longitudeError = { invalidField = "longitude"; message = "Please provide a longitude value between -180 to 180" }

let geoCoordinatesValidator: GeoCoordinatesValidator =
 fun unvalidatedGeoCoordinates ->
    match Latitude.create unvalidatedGeoCoordinates.lat, Longitude.create unvalidatedGeoCoordinates.lon with
    | Some lat, Some lon -> Ok { latitude = lat; longitude = lon }
    | Some _lat, None -> Error [ longitudeError ]
    | None, Some _lon -> Error [ latitudeError ]
    | None, None -> Error [
            latitudeError
            longitudeError
        ]          