#if UNITY_IOS
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace UnityNative.Sharing.Editor
{
    internal static class UnityNativeSharing_iOSPlistKeys
    {
        /// <summary>
        /// Keys to add to Info.plist for iOS, this stops the app from crashing when attempting to save screenshots to the library
        /// </summary>
        private static readonly Dictionary<string, string> infoPlistStringKeys = new Dictionary<string, string>
        {
            {"NSPhotoLibraryUsageDescription", "This App Can Save Screenshots For Sharing"},
            {"NSPhotoLibraryAddUsageDescription", "This App Can Save Screenshots To Your Photo Album For Sharing"},
        };

        [PostProcessBuild(0)]
        public static void EditXcodeProject(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS) return;

            Edit_Plist(pathToBuiltProject);
        }

        /// <summary>
        /// Edits the Info.plist file and adds in a missing key
        /// </summary>
        /// <param name="pathToBuiltProject">Path to the build project</param>
        private static void Edit_Plist(string pathToBuiltProject)
        {
            Debug.Log("Starting Editing of Info.plist");

            var plistPath = pathToBuiltProject + "/Info.plist";
            var plist     = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));

            // Get root
            PlistElementDict rootDict = plist.root;

            // Add string keys
            foreach (var entry in infoPlistStringKeys)
            {
                // Only add the key if needed, another plugin may have already set this
                if (rootDict.values.ContainsKey(entry.Key))
                    continue;

                rootDict.SetString(entry.Key, entry.Value);
                Debug.Log($"Added \"{entry.Key} = {entry.Value}\" to Info.plist");
            }

            // Saves the plist file
            File.WriteAllText(plistPath, plist.WriteToString());
            Debug.Log("Saving Edited Info.plist");
        }
    }
}
#endif //UNITY_IOS
