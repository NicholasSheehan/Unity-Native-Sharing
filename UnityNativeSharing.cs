namespace UnityNative.Sharing
{
    public interface IUnityNativeSharing
    {
        void ShareScreenshotAndText(string shareText, string filePath,                  bool   showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With");
        void ShareText(string              shareText, bool   showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With");
    }


    public class UnityNativeSharing : IUnityNativeSharing
    {
        private readonly IUnityNativeSharingAdapter adapter;

        /// <summary>
        /// Creates a UnityNativeSharing object with the correct platform setup. Use this if not being used with an IoC container
        /// </summary>
        /// <returns>Interface for the detected platform</returns>
        public static IUnityNativeSharing Create()
        {
#if UNITY_ANDROID
            return new UnityNativeSharing(new AndroidUnityNativeSharingAdapter());
#elif UNITY_IOS
            return new UnityNativeSharing(new IosUnityNativeSharingAdapter());
#else
            return new UnityNativeSharing(new NullUnityNativeSharingAdapter());
#endif
        }

        public UnityNativeSharing(IUnityNativeSharingAdapter adapter)
        {
            this.adapter = adapter;
        }

        /// <summary>
        /// Shares a screenshot with text
        /// </summary>
        /// <param name="shareText">Text to share</param>
        /// <param name="filePath">The path to the attached file</param>
        /// <param name="showShareDialogBox">Should the share dialog be opened (Android only)</param>
        /// <param name="shareDialogBoxText">The text to show on the share dialog (Android only)</param>
        public void ShareScreenshotAndText(string shareText, string filePath, bool showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With")
        {
            adapter.ShareScreenshotAndText(shareText, filePath, showShareDialogBox, shareDialogBoxText);
        }

        /// <summary>
        /// Shares text
        /// </summary>
        /// <param name="shareText">Text to share</param>
        /// <param name="showShareDialogBox">Should the share dialog be opened (Android only)</param>
        /// <param name="shareDialogBoxText">The text to show on the share dialog (Android only)</param>
        public void ShareText(string shareText, bool showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With")
        {
            adapter.ShareText(shareText, showShareDialogBox, shareDialogBoxText);
        }
    }
}
