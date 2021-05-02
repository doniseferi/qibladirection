module TestData
open CommonTypes

let testData = [|
    {| input = { lat = 51.5160; lon = -0.1749}; expected = 118.9432373f |}
    {| input = {lat = 65.994189; lon = -129.143226}; expected = 10.267454726525035f |}
    {| input = {lat = 37.253646; lon = -112.755227}; expected = 28.456810409061276f |}
    {| input = {lat = 3.279451; lon = -71.668188}; expected = 66.08214676347097f |}
    {| input = {lat = -70.806185; lon = -64.527692}; expected = 96.1938936570457f |}
    {| input = {lat = -80.532071; lon = 57.802942}; expected = -17.107324005468886f |}
    {| input = {lat = -21.070825; lon = 132.047922}; expected = -70.58537361766263f |}
    {| input = {lat = 34.355531; lon = 135.493330}; expected = -69.1183753507485f |}
    {| input = {lat = 42.524635; lon = 87.539589}; expected = -102.61910076759416f |}
    {| input = {lat = 55.755825; lon = 37.617298}; expected = 176.35625368092548f |}
    {| input = {lat = 66.791909; lon = 165.023913}; expected = -50.05412698394485f |}
    {| input = {lat = 59.977005; lon = 10.715712}; expected = 139.02517344191932f |}
    {| input = {lat = 64.147355; lon = -21.893204}; expected = 106.16618779534778f |}
    {| input = {lat = 83.111071; lon = -30.911536}; expected = 106.54573156682889f |}
|]