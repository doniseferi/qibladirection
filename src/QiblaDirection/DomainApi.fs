namespace DomainApi
open CommonTypes
open QiblaDirectionService

type QiblaError = QiblaError of ErrorInformation

type GeoCoordinatesService = UnvalidatedGeoCoordinates -> Result<GeoCoordinates, ErrorInformation>

type GetQiblaDirectionQueryHandler = QiblaDirectionService -> GeoCoordinatesService -> UnvalidatedGeoCoordinates -> Result<QiblaDirection, QiblaError>

module GetQiblaDirectionQueryHandler
    let handle getQiblaDirectionQueryHandler createGeoCoordinates unvalidatedGeoCoordinates =
        match geoCoordinatesService unvalidatedGeoCoordinates with
        | Error err -> QiblaError { invalidField = err.invalidField; message = err.message}
        |  Ok geoCoordinates -> qiblaDirection geoCoordinates