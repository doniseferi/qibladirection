namespace DomainApi
open CommonTypes
open QiblaDirection

type UnvalidatedGeoCoordinates = {
    lat: float
    lon: float
}

type Error = {
    invalidField: string
    message: string
}

type QiblaError = QiblaError of Error

type GeoCoordinatesService = UnvalidatedGeoCoordinates -> Result<GeoCoordinates, Error>

type GetQiblaDirectionQueryHandler = UnvalidatedGeoCoordinates -> GeoCoordinatesService -> Result<QiblaDirection, QiblaError>

module GetQiblaDirectionQueryHandler
    let handle qiblaDirection createGeoCoordinates unvalidateGeoCoordinates =
        let geoCoordinates = createGeoCoordinates unvalidateGeoCoordinates
            match geoCoordinates with
            | Error -> QiblaError { invalidField = "a"; message = "abc" }
            | GeoCoordinates value -> qiblaDirection value