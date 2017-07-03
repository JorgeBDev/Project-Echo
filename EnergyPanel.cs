using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyPanel : MonoBehaviour {

	LevelManager levelManager;
	GameObject gameControllerGo;
	public int row,buttonInSequence;
	int buttonRequired = 1;
	public bool squarebuttonMoved = false;
	float desiredPosition = 19;
	float buttonSpeed = 1;
	GameObject[] firstRowButtons;
	public Image buttonImage;
	Color buttonColor;
	//row 2
	public string secondRowButtonColor = "grey";
	public EnergyPanelController energyPanelController;

	// Use this for initialization
	void Start () {

		gameControllerGo = GameObject.FindGameObjectWithTag ("GameController");
		levelManager = gameControllerGo.GetComponent<LevelManager> ();
		firstRowButtons = GameObject.FindGameObjectsWithTag ("FirstRowButtons");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PressSquareButton(){

		if(row == 1 && squarebuttonMoved == false){

			if(levelManager.isRow1Done == true){

				//Debug.Log ("Blocked");

			}else{
				//transform.Translate(Vector3.up * buttonSpeed * Time.deltaTime);
				transform.localPosition = new Vector3(transform.localPosition.x,262, transform.localPosition.z);
				squarebuttonMoved = true;
				buttonImage.color = Color.green;

				if(levelManager.energPanelButtonRequired == 5 && buttonInSequence == 5){

					levelManager.canTurnFirstLever = true;

				}

				if (buttonInSequence == levelManager.energPanelButtonRequired) { // pongo la condicion && para que no entre en el ultimo boton pero entre en la ultima if

					levelManager.EnergyPanelManager ("ButtonRequired++");

				} else{

					StartCoroutine ("WaitAndResetButtons",1);
				}


			}
		} 

		if(row == 2 && squarebuttonMoved == false && levelManager.isRow1Done == true && secondRowButtonColor == energyPanelController.currentColor){

			Debug.Log ("BOTON ACERTADO");
			transform.localPosition = new Vector3(transform.localPosition.x,39, transform.localPosition.z);
			buttonImage.color = Color.green;
			squarebuttonMoved = true;
			levelManager.secondButtonRowCounter ();
		}

		if(row == 2 && squarebuttonMoved == false && levelManager.isRow1Done == true && secondRowButtonColor != energyPanelController.currentColor){

			transform.localPosition = new Vector3(transform.localPosition.x,39, transform.localPosition.z);
			StartCoroutine ("WaitAndResetButtons",2);
		}
	}

	public void PressGreyLever(){

		//transform.parent.transform.localEulerAngles = new Vector3 (0,0,-90);

		if (levelManager.canTurnFirstLever == true && row == 1) {


			transform.parent.transform.localEulerAngles = new Vector3 (-180, 0, 0);
			levelManager.isRow1Done = true;

		}

		if (levelManager.canTurnSecondLever && row == 2) {


			transform.parent.transform.localEulerAngles = new Vector3 (-180, 0, 0);
			levelManager.isSecondRowDone = true;

		}
	}

	public void TurnRedLever(){

		if(levelManager.isRow1Done == true && levelManager.isSecondRowDone == true){

			transform.localPosition = new Vector3(transform.localPosition.x,-45, transform.localPosition.z);
			transform.localEulerAngles = new Vector3(-180,-transform.localRotation.y, transform.localRotation.z);
			StartCoroutine ("WaitAndCloseEnegyPanel");
		}

	}

	IEnumerator WaitAndResetButtons(int row){

		yield return new WaitForSecondsRealtime (0.3f);

		if(row == 1){

			foreach (GameObject button in firstRowButtons) {

				button.transform.localPosition = new Vector3(button.transform.localPosition.x,201, button.transform.localPosition.z);
				EnergyPanel buttonController = button.GetComponent<EnergyPanel> ();
				buttonController.squarebuttonMoved = false;	
				Image imageButton = button.transform.GetChild(0).GetComponent<Image>();
				imageButton.color = Color.grey;
				levelManager.energPanelButtonRequired = 1;
			}
		}

		if(row == 2){

			energyPanelController.ResetSecondRowButtons ();
		}

	}

	IEnumerator WaitAndCloseEnegyPanel(){

		yield return new WaitForSecondsRealtime (0.3f);

		levelManager.EnergyPanelDone ();
	}


}
