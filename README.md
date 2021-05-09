<p align="center" background-color="white">
<img src="https://raw.githubusercontent.com/doniseferi/qibladirection/a348f377d5adac74bdb78aafd7664a80c072081c/images/QiblaDirection.svg?sanitize=true" width="300px" />
</p>

![GitHub Workflow Status](https://img.shields.io/github/workflow/status/doniseferi/qibladirection/.NET?style=for-the-badge) ![GitHub top language](https://img.shields.io/github/languages/top/doniseferi/qibladirection?style=for-the-badge) ![License](https://img.shields.io/github/license/doniseferi/qibladirection?style=for-the-badge) ![Coveralls](https://img.shields.io/coveralls/github/doniseferi/qibladirection?style=for-the-badge)

An F# library that given a latitude and logitude record will return the direction of the Kaaba, also known as the Qibla.

# Install
```dotnetcli
dotnet add package QiblaDirection
```
or from Visual Studios package manager console
```powershell
Install-Package QiblaDirection -ProjectName YOUR_PROJECT_NAME
```

# Example
```fsharp
open QiblaDirection

(*
  Case: Ok,
  trueNorth: Degrees 118.93071604419522
*)
GetQiblaDirectionHandler.qiblaDirectionQueryHandler' { lat = 51.522079; lon = -0.191380 }
```

```fsharp
open QiblaDirection

(* Output:
  Case: Error
    [
      {
        message: "Please provide a latitude value between -90 to 90"
        invalidField: "latitude"
      },
      {
        message: "Please provide a longitude value between -180 to 180"
        invalidField: "longitude"
      }
    ]
*)
GetQiblaDirectionHandler.qiblaDirectionQueryHandler'{ lat = 180.0012; lon = 0.0 }
```