module QiblaDirection.GetQiblaDirectionHandler

open QiblaDirection.CommonTypes

let getQiblaDirection' = GetQiblaDirection.getQiblaDirection

let qiblaDirectionQueryHandler' =
    fun unvalidatedGeoCoordinates ->
        unvalidatedGeoCoordinates
        |> GeoCoordinatesValidator.geoCoordinatesValidator
        |> Result.map getQiblaDirection' 
