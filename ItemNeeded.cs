using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemNeeded : MonoBehaviour
{

	public GameObject icon;
	public bool isOn = false;
	public GameController gameController;
	public UseSlot useSlot;
	public Inventory inventory;

	public GameObject closePosition;
	public GameObject player;
	public CharacterBehaviour characterBehaviour;
	public float closePositionDistance = 200; //2
	public float moveSpeed = 50;
	public bool moveToClosePosition = false;

	public int level = 1; //Esto es el nivel en el que está el objeto

	public AlexDialogueLvl_1andTutorial alexMonologue;
	bool firstTimeInteraction = true;

	public bool direction2D,isPlayerClose;
	public GameObject observationIcon;

	Color goColor;
	SpriteRenderer goRenderer;
	public GameObject interactIcon;
	// Use this for initialization
	void Start ()
	{
		goRenderer= interactIcon.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		GetToInteraction ();

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
	}

	void GetToInteraction(){
		
		if (isOn && Input.GetKeyDown (KeyCode.Mouse0)) {
			if (Vector3.Distance (closePosition.transform.position, player.transform.position) < closePositionDistance) {

				gameController.Inventory ();
				inventory.canUseObject = true;

				if (gameObject.name == "DoorLock") {
					//Debug.Log ("Funciona");
					useSlot.keyItem = "CardItem";

					if(firstTimeInteraction == true){ // && alexMonologue.stringIndex >= 10

						alexMonologue.AlexsObservations ("FirstDoor");
						firstTimeInteraction = false; //ELIMINADO EL 26/04 PARA NO TRIGGEREAR EL GUION
						gameController.ShowTriggeredTutorial ("InventoryAndUseSlot");
					}
				}

				if (gameObject.name.Contains("SecondDoorLock")) {

					Debug.Log ("TARJETA SEGUNDA PUERTA");
					useSlot.keyItem = "CardItem";
				}

				if (gameObject.name.Contains("CoffeeMachine")) {
					
					useSlot.keyItem = "Coin";
				}

				if (gameObject.name.Contains("NotWorkingCoffeeMachine")) {

					useSlot.keyItem = "Coffee";
				}

				if (gameObject.name.Contains("MaintenanceDoorPresent")) {

					useSlot.keyItem = "MaintenanceKey";
				}

				if (gameObject.name.Contains("MaintenanceDoorPast")) {

					useSlot.keyItem = "Stethoscope";
				}

				if (gameObject.name.Contains("Elevator")) {

					useSlot.keyItem = "MaintenanceKey";
				}

				if (gameObject.name.Contains("Screwdriver")) {

					useSlot.keyItem = "Screwdriver";
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
			Debug.Log ("OhShitWaddap");
			gameController.UpdateGotoPointGo(gameObject);
			//
		}

		if(Vector3.Distance (closePosition.transform.position, player.transform.position) < closePositionDistance){

			characterBehaviour.goingToPoint = false;
			characterBehaviour.GoToPoint (false);
			//Debug.Log ("PARAAAAAAA");

		}

		if (moveToClosePosition == true && Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){
			moveToClosePosition = false;
		}

		if (Vector3.Distance (closePosition.transform.position, player.transform.position) < closePositionDistance) {

			isPlayerClose = true;
			if(observationIcon != null){
				observationIcon.SetActive (true);
			}

			//Debug.Log ("PLAYER CLOSSSE");
		} else {

			isPlayerClose = false;
			if(observationIcon != null){
				observationIcon.SetActive (false);
			}
		}
	}
}
