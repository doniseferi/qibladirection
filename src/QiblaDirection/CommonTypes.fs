namespace QiblaDirection.CommonTypes

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
type ErrorInformation = public {
    message: string
    invalidField: string
}

[<Struct>]
type UnvalidatedGeoCoordinates = public {
    lat: float
    lon: float
}

type Result<'Success, 'Failure> =
    | Ok of 'Success
    | Error of 'Failure
    
module Result =
    let map fn r =
        match r with
        | Ok s -> Ok (fn s)
        | Error e -> Error e
        
    let bind fn r =
        match r with
        | Ok s -> fn s
        | Error e -> Error e

module ConstainedTypes =
    let (|LessThan|_|) k value = if value < k then Some() else None
    let (|GreaterThan|_|) k value = if value > k then Some() else None

module QiblaDirection =
    let create trueNorth = { trueNorth = trueNorth }

module Degrees = 
    open System

    let value (Degrees deg) = deg
    
    let fromRadians rad =
        Degrees (rad * (float 180 / Math.PI))

module Radians =
    open System
    let value (Radians rad) = rad

    let fromDegrees deg =
        let degreesValue: float = float deg
        Radians ((Math.PI / float 180) * degreesValue)

module Latitude =
    open ConstainedTypes
    let value (Latitude lat) = lat

    let subtract latitudeA latitudeB =
        value latitudeA - value latitudeB 
        |> Radians.fromDegrees

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
        |> Radians.fromDegrees

    let create longitude =
        match longitude with
        | GreaterThan 180.0 -> None
        | LessThan -180.0 -> None
        | _ -> Some (Longitude longitude)

module Mecca =
    let Kaaba = { latitude = Latitude 21.422487; longitude  = Longitude 39.826206 }