module GetQiblaDirectionHandler
open DomainApi
open CommonTypes

let qiblaDirectionQueryHandler: QiblaDirectionQueryHandler =
    fun getQiblaDirection geoCoordinatesValidator unvalidatedGeoCoordinates ->
       match geoCoordinatesValidator unvalidatedGeoCoordinates with
       | Ok geo -> 
            geo
            |> getQiblaDirection 
            |> Ok
       | Error err -> 
            QiblaError { invalidField = err.invalidField; message = err.message } 
            |> Error

let qiblaDirectionQueryHandler' =
    let getQiblaDirection' = GetQiblaDirection.getQiblaDirection
    let geoCoordinatesValidator' = GeoCoordinatesValidator.geoCoordinatesValidator
    fun unvalidatedGeoCoordinates ->
        qiblaDirectionQueryHandler getQiblaDirection' geoCoordinatesValidator' unvalidatedGeoCoordinates