using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;

/*
 * https://github.com/ChrisMaire/unity-native-sharing
 */

public static class NativeShare {

	public static void Share(string body, string imagePath, string url, string subject = "")
	{
#if UNITY_ANDROID
		ShareAndroid(body, subject, url, imagePath);
#elif UNITY_IOS
		ShareIOS(body, subject, url, imagePath);
#else
		Debug.Log("No sharing set up for this platform.");
#endif
	}

#if UNITY_ANDROID
	public static void ShareAndroid(string body, string subject, string url, string imagePath)
	{
		AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
		AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + imagePath);
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
		intentObject.Call<AndroidJavaObject>("setType", "image/png");

		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);

		AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, subject);
		currentActivity.Call("startActivity", jChooser);
	}
#endif

#if UNITY_IOS
	public struct ConfigStruct
	{
		public string title;
		public string message;
	}

	[DllImport ("__Internal")] private static extern void showAlertMessage(ref ConfigStruct conf);

	public struct SocialSharingStruct
	{
		public string text;
		public string url;
		public string image;
		public string subject;
	}

	[DllImport ("__Internal")] private static extern void showSocialSharing(ref SocialSharingStruct conf);

	public static void ShareIOS(string title, string message)
	{
		ConfigStruct conf = new ConfigStruct();
		conf.title  = title;
		conf.message = message;
		showAlertMessage(ref conf);
	}


	public static void CallSocialShareAdvanced(string body, string subject, string url, string imagePath)
	{
		SocialSharingStruct conf = new SocialSharingStruct();
		conf.text = body;
		conf.url = url;
		conf.image = imagePath;
		conf.subject = subject;

		showSocialSharing(ref conf);
	}
#endif
}
