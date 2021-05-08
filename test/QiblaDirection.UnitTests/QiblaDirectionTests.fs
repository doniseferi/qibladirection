namespace QiblaDirection.UnitTests
open QiblaDirection
open QiblaDirection.CommonTypes
open TestData
open NUnit.Framework

[<TestFixture>]
type QiblaDirectionTests () =

    let resultPassthroughAdapter: ('i -> Result<'o, 'e>) -> 'i-> 'o =
        fun f arg ->
            match f arg with
            | Ok s -> s
            | Error _ -> failwith "Passthrough failed %s"
    
    let errorPassthroughAdapter: ('i -> Result<'o, 'e>) -> 'i-> 'e =
       fun f arg ->
            match f arg with
            | Ok _ -> failwith "Passthrough failed %s"
            | Error e -> e
 
    let systemUnderTest =
        GetQiblaDirectionHandler.qiblaDirectionQueryHandler' 
        |> resultPassthroughAdapter

    let systemUnderTestErrorAdapter =
        GetQiblaDirectionHandler.qiblaDirectionQueryHandler' 
        |> errorPassthroughAdapter
    
    [<Test>]
    member this.``Returns the true north value for Qibla when given geo coordinates`` () =
          testData 
          |> Seq.iter (fun x -> 
            Assert.That(
                x.expected, 
                Is.EqualTo(
                    (systemUnderTest x.input).trueNorth 
                    |> Degrees.value)
                    .Within(0.00005f)))

    [<Test>]
    member this.``Invalid latitude returns an error`` () =
          [|
              { lat = 91 |> float; lon = 0|> float }
              { lat = -91 |> float; lon = 0|> float }
          |] 
          |> Seq.iter (fun x ->
            Assert.AreEqual(
                [{ invalidField = "latitude"; message = "Please provide a latitude value between -90 to 90" }],
                systemUnderTestErrorAdapter x))

    [<Test>]
    member this.``Invalid longitude returns an error`` () =
          [|
              { lat = 0 |> float; lon = -181 |> float }
              { lat = 0 |> float; lon = 181 |> float }
          |] 
          |> Seq.iter (fun x -> 
            Assert.AreEqual(
                [{ invalidField = "longitude"; message = "Please provide a longitude value between -180 to 180" }],
                systemUnderTestErrorAdapter x))