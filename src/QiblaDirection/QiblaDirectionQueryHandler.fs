module QiblaDirection.GetQiblaDirectionHandler

open QiblaDirection.CommonTypes
open QiblaDirection.DomainApi

let qiblaDirectionQueryHandler: QiblaDirectionQueryHandler =
    fun getQiblaDirection geoCoordinatesValidator unvalidatedGeoCoordinates ->
       match geoCoordinatesValidator unvalidatedGeoCoordinates with
       | Ok geo -> Ok (getQiblaDirection geo)
       | Error err -> Error err

let getQiblaDirection' = GetQiblaDirection.getQiblaDirection
let geoCoordinatesValidator' = GeoCoordinatesValidator.geoCoordinatesValidator

let qiblaDirectionQueryHandler' =
    fun unvalidatedGeoCoordinates ->
        qiblaDirectionQueryHandler getQiblaDirection' geoCoordinatesValidator' unvalidatedGeoCoordinates