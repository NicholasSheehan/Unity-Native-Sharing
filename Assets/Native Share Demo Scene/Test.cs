using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;

/*
 * https://github.com/ChrisMaire/unity-native-sharing
 */

public class Test : MonoBehaviour {
	public string ScreenshotName = "screenshot.png";

    public void ShareScreenshotWithText(string text)
    {
        string screenShotPath = Application.persistentDataPath + "/" + ScreenshotName;
        if(File.Exists(screenShotPath)) File.Delete(screenShotPath);

        Application.CaptureScreenshot(ScreenshotName);

        StartCoroutine(delayedShare(screenShotPath, text));
    }

    //CaptureScreenshot runs asynchronously, so you'll need to either capture the screenshot early and wait a fixed time
    //for it to save, or set a unique image name and check if the file has been created yet before sharing.
    IEnumerator delayedShare(string screenShotPath, string text)
    {
        while(!File.Exists(screenShotPath)) {
    	    yield return new WaitForSeconds(.05f);
        }

		NativeShare.Share(text, screenShotPath, "");
    }
}
