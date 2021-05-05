namespace CommonTypes

[<Struct>]
type Latitude = private Latitude of  float

[<Struct>]
type Longitude = private Longitude of float

[<Struct>]
type GeoCoordinates = public {
    latitude: Latitude; 
    longitude: Longitude
}

[<Struct>]
type Degrees = private Degrees of float

[<Struct>]
type Radians = private Radians of float

[<Struct>]
type QiblaDirection = public {
    trueNorth: Degrees
}

[<Struct>]
type ErrorInformation = {
    message: string
    invalidField: string
}

[<Struct>]
type QiblaError = QiblaError of ErrorInformation

[<Struct>]
type UnvalidatedGeoCoordinates = public {
    lat: float
    lon: float
}

module ConstainedTypes =
    let (|LessThan|_|) k value = if value < k then Some() else None
    let (|GreaterThan|_|) k value = if value > k then Some() else None

module QiblaDirection =
    let create trueNorth = { trueNorth = trueNorth }

module Degrees = 
    open ConstainedTypes
    open System

    let value (Degrees deg) = deg
    
    let convert value =
        Degrees (value * (float 180 / Math.PI))

    let create degrees =
        match degrees with
        | GreaterThan 360f -> None
        | LessThan 0f -> None
        | _ -> Some (Degrees (float degrees))

module Radians =
    open System
    let value (Radians rad) = rad

    let convert value =
        let degreesValue: float = float value
        Radians ((Math.PI / float 180) * degreesValue)

module Latitude =
    open ConstainedTypes
    let value (Latitude lat) = lat

    let subtract latitudeA latitudeB =
        value latitudeA - value latitudeB 
        |> Radians.convert

    let create latitude =
        match latitude with
        | GreaterThan (float 90) -> None
        | LessThan (float -90) -> None
        | _ -> Some (Latitude latitude)

module Longitude =
    open ConstainedTypes
    let value (Longitude lon) = lon

    let subtract longitudeA longitudeB =
        value longitudeA - value longitudeB 
        |> Radians.convert

    let create longitude =
        match longitude with
        | GreaterThan 180.0 -> None
        | LessThan -180.0 -> None
        | _ -> Some (Longitude longitude)

module Mecca =
    let Kaaba = { latitude = Latitude 21.422487; longitude  = Longitude 39.826206 }