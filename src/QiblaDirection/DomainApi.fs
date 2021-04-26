module GetQiblaDirectionQueryHandler
open CommonTypes

type QiblaError = QiblaError of ErrorInformation

type QiblaDirectionService = GeoCoordinates -> QiblaDirection

type GeoCoordinatesService = UnvalidatedGeoCoordinates -> Result<GeoCoordinates, ErrorInformation>

let handle (qiblaDirectionService: QiblaDirectionService) (createGeoCoordinates:GeoCoordinatesService) (unvalidatedGeoCoordinates:UnvalidatedGeoCoordinates) =
    match createGeoCoordinates unvalidatedGeoCoordinates with
    | Ok geo -> Ok (qiblaDirectionService geo)
    | Error e -> Error (QiblaError { invalidField = e.invalidField; message = e.message })