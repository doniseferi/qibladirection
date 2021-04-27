module GetQiblaDirectionHandler
open DomainApi
open CommonTypes

let qiblaDirectionQueryHandler: QiblaDirectionQueryHandler =
    fun getQiblaDirection geoCoordinatesValidator unvalidatedGeoCoordinates ->
       match geoCoordinatesValidator unvalidatedGeoCoordinates with
       | Ok geo -> Ok 
                <| (geo 
                |> getQiblaDirection)
       | Error err -> Error 
                    <| QiblaError { invalidField = err.invalidField; message = err.message }