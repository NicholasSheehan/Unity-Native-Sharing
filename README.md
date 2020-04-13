# Unity-Native-Sharing
Unity-Native-Sharing is a plugin to open native sharing dialogs on iOS and Android.

[![openupm](https://img.shields.io/npm/v/com.unitynative.sharing?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.unitynative.sharing/)

### Social
![](https://img.shields.io/github/followers/NicholasSheehan?label=Follow%20on%20GitHub&style=social) ![](https://img.shields.io/twitter/follow/NSheehanDev?label=Follow%20on%20Twitter)

### Support
All of these projects are made during my free time. If you'd like to support me, you can do it whether by sponsoring me on GitHub or by donating via PayPal

[![](https://img.shields.io/badge/paypal-donate-yellow.svg)](https://www.paypal.me/NicholasSheehan)  

### Changes
Watch this repository to be notified of new releases! ![](https://img.shields.io/github/watchers/NicholasSheehan/Unity-Native-Sharing?style=social)

What's New? [CHANGELOG](CHANGELOG.md)

### Contribution
For contributing please read [CONTRIBUTING.md](CONTRIBUTING.md)

### System Requirements
Unity 2018.3.14f1 or later. Older versions may work, feel free to test!

### Examples
Examples can be found at [Unity-Native-Example-Project](https://github.com/NicholasSheehan/Unity-Native-Example-Project)

## Installation
#### For `Unity 2018.3` or later (Using OpenUPM) [![openupm](https://img.shields.io/npm/v/com.unitynative.sharing?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.unitynative.sharing/)

This package is available on [OpenUPM](https://openupm.com).  
You can install it via [openupm-cli](https://github.com/openupm/openupm-cli).
```
openupm add com.unitynative.sharing
```

#### For `Unity 2018.3` or later (Using Unity Package Manager)
Add this to the projects `manifest.json`
```
"com.unitynative.sharing" : "https://github.com/NicholasSheehan/Unity-Native-Sharing"
```

To update the package, change suffix `#release/{version}` to the target version.

* e.g. `"com.unitynative.sharing" : "https://github.com/NicholasSheehan/Unity-Native-Sharing#release/v1.0.0"`

Or, use [UpmGitExtension](https://github.com/mob-sakai/UpmGitExtension) to install and update the package.

#### For `Unity 2018.2`
`Unity 2018.2` supports embedded packages.

1. Download a source code zip file from [Releases](https://github.com/NicholasSheehan/Unity-Native-Sharing/releases) page
2. Extract it
3. Import it under `Packages` directory in your Unity project

## Features
- Share Text
- Share Screenshots w/ Text

### Known Issues
[Facebook, Messenger and Instagram cannot share text at all.](https://answers.unity.com/questions/871846/can-i-post-to-facebook-with-my-own-text.html)

### Testing

--            | `Android 8.0.0` | `iOS 10.3.3` | `iOS 11.3.1`
------------- | --------------  | -------------| ------------
Facebook      | No Text         | No Text      | No Text
Messenger     | No Text         | No Text      | No Text
Instagram     | No Text         | No Text      | No Text
Twitter       | ✔              | ✔            | ✔
Discord       | ✔              | ✔            | ✔
Slack         | ✔              | ✔            | ✔

## Roadmap
* Look into email sharing
* Look into video sharing
* Sharing multiple files
* Sharing Links w/ Text

## Platform Notes
#### Android
The Android plugin requires `androidx.appcompat:appcompat:1.1.0` to run.

This plugin has support for [Play Services Resolver for Unity](https://github.com/googlesamples/unity-jar-resolver) which will take care of this for you



