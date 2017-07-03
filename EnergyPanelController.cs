using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyPanelController : MonoBehaviour {

	public Image redLight, blueLight, greenLight;
	public string currentColor = "red";
	public GameObject[] secondRowButtons;
	// Use this for initialization
	void Start () {

		redLight.color = Color.grey;
		blueLight.color = Color.grey;
		greenLight.color = Color.grey;
		StartCoroutine ("LightRedBulb");
		secondRowButtons = GameObject.FindGameObjectsWithTag ("SecondRowButtons");
		ButtonColorGrey ();
	}
	
	// Update is called once per frame
	void Update () {


	}

	IEnumerator LightRedBulb(){

		greenLight.color = Color.grey;
		redLight.color = Color.red;
		currentColor = "red";

		yield return new WaitForSecondsRealtime (2.0f);
		StartCoroutine ("LightBlueBulb");
		GetButtonColor ("blue");
	}

	IEnumerator LightBlueBulb(){

		redLight.color = Color.grey;
		blueLight.color = Color.blue;
		currentColor = "blue";

		yield return new WaitForSecondsRealtime (2.0f);
		StartCoroutine ("LightGreenBulb");
		GetButtonColor ("green");
	}

	IEnumerator LightGreenBulb(){

		blueLight.color = Color.grey;
		greenLight.color = Color.green;
		currentColor = "green";

		yield return new WaitForSecondsRealtime (2.0f);
		StartCoroutine ("LightRedBulb");
		GetButtonColor ("red");

	}

	void ButtonColorGrey(){

		foreach (GameObject button in secondRowButtons) {

			EnergyPanel buttonStats = button.GetComponent<EnergyPanel> ();

			if(buttonStats.squarebuttonMoved == false){

				Image buttonColor;
				buttonColor = button.transform.GetChild (0).GetComponent<Image> ();
				buttonColor.color = Color.grey;
				buttonStats.secondRowButtonColor = "";
			}

		}
	}

	void GetButtonColor(string color){

		ButtonColorGrey ();

		int randomButton;
		randomButton = Random.Range (0, 6);
		GameObject selectedButton = secondRowButtons [randomButton];
		EnergyPanel buttonStats = selectedButton.GetComponent<EnergyPanel> ();
		Image selectedButtonColor = selectedButton.transform.GetChild (0).GetComponent<Image> ();

		/*
		while (buttonStats.squarebuttonMoved == true) {
			randomButton = Random.Range (0, 6);
			selectedButton = secondRowButtons [randomButton];
			buttonStats = selectedButton.GetComponent<EnergyPanel> ();
		}
		*/


		if (buttonStats.secondRowButtonColor == ""){

			if(color == "blue"){

				selectedButtonColor.color = Color.blue;
				buttonStats.secondRowButtonColor = "blue";

			}

			if(color == "red"){

				selectedButtonColor.color = Color.red;
				buttonStats.secondRowButtonColor = "red";

			}

			if(color == "green"){

				selectedButtonColor.color = Color.green;
				buttonStats.secondRowButtonColor = "green";

			}
		}

	}

	/*
	void GetButtonColor(){

		int randomButton;
		randomButton = Random.Range (0, 6);
		GameObject selectedButton = secondRowButtons [randomButton];
		EnergyPanel buttonStats = selectedButton.GetComponent<EnergyPanel> ();
		/*
		while (buttonStats.squarebuttonMoved == true) {
			randomButton = Random.Range (0, 6);
			selectedButton = secondRowButtons [randomButton];
			buttonStats = selectedButton.GetComponent<EnergyPanel> ();
		}
		//el while es de beñat

			Image selectedButtonColor = selectedButton.transform.GetChild (0).GetComponent<Image> ();
			//selectedButtonColor.color = Color.
			switch(Random.Range(1,4)){

			case 1:

				selectedButtonColor.color = Color.blue;
				buttonStats.secondRowButtonColor = "blue";
				break;

			case 2:

				selectedButtonColor.color = Color.red;
				buttonStats.secondRowButtonColor = "red";
				break;

			case 3:

				selectedButtonColor.color = Color.green;
				buttonStats.secondRowButtonColor = "green";
				break;

			}

			
	}
*/

	public void ResetSecondRowButtons(){

		foreach (GameObject button in secondRowButtons) {

			button.transform.localPosition = new Vector3(button.transform.localPosition.x,-22, button.transform.localPosition.z);
			EnergyPanel buttonController = button.GetComponent<EnergyPanel> ();
			buttonController.squarebuttonMoved = false;	
			Image imageButton = button.transform.GetChild(0).GetComponent<Image>();
			imageButton.color = Color.grey;
		}
	}
}
