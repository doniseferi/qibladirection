namespace DomainApi
open CommonTypes

type GeoCoordinatesValidator = UnvalidatedGeoCoordinates -> Result<GeoCoordinates, ErrorInformation>

type GetQiblaDirection = GeoCoordinates -> QiblaDirection 

type QiblaDirectionQueryHandler = GetQiblaDirection -> GeoCoordinatesValidator -> UnvalidatedGeoCoordinates -> Result<QiblaDirection, QiblaError>