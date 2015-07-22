using UnityEngine;

namespace UnityNative.Sharing.Example
{
    public class ShareText : MonoBehaviour
    {
        /// <summary>
        /// Text to share
        /// </summary>
        [SerializeField] private string textToShare = "This is an example of some shared text";

        /// <summary>
        /// Called via a button to share a string
        /// </summary>
        public void ShareString()
        {
            ShareString(textToShare);
        }

        /// <summary>
        /// Shares a string
        /// </summary>
        /// <param name="text">Text to share</param>
        public void ShareString(string text)
        {
           UnityNativeSharingHelper.ShareText(text);
        }
    }
}
