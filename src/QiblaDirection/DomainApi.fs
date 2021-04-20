module DomainApi
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

type GetQiblaQueryHandler = UnvalidatedGeoCoordinates -> GeoCoordinatesService -> Result<QiblaInformation, QiblaError>

module GeoCoordinatesService =
    let createGeoCoordinates unvalidatedGeoCoordinates =
        match Latitude.create unvalidatedGeoCoordinates.lat, Longitude.create unvalidatedGeoCoordinates.lon with
        | (Some lat, Some lon) -> Ok { latitude = lat; longitude = lon}
        | (None, Some lon) -> Error { invalidField= "latitude"; message = "l" }
        | (Some lat, None) -> Error { invalidField= "longitude"; message = "l" }
        | (None, None) -> Error { invalidField= "latitude;longitude"; message = "l" }