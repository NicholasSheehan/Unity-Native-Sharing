namespace UnityNative.Sharing
{
    public interface IUnityNativeSharingAdapter
    {
        void ShareScreenshotAndText(string shareText, string filePath,                  bool   showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With", string mimeType = "image/*");
        void ShareText(string              shareText, bool   showShareDialogBox = true, string shareDialogBoxText = "Select App To Share With");
    }
}
