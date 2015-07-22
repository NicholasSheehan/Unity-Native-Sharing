using UnityEngine;
using System.Collections;

public class DoShare : MonoBehaviour {
	NativeShare share;

	void Awake () {
		share = GetComponent<NativeShare> ();
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
            share.ShareScreenshotWithText("Whoa Cool You Shared Some Text");
		}
	}
}
