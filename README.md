<p align="center" background-color="white">
<img src="https://raw.githubusercontent.com/doniseferi/qibladirection/a348f377d5adac74bdb78aafd7664a80c072081c/images/QiblaDirection.svg?sanitize=true" width="300px" />
</p>

![GitHub Workflow Status](https://img.shields.io/github/workflow/status/doniseferi/qibladirection/.NET?style=for-the-badge) ![GitHub top language](https://img.shields.io/github/languages/top/doniseferi/qibladirection?style=for-the-badge) ![License](https://img.shields.io/github/license/doniseferi/qibladirection?style=for-the-badge) ![Coveralls](https://img.shields.io/coveralls/github/doniseferi/qibladirection?style=for-the-badge)

An F# library that given a latitude and logitude record will return the direction of the Kaaba, also known as the Qibla.

# Example
```dotnetcli
// Output: {Case:Ok,Fields:[{{ trueNorth: Degrees 118.9432346 }}]}
GetQiblaDirectionHandler.qiblaDirectionQueryHandler' { lat = 51.5160; lon = -0.1749}
```