# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.0.6] - 2021-03-09
### Added
- Added optional mime type parameter for Android to use in the intent rather than it being hardcoded to `image/*`

## [1.0.5] - 2021-01-07
### Fixed
- AAR `AndroidManifest.xml` now uses a custom file provider in order to stop conflicts with other plugins from the Unity asset store which also use the default file provider

## [1.0.4] - 2020-06-25
### Fixed
- AAR `AndroidManifest.xml` now used the AndroidX file provider

### Removed
- Removed the `Roadmap` and converted them all into issues for easier tracking

## [1.0.3] - 2020-04-15
### Changed
- Fixed inconsistent share dialog text
- Sharing a screenshot does not display the share dialog text, this is to show the difference between the options
- Added more things to the `Roadmap` list in the README.md

## [1.0.2] - 2020-04-13
### Changed
- Updated the Android AAR to targetSdk 28 to be more inline with Google's current requirements
- Updated README.md with updated Android dependency `androidx.appcompat:appcompat:1.1.0`
- Bumped the version number

## [1.0.1] - 2020-04-13
### Changed
- Updated README.md with OpenUPM badge
- Bumped the version number to see how OpenUPM works

## [1.0.0] - 2020-04-13
### This is the first release of *Unity-Native-Sharing*.
