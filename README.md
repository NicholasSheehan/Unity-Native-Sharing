# unity-native-sharing
A Unity plugin to open native sharing dialogs on iOS and Android, primarily for sharing screenshots.

To use, copy the iOSNativeShare.h and iOSNativeShare.m files to Assets/Plugins/iOS and NativeShare.cs to Assets/Plugins, then call the Share method in NativeShare.cs. See NativeShare.cs for details.

This plugin combines and refines code from:

Android Native sharing by Daniele Olivieri
http://www.daniel4d.com/blog/sharing-image-unity-android/

iOS Native sharing by Tushar Sonu Lambole 
http://tusharlambole.blogspot.com/2014/06/ios-native-plugin-for-unity3d.html

Huge thank you to both of those folks for sharing their code!

Documentation on Android intents
http://developer.android.com/reference/android/content/Intent.html
Documentation on iOS UIActivityViewController
https://developer.apple.com/library/ios/documentation/UIKit/Reference/UIActivityViewController_Class/index.html

Built in Unity 5.1.1p4 and tested on Android 5.1 (HTC One M7) and iOS 8.4 (iPhone 5S)

by Christopher Maire (http://www.twitter.com/DINOSAURSSSSSSS)
www.chrismaire.com
