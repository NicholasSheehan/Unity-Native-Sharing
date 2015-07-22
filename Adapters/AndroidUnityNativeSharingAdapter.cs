#if UNITY_ANDROID

using UnityEngine;

namespace UnityNative.Sharing
{
    public class AndroidUnityNativeSharingAdapter : IUnityNativeSharingAdapter
    {
        /// <summary>
        /// Android package name and class
        /// </summary>
        private const string AndroidClass = "com.UnityNative.Sharing.UnityNativeSharingAdapter";

        /// <summary>
        /// Android method name to call to share a screenshot with text
        /// </summary>
        private const string ShareScreenshotWithTextMethodName = "ShareScreenshotAndText";

        /// <summary>
        /// Android method name to call to share text
        /// </summary>
        private const string ShareTextMethodName = "ShareText";

        /// <summary>
        /// UnityNativeSharingAdapter.java
        /// </summary>
        private readonly AndroidJavaClass sharingJavaClass;
        
        public AndroidUnityNativeSharingAdapter()
        {
            AndroidJNI.AttachCurrentThread();
            
            sharingJavaClass = new AndroidJavaClass(AndroidClass);
        }
        
        public void ShareScreenshotAndText(string shareText, string filePath, bool showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With")
        {
            AndroidJNI.AttachCurrentThread();
            
            sharingJavaClass.CallStatic(ShareScreenshotWithTextMethodName, shareText, filePath, showShareDialogBox, shareDialogBoxText);
        }

        public void ShareText(string shareText, bool showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With")
        {
            AndroidJNI.AttachCurrentThread();
            
            sharingJavaClass.CallStatic(ShareTextMethodName, shareText, showShareDialogBox, shareDialogBoxText);
        }
    }
}

#endif //UNITY_ANDROID
