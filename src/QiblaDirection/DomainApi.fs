namespace DomainApi
open CommonTypes

type UnvalidatedGeoCoordinates = {
    lat: decimal
    lon: decimal
}

type Error = {
    invalidField: string
    message: string
}

type QiblaError = QiblaError of Error

type GeoCoordinatesService = UnvalidatedGeoCoordinates -> Result<GeoCoordinates, Error>

type GetQiblaDirectionQueryHandler = UnvalidatedGeoCoordinates -> GeoCoordinatesService -> Result<QiblaDirection, QiblaError>