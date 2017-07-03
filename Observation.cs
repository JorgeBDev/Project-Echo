using UnityEngine;
using System.Collections;

public class Observation : MonoBehaviour {

	bool isOn = false;
	bool showObservation,auxiliarShow; //AuxiliarShow es para saber si un PropObsevation ha puesto On el textBox
	AlexDialogueLvl_1andTutorial alexObservation;
	GameObject player;
	GameController gameController;

	public GameObject interactIcon;
	public string propName;

	Color goColor;
	SpriteRenderer goRenderer;

	bool isPlayerClose;
	public GameObject closePosition;
	public CharacterBehaviour characterBehaviour;
	public float closePositionDistance = 0.5f; //2
	public float moveSpeed = 3;
	public bool moveToClosePosition = false;

	// Use this for initialization
	void Start () {


		player = GameObject.FindGameObjectWithTag ("Player");
		alexObservation = player.GetComponent<AlexDialogueLvl_1andTutorial> ();

		goRenderer= GetComponent<SpriteRenderer> ();
		characterBehaviour = player.GetComponent<CharacterBehaviour> ();
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {

		GetToObservation ();
	}

	void OnMouseOver ()
	{
		isOn = true;

		if (isOn == true) {
			goColor = goRenderer.color;
			goColor.a = 1.0f;
			goRenderer.color = goColor;

		}
	}

	void OnMouseExit ()
	{
		isOn = false;

		goColor = goRenderer.color;
		goColor.a = 0.5f;
		goRenderer.color = goColor;
		if(auxiliarShow == true){

			auxiliarShow = false;
			alexObservation.ShowHideTextBox (false);
		}
	}

	public void ShowHideInteractIcon(bool show)
	{

		if (show == true) {
			interactIcon.SetActive (true);

		} else {

			interactIcon.SetActive (false);
		}
	}

	void PropObservation(){

		switch(propName){

		case "TeddyBear":

			alexObservation.PropObservation ("TeddyBear");
			break;

		case "Elevator":

			alexObservation.PropObservation ("Elevator");
			break;

		case "FirstDoor":

			alexObservation.PropObservation ("FirstDoor");
			break;

		case "EntranceDoor":

			alexObservation.PropObservation ("EntranceDoor");
			break;

		case "PastEntranceDoor":

			alexObservation.PropObservation ("PastEntranceDoor");
			break;

		case "CoffeeMachine":

			alexObservation.PropObservation ("CoffeeMachine");
			break;

		case "NotWorkingCoffeeMachine":

			alexObservation.PropObservation ("NotWorkingCoffeeMachine");
			break;
		}
			
	}

	void GetToObservation(){

		if (isOn && Input.GetKeyDown (KeyCode.Mouse0)) {
			if (Vector3.Distance (closePosition.transform.position, player.transform.position) < closePositionDistance) {

				if (Input.GetKeyDown (KeyCode.Mouse0)) {

					PropObservation ();
					alexObservation.ShowHideTextBox (true);
					auxiliarShow = true;
					if(interactIcon != null){

						ShowHideInteractIcon (true);
					}

				}

			} else {
				
				moveToClosePosition = true; //COMENTADO PARA METERLO EN EL IF
			}
		}
		if (moveToClosePosition == true && Vector3.Distance (closePosition.transform.position, player.transform.position) > closePositionDistance) {

			player.transform.position = Vector3.MoveTowards (player.transform.position, new Vector3( closePosition.transform.position.x,player.transform.position.y, closePosition.transform.position.z ), moveSpeed * Time.deltaTime);


			characterBehaviour.LookTowards (closePosition.transform);
			characterBehaviour.GoToPoint (true);
			//
			gameController.UpdateGotoPointGo(gameObject);
			//
		}

		if(Vector3.Distance (closePosition.transform.position, player.transform.position) < closePositionDistance){

			characterBehaviour.goingToPoint = false;
			characterBehaviour.GoToPoint (false);

		}

		if (moveToClosePosition == true && Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){
			moveToClosePosition = false;
		}

		if (Vector3.Distance (closePosition.transform.position, player.transform.position) < closePositionDistance) {

			isPlayerClose = true;

		} else {

			isPlayerClose = false;
		}
	}
}
