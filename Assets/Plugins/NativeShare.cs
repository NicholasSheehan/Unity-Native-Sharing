#define UNITY_ANDROID

#if UNITY_IOS
using System.Runtime.InteropServices;
#else
using UnityEngine;
#endif

/*
 * https://github.com/ChrisMaire/unity-native-sharing
 */

public static class NativeShare {

	public static void Share(string body, string imagePath, string url, string subject = "", string mimeType = "text/html")
	{
#if UNITY_ANDROID
		ShareAndroid(body, subject, url, imagePath, mimeType);
#elif UNITY_IOS
		ShareIOS(body, subject, url, imagePath);
#else
		Debug.Log("No sharing set up for this platform.");
#endif
	}

#if UNITY_ANDROID
	public static void ShareAndroid(string body, string subject, string url, string imagePath, string mimeType)
	{
		using (AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent"))
		using (AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent"))
		{
			using (intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND")))
			{ }
			using (AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri"))
			using (AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + imagePath))
			using (intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject))
			{ }
			using (intentObject.Call<AndroidJavaObject>("setType", mimeType))
			{ }
			using (intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body))
			{ }

			using (AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			using (AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity"))
			using (AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, subject))
			{
				currentActivity.Call("startActivity", jChooser);
			}
		}
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

	public static void ShareIOS(string body, string subject, string url, string imagePath)
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
