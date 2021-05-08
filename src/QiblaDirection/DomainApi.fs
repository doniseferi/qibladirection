namespace QiblaDirection.DomainApi

open QiblaDirection.CommonTypes

type GeoCoordinatesValidator = UnvalidatedGeoCoordinates -> Result<GeoCoordinates, List<ErrorInformation>>

type GetQiblaDirection = GeoCoordinates -> QiblaDirection 

type QiblaDirectionQueryHandler = GetQiblaDirection -> GeoCoordinatesValidator -> UnvalidatedGeoCoordinates -> Result<QiblaDirection, List<ErrorInformation>>