namespace QiblaDirection.UnitTests
open CommonTypes
open TestData
open NUnit.Framework

[<TestFixture>]
type QiblaDirectionTests () =

    let resultPassthroughAdapter: ('i -> Result<'o, 'e>) -> 'i-> 'o =
        fun f arg ->
            match f arg with
            | Ok s -> s
            | Error _ -> failwith ""

    let systemUnderTest = 
        GetQiblaDirectionHandler.qiblaDirectionQueryHandler' 
        |> resultPassthroughAdapter
    
    [<Test>]
    member this.``Returns the true north value for Qibla when given geocoordinates`` () =
          testData 
          |> Seq.iter (fun x -> 
            Assert.That(
                x.expected, 
                Is.EqualTo(
                    (systemUnderTest x.input).trueNorth 
                    |> Degrees.value)
                    .Within(0.00005f)))
