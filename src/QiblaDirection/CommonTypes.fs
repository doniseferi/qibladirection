module CommonTypes

[<Struct>]
type Latitude = private Latitude of  decimal

[<Struct>]
type Longitude = private Longitude of decimal

[<Struct>]
type GeoCoordinates = { latitude: Latitude; longitude: Longitude }

[<Struct>]
type Degrees = private Degrees of decimal

[<Struct>]
type QiblaInformation = public {
    trueNorth: Degrees
    magneticNorth: Degrees
}

type QiblaInformationQueryHandler = GeoCoordinates -> QiblaInformation

module QiblaInformation =
    let create trueNorth magneticNorth = { trueNorth = trueNorth; magneticNorth = magneticNorth }

module ConstainedTypes =
    let (|LessThan|_|) k value = if value < k then Some() else None
    let (|GreaterThan|_|) k value = if value > k then Some() else None

module Degrees = 
    open ConstainedTypes
    let value (Degrees deg) = deg
    let create degrees =
        match degrees with
        | GreaterThan 360m -> None
        | LessThan 0m -> None
        | _ -> Some (Degrees degrees)

module Latitude =
    open ConstainedTypes
    let value (Latitude lat) = lat

    let create latitude =
        match latitude with
        | GreaterThan 90m -> None
        | LessThan -90m -> None
        | _ -> Some (Latitude latitude)

module Longitude =
    open ConstainedTypes    
    let create longitude =
        match longitude with
        | GreaterThan 180.0m -> None
        | LessThan -180.0m -> None
        | _ -> Some (Longitude longitude)


module Mecca =    
    let Kaaba = { latitude = Latitude 21.422487m; longitude  = Longitude 39.826206m }