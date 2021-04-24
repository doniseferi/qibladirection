module GeoCoordinatesService
open CommonTypes

let createGeoCoordinates unvalidatedGeoCoordinates =
    match Latitude.create (float unvalidatedGeoCoordinates.lat) with
    | None -> Error { invalidField = "latitude"; message = "l" }
    | Some latitude ->
        match Longitude.create unvalidatedGeoCoordinates.lon with
        | None -> Error { invalidField = "longitude"; message = "l" }
        | Some longitude -> Ok { latitude = latitude; longitude = longitude }