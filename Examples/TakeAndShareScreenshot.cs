using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace UnityNative.Sharing.Example
{
    public class TakeAndShareScreenshot : MonoBehaviour
    {
        /// <summary>
        /// Name of the screenshot
        /// </summary>
        [SerializeField] private string screenshotName = "screenshot.png";

        /// <summary>
        /// Text to share with the screenshot
        /// </summary>
        [SerializeField] private string shareText = "This is a some text that is shared with a screenshot";

        /// <summary>
        /// Amount to upscale the image by
        /// </summary>
        [Range(1, 4)]
        [SerializeField] private int upscaleAmount = 1;

        #region Events / Actions

        /// <summary>
        /// Event that is invoked a frame before the screenshot is taken
        /// </summary>
        [Header("Screenshot Actions")]
        [SerializeField] private UnityEvent OnFrameBeforeScreenshot = null;

        /// <summary>
        /// Event that is invoked a frame after the screenshot is taken
        /// </summary>
        [SerializeField] private UnityEvent OnFrameAfterScreenshot = null;

        #endregion

        /// <summary>
        /// Takes and shares a screenshot with text
        /// </summary>
        public void ShareScreenshotWithText()
        {
            ShareScreenshotWithText(shareText);
        }

        /// <summary>
        /// Takes and shares a screenshot with text
        /// </summary>
        /// <param name="text">Text to share along side the screenshot</param>
        public void ShareScreenshotWithText(string text)
        {
            var screenShotPath = Application.persistentDataPath + "/" + screenshotName;
            
            OnFrameBeforeScreenshot?.Invoke();

            ScreenCapture.CaptureScreenshot(screenshotName, upscaleAmount);
            
            StartCoroutine(WaitForScreenshotToSaveThenShare(screenShotPath, text));
        }

        /// <summary>
        /// CaptureScreenshot() runs async, so we check the screenshot path to see if there is a file there, once a file is found, then we share it 
        /// </summary>
        /// <param name="screenshotPath">Path the screenshot was saved to</param>
        /// <param name="text">Text to share with the screenshot</param>
        private IEnumerator WaitForScreenshotToSaveThenShare(string screenshotPath, string text)
        {
            while (!File.Exists(screenshotPath))
                yield return new WaitForSecondsRealtime(0.05f);

            OnFrameAfterScreenshot?.Invoke();

            UnityNativeSharingHelper.ShareScreenshotAndText(text, screenshotPath, false, "Select App To Share With");
        }
    }
}
