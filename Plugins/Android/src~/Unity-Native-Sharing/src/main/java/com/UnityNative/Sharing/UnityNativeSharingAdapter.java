package com.UnityNative.Sharing;

import android.content.Context;
import android.content.Intent;
import android.net.Uri;

import androidx.annotation.Keep;
import androidx.core.content.FileProvider;

import com.unity3d.player.UnityPlayer;

import java.io.File;

/**
 * Created by Nicholas Sheehan on 28/05/2018.
 */
@Keep
public class UnityNativeSharingAdapter {

    /**
     * Shares text and a image to an app
     *
     * @param shareText          - Text to share to the app
     * @param imagePath          - Path to the file to share
     * @param showShareDialog    - Should the share dialog be opened
     * @param shareDialogBoxText - Title of the share dialog
     * @param mimeType           - Mime type of the file being shared
     */
    @Keep
    public static void ShareScreenshotAndText(String shareText, String imagePath, boolean showShareDialog, String shareDialogBoxText, String mimeType) {

        //Generate the intent
        Intent intent = new Intent();
        intent.setAction(Intent.ACTION_SEND);
        intent.setType(mimeType);
        intent.putExtra(Intent.EXTRA_TEXT, shareText);
        intent.addFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION);

        Context unityContext = UnityPlayer.currentActivity.getApplicationContext();

        // This will generate a uri based that will get the screenshot we have allowed Android to see.
        // This is done this way to prevent a UriFileException on newer targets of Android
        Uri imageUri = FileProvider.getUriForFile(unityContext, unityContext.getPackageName() + ".UnityNativeSharing.provider", new File(imagePath));

        intent.putExtra(Intent.EXTRA_STREAM, imageUri);

        Intent shareIntent = Intent.createChooser(intent, shareDialogBoxText);

        if (showShareDialog)
            UnityPlayer.currentActivity.startActivity(shareIntent);
        else
            UnityPlayer.currentActivity.startActivity(intent);
    }

    /**
     * Shares text to an app
     *
     * @param shareText          - Text to share to the app
     * @param showShareDialog    - Should the share dialog be opened
     * @param shareDialogBoxText - Title of the share dialog
     */
    @Keep
    public static void ShareText(String shareText, boolean showShareDialog, String shareDialogBoxText) {

        //Generate the intent
        Intent intent = new Intent();
        intent.setAction(Intent.ACTION_SEND);
        intent.setType("text/plain");
        intent.putExtra(Intent.EXTRA_TEXT, shareText);

        Intent shareIntent = Intent.createChooser(intent, shareDialogBoxText);

        if (showShareDialog)
            UnityPlayer.currentActivity.startActivity(shareIntent);
        else
            UnityPlayer.currentActivity.startActivity(intent);
    }
}