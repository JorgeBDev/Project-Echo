using UnityEngine;
using System.Collections;

public class InteractiveObject : MonoBehaviour
{

	public GameObject player;

	public Inventory inventory;

	public GameObject pressEToInteract;

	bool elevatorpressed = false;

	GameObject gameControllerGo;
	GameController gameController;

	public AlexDialogueLvl_1andTutorial alexsMonologue;
	bool isOn, isPlayerClose;

	Color goColor;
	SpriteRenderer goRenderer;

	/*
	ImportandoScript de acercarse
	*/

	public GameObject closePosition;
	public CharacterBehaviour characterBehaviour;
	public float closePositionDistance = 200;
	//2
	public float moveSpeed = 50;
	public bool moveToClosePosition = false;

	// Use this for initialization
	void Start ()
	{

		//inventory = GetComponent<Inventory> ();
		gameControllerGo = GameObject.FindGameObjectWithTag ("GameController");
		gameController = gameControllerGo.GetComponent<GameController> ();

		goRenderer = GetComponent<SpriteRenderer> ();

		characterBehaviour = player.GetComponent<CharacterBehaviour> ();
	}

	// Update is called once per frame
	void Update ()
	{

		GetToItem ();

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

	void GetToItem ()
	{


		if (isOn && Input.GetKeyDown (KeyCode.Mouse0)) {

			if (Vector3.Distance (closePosition.transform.position, player.transform.position) < closePositionDistance) {

				if (gameObject.name.Contains ("AccessCard") && inventory.card1 == false) {

					inventory.card1 = true;
					inventory.AddItem ("AccessCard", true);//añado item a el hud de inventario

					if (alexsMonologue.stringIndex >= 9) {

						//alexsMonologue.AlexsObservations ("FirstCard");
						//gameController.ableToTravel = false;
						alexsMonologue.block++;
						gameController.ShowTutorialLockedIcon ("PlantPotIcons");
					}


					Destroy (gameObject);

				}

				if (gameObject.name.Contains ("Stethoscope")) {

					inventory.AddItem ("Stethoscope", true);//añado item a el hud de inventario
					Destroy (gameObject);

				}

				if (gameObject.name.Contains ("CoinFalse")) {

					alexsMonologue.AlexsObservations ("NoMoney");
					Destroy (gameObject);

				}

				if (gameObject.name.Contains ("CoinTrue")) {

					alexsMonologue.AlexsObservations ("MoneyFound");
					inventory.AddItem ("Coin",true);
					Destroy (gameObject);

				}

				if (gameObject.name.Contains ("Coffee")) {

					alexsMonologue.AlexsObservations ("Coffee");
					inventory.AddItem ("Coffee",true);
					Destroy (gameObject);

				}

				if (gameObject.name.Contains ("MaintenanceKey")) {

					alexsMonologue.AlexsObservations ("MaintenanceKey");
					inventory.AddItem ("MaintenanceKey",true);
					Destroy (gameObject);

				}

				if (gameObject.name.Contains ("Screwdriver")) {

					alexsMonologue.AlexsObservations ("Screwdriver");
					inventory.AddItem ("Screwdriver",true);
					Destroy (gameObject);

				}

			} else {

				moveToClosePosition = true; //COMENTADO PARA METERLO EN EL IF
			}
		}
		if (moveToClosePosition == true && Vector3.Distance (closePosition.transform.position, player.transform.position) > closePositionDistance) {

			player.transform.position = Vector3.MoveTowards (player.transform.position, new Vector3 (closePosition.transform.position.x, player.transform.position.y, closePosition.transform.position.z), moveSpeed * Time.deltaTime);
			Debug.Log ("MOVIENDOSE AL OBJETIVO");


			//Vector3 elnuevo =Vector3.Scale(closePosition.transform.position, new Vector3(1,0,1))

			//ESTA LINEA DE ARRIBA LA HIZO BEÑAT. MULTIPLICA VECTORES. SI PONES EN UNO "0", EL VALOR CON EL QUE MULTILPIQUE SERÁ 0

			characterBehaviour.LookTowards (closePosition.transform);
			characterBehaviour.GoToPoint (true);
		}

		if (Vector3.Distance (closePosition.transform.position, player.transform.position) < closePositionDistance) {

			characterBehaviour.goingToPoint = false;
			characterBehaviour.GoToPoint (false);
			//Debug.Log ("PARAAAAAAA");

		}

		if (moveToClosePosition == true && Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D)) {
			moveToClosePosition = false;
		}

		if (Vector3.Distance (closePosition.transform.position, player.transform.position) < closePositionDistance) {

			isPlayerClose = true;
			//Debug.Log ("PLAYER CLOSSSE");
		} else {

			isPlayerClose = false;
		}
	}

}

