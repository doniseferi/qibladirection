module GetQiblaDirectionWorkflow
open CommonTypes
open DomainApi
open System
open GeoCoordinatesService

//let handle geoCoordinatesService unvalidatedGeoCoordinates =
//    match geoCoordinatesService unvalidatedGeoCoordinates with
//    | Error e -> QiblaError { invalidField = e.invalidField; message = e.message }
//    | Result geoCoordinates ->

let qiblaDirection geoCoordinates =
    let l = Longitude.value Mecca.Kaaba.longitude - Longitude.value geoCoordinates.longitude
    let rad: float = float l
    let n = sin rad
    let b = cos (Latitude.value geoCoordinates.latitude) tan Mecca.Kaaba.latitude sin cos Latitude.value Mecca.Kaaba.longitude - geoCoordinates.longitude
    let r = a / b
    let q = atan r
    let res = Degrees.create q
    match res with
    | Some s -> {trueNorth = s; magneticNorth = s}
    | None -> failwith "Err Err Err"


