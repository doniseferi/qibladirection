# qibladirection

![GitHub Workflow Status](https://img.shields.io/github/workflow/status/doniseferi/qibladirection/.NET?style=for-the-badge) ![GitHub top language](https://img.shields.io/github/languages/top/doniseferi/qibladirection?style=for-the-badge) ![License](https://img.shields.io/github/license/doniseferi/qibladirection?style=for-the-badge)

An F# library that given a latitude and logitude record will return the magnetic north direction of the Kaaba, also known as the qibla.

# Example
```dotnetcli
// Output: trueNorth: Degrees 118.9432346
GetQiblaDirectionHandler.qiblaDirectionQueryHandler' { lat = 51.5160; lon = -0.1749}
```