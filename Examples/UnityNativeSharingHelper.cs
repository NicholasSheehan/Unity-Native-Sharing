namespace UnityNative.Sharing.Example
{
    public static class UnityNativeSharingHelper
    {
        private static readonly IUnityNativeSharing unityNativeSharing;

        static UnityNativeSharingHelper()
        {
            unityNativeSharing = UnityNativeSharing.Create();
        }

        /// <summary>
        /// Shares a screenshot with text
        /// </summary>
        /// <param name="shareText">Text to share</param>
        /// <param name="filePath">The path to the attached file</param>
        /// <param name="showShareDialogBox">Should the share dialog be opened (Android only)</param>
        /// <param name="shareDialogBoxText">The text to show on the share dialog (Android only)</param>
        public static void ShareScreenshotAndText(string shareText, string filePath, bool showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With")
        {
            unityNativeSharing.ShareScreenshotAndText(shareText, filePath, showShareDialogBox, shareDialogBoxText);
        }

        /// <summary>
        /// Shares text
        /// </summary>
        /// <param name="shareText">Text to share</param>
        /// <param name="showShareDialogBox">Should the share dialog be opened (Android only)</param>
        /// <param name="shareDialogBoxText">The text to show on the share dialog (Android only)</param>
        public static void ShareText(string shareText, bool showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With")
        {
            unityNativeSharing.ShareText(shareText, showShareDialogBox, shareDialogBoxText);
        }
    }
}
