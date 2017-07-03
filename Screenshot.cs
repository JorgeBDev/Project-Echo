using UnityEngine;
using System.Collections;

public class Screenshot : MonoBehaviour {
	public int screenshotIndex = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.F12)) {
			//Application.CaptureScreenshot("Screenshot.png", superSize:5);
			Application.CaptureScreenshot("Screenshot" + screenshotIndex + ".png", superSize:5);
			screenshotIndex++;
		
		}
	
	}
}
