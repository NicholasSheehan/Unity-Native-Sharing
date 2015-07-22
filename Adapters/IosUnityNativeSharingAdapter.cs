#if UNITY_IOS

namespace UnityNative.Sharing
{
    public class IosUnityNativeSharingAdapter : IUnityNativeSharingAdapter
    {
        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern void UnityNative_Sharing_ShareTextAndScreenshot(string shareText, string filePath);

        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern void UnityNative_Sharing_ShareText(string shareText);
        
        public void ShareScreenshotAndText(string shareText, string filePath, bool showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With")
        {
            UnityNative_Sharing_ShareTextAndScreenshot(shareText, filePath);
        }

        public void ShareText(string shareText, bool showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With")
        {
            UnityNative_Sharing_ShareText(shareText);
        }
    }
}

#endif //UNITY_IOS
