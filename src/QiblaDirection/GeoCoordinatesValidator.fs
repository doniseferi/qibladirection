module GeoCoordinatesValidator
open CommonTypes
open DomainApi

let geoCoordinatesValidator: GeoCoordinatesValidator =
 fun unvalidatedGeoCoordinates ->
    match Latitude.create (float unvalidatedGeoCoordinates.lat) with
    | None -> Error { invalidField = "latitude"; message = "Please provide a latitude value between -90 to 90" }
    | Some latitude ->
        match Longitude.create unvalidatedGeoCoordinates.lon with
        | None -> Error { invalidField = "longitude"; message = "Please provide a longitude value between -180 to 180" }
        | Some longitude -> Ok { latitude = latitude; longitude = longitude }