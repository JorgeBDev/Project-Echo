using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextBoxController : MonoBehaviour {

	public TextAsset plasteTutorialTextFile;
	public string[] plasteTextLines;

	public GameObject textBox;
	public Text plasteText;

	public int currentTextLine;
	public int endAtTextLine;

	public int currentStep = 0;
	public bool canNext = true;
	// Use this for initialization
	void Start () {

		if(plasteTutorialTextFile != null){

			plasteTextLines = (plasteTutorialTextFile.text.Split('\n'));
		}
		/*
		if(endAtTextLine == 0){
			endAtTextLine = plasteTextLines.Length - 1;
		}
		*/
	
	}
	
	// Update is called once per frame
	void Update () {

		plasteText.text = plasteTextLines[currentTextLine];

		if(Input.GetKeyDown(KeyCode.Return) && canNext == true){
			currentTextLine += 1;
		}

		if(currentTextLine == 2){
			textBox.SetActive (false);
			canNext = false;
		}

		if(currentTextLine == 5){
			textBox.SetActive (false);
			canNext = false;
		}

		if(currentTextLine == 8){
			textBox.SetActive (false);
			canNext = false;
		}

		if (textBox.activeInHierarchy) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
			
	}

	public void NextStep(){

		Debug.Log ("NEX STEP");
		currentTextLine += 1;
		textBox.SetActive (true);
		canNext = true;
	}


}
