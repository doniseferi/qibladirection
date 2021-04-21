module CommonTypes

[<Struct>]
type Latitude = private Latitude of  decimal with
    static member (-) (Latitude d1, Latitude d2) = Latitude (d1 - d2)

[<Struct>]
type Longitude = private Longitude of decimal with
    static member (-) (Longitude d1, Longitude d2) = Longitude (d1 - d2)

[<Struct>]
type GeoCoordinates = { latitude: Latitude; longitude: Longitude }

[<Struct>]
type Degrees = private Degrees of decimal with
    static member (-) (Degrees d1, Degrees d2) = Degrees (d1 - d2)

[<Struct>]
type Radians = private Radians of float

[<Struct>]
type QiblaDirection = public {
    trueNorth: Degrees
    magneticNorth: Degrees
}

type QiblaDirectionQueryHandler = GeoCoordinates -> QiblaDirection

module QiblaDirection =
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
    let value (Longitude lon) = lon

    let create longitude =
        match longitude with
        | GreaterThan 180.0m -> None
        | LessThan -180.0m -> None
        | _ -> Some (Longitude longitude)

module Radians =
    open System
    let value (Radians rad) = rad

    let convert degrees =
        let degreesValue: float = float (Degrees.value degrees)
        (Math.PI / float 180) * degreesValue

module Mecca =
    let Kaaba = { latitude = Latitude 21.422487m; longitude  = Longitude 39.826206m }