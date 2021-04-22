namespace QiblaDirection.UnitTests
open DomainApi
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing () =
        Assert.IsTrue(true);

    [<TestMethod>]
    member this.Isit () =
        let res = { lat = 51.5160; lon = -0.1749 } |> GetQiblaDirectionWorkflow.qiblaDirection