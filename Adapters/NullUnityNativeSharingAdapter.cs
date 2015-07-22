namespace UnityNative.Sharing
{
    public class NullUnityNativeSharingAdapter : IUnityNativeSharingAdapter
    {
        public void ShareScreenshotAndText(string shareText, string filePath, bool showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With")
        {
        }

        public void ShareText(string shareText, bool showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With")
        {
        }
    }
}
