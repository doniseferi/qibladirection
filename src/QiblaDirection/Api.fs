    module QiblaDirection.Api

[<Struct>]
type UnvalidatedGeoCoordinates = public {
    lat: float
    lon: float
}

[<Struct>]
type QiblaDirection = public {
    trueNorth: float
}

[<Struct>]
type ErrorInformation = private {
    message: string
    invalidField: string
}

type QiblaDirectionQueryHandler = UnvalidatedGeoCoordinates -> Result<QiblaDirection, ErrorInformation>