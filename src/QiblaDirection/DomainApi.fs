namespace DomainApi
open CommonTypes

[<Struct>]
type QiblaError = QiblaError of ErrorInformation

[<Struct>]
type UnvalidatedGeoCoordinates = public {
    lat: float
    lon: float
}

type GeoCoordinatesValidator = UnvalidatedGeoCoordinates -> Result<GeoCoordinates, ErrorInformation>

type GetQiblaDirection = GeoCoordinates -> QiblaDirection 

type QiblaDirectionQueryHandler = GetQiblaDirection -> GeoCoordinatesValidator -> UnvalidatedGeoCoordinates -> Result<QiblaDirection, QiblaError>