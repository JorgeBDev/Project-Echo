using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlexDialogueLvl_1andTutorial : MonoBehaviour
{

	public GameController gameController;
	public bool onAlexDialogue;
	bool auxiliarIndex = false;
	public GameObject dialogueBox, logo;
	public Text dialogueText, talker;

	public string[] strings;
	// array de lineas de textos
	public float dialogueSpeed = 0.05f;
	public int stringIndex = 0;
	public int characterIndex = 0;

	public int block = 0;

	LevelManager levelManager;

	//
	public GameObject tutorialPanel,closeTutorial,nextTutorial,welcomeToProjectEchoText;
	public Text tutorialName;

	//

	// Use this for initialization
	void Start ()
	{

		talker.text = "Alex";
		StartOfTheGame ();
		levelManager = gameController.gameObject.GetComponent<LevelManager> ();

		Vector3 startingPosition = gameObject.transform.position;

	}

	// Update is called once per frame
	void Update ()
	{
		//Debug.Log ("BLOCK ES: " + block);

		if (onAlexDialogue == true && (Input.GetKeyDown (KeyCode.Mouse0) && !tutorialPanel.activeInHierarchy)) {

			if (characterIndex < strings [stringIndex].Length) {

				characterIndex = strings [stringIndex].Length;

			} else if (stringIndex < strings.Length) {

				stringIndex++;
				characterIndex = 0;
				logo.SetActive (false);

				ScriptMoment ();

			}
		}
		if (block == 1 && Input.GetKey (KeyCode.E)) {

			block = 2;
			stringIndex++;
			Block2 ();

		}
		if (block == 2 && gameController.moment == 1) {

			//Debug.Log ("WADDA LA DAD BAB");
		}

		/*
		if (block == 4 && Input.GetKey (KeyCode.E)) {

			stringIndex++;
			Block4 ();
		}
		*/

		if (block == 4 && Input.GetKey (KeyCode.E)) {

			//WaitForFirstCard
			StartCoroutine("WaitForFirstCard");
			block++;

		}

		/*
		if (block == 5 && Input.GetKey (KeyCode.E)) {
			Block5 ();
		}
		*/
	}

	void StartOfTheGame ()
	{

		onAlexDialogue = true;
		block = 1;
		stringIndex = 0;
		characterIndex = 0;
		StartCoroutine ("DisplayTimer");
	}

	void Block2 ()
	{

		StartCoroutine ("WaitForText");
	}

	void Block4 ()
	{

		stringIndex++;
		onAlexDialogue = true;
		dialogueBox.SetActive (true);
		characterIndex = 0;
		block = 5; //AQUI PASO A LO DE QUE NO PUEDE VIAJAR CON TARJETA
		StartCoroutine ("DisplayTimer");

	}

	void Block5 ()
	{

		//stringIndex++;
		stringIndex = 16;
		onAlexDialogue = true;
		dialogueBox.SetActive (true);
		characterIndex = 0;
		block = 6; //AQUI PASO A LO DE QUE NO PUEDE VIAJAR CON TARJETA
		StartCoroutine ("DisplayTimer");
	}


	void ScriptMoment ()
	{

		switch (stringIndex) {

		case 3:

			talker.text = "Tutorial";
			break;

		case 4:

			talker.text = "Alex";
			dialogueBox.SetActive (false);
			onAlexDialogue = false;
			auxiliarIndex = true;
			break;

		case 8:

			talker.text = "Tutorial";
			break;

		case 10:

			dialogueBox.SetActive (false);
			onAlexDialogue = false;
			auxiliarIndex = true;
			break;

		case 11:

			talker.text = "Alex";
			gameController.ShowTriggeredTutorial ("InventoryAndUseSlot");
			break;

		case 12:

			talker.text = "Tutorial";
			break;

		case 13:

			dialogueBox.SetActive (false);
			onAlexDialogue = false;

			gameController.ShowTutorialLockedIcon ("GetCardIcon");
			break;

		case 14:

			talker.text = "Alex";
			break;

		case 15:
			dialogueBox.SetActive (false);
			onAlexDialogue = false;
			break;

		case 17:

			talker.text = "Tutorial";
			break;

		case 18:

			talker.text = "Alex";
			break;

		case 21:
			dialogueBox.SetActive (false);
			onAlexDialogue = false;

			gameController.ableToTravel = true; //ESTA LINEA ES PARA DESBLOQUEAR EL VIAJE TRAS EXPLICAR EL DOBLE INVENTARIO
			break;

		case 23:
			dialogueBox.SetActive (false);
			onAlexDialogue = false;
			break;

		case 25:
			dialogueBox.SetActive (false);
			onAlexDialogue = false;
			break;

		case 27:
			dialogueBox.SetActive (false);
			onAlexDialogue = false;
			break;


		case 30:

			dialogueBox.SetActive (false);
			onAlexDialogue = false;
			break;

		case 32:

			talker.text = "Woman 2";
			break;

		case 33:

			talker.text = "Woman 1";
			break;

		case 34:

			talker.text = "Woman 2";
			break;

		case 35:

			talker.text = "Woman 1";
			break;

		case 36:

			talker.text = "Woman 2";
			break;

		case 37:

			talker.text = "Woman 1";
			break;

		case 38:

			talker.text = "Woman 2";
			break;

		case 39:
			dialogueBox.SetActive (false);
			onAlexDialogue = false;
			levelManager.CanGetMaintenanceKey ();
			break;

		case 41:
			dialogueBox.SetActive (false);
			onAlexDialogue = false;
			break;

		case 43:
			dialogueBox.SetActive (false);
			onAlexDialogue = false;
			break;

		case 45:
			dialogueBox.SetActive (false);
			onAlexDialogue = false;
			break;

		}
	}

	public void AlexsObservations (string about)
	{

		if (about == "FirstDoor") {

			onAlexDialogue = true;
			dialogueBox.SetActive (true);
			stringIndex = 11;
			characterIndex = 0;
			block = 3;
			StartCoroutine ("DisplayTimer");
		}

		if (about == "FirstCard") {
			stringIndex++;
			onAlexDialogue = true;
			dialogueBox.SetActive (true);
			stringIndex = 16;
			characterIndex = 0;
			//block = 4;
			StartCoroutine ("DisplayTimer");

		}

		if (about == "NoMoney") {

			onAlexDialogue = true;
			dialogueBox.SetActive (true);
			stringIndex = 22;
			characterIndex = 0;
			StartCoroutine ("DisplayTimer");
		}

		if (about == "MoneyFound") {

			onAlexDialogue = true;
			dialogueBox.SetActive (true);
			stringIndex = 24;
			characterIndex = 0;
			StartCoroutine ("DisplayTimer");
		}

		if (about == "Coffee") {

			onAlexDialogue = true;
			dialogueBox.SetActive (true);
			stringIndex = 26;
			characterIndex = 0;
			StartCoroutine ("DisplayTimer");
		}

		if(about == "PrivateConversationComing"){

			onAlexDialogue = true;
			dialogueBox.SetActive (true);
			stringIndex = 28;
			talker.text = "Surroundings";
			characterIndex = 0;
			StartCoroutine ("DisplayTimer");
		}

		if (about == "PrivateConversation") {

			onAlexDialogue = true;
			dialogueBox.SetActive (true);
			stringIndex = 31;
			talker.text = "Woman 1";
			characterIndex = 0;
			StartCoroutine ("DisplayTimer");
		}

		if (about == "DestroyDebris") {

			onAlexDialogue = true;
			dialogueBox.SetActive (true);
			stringIndex = 44;
			characterIndex = 0;
			StartCoroutine ("DisplayTimer");
		}

		if (about == "MaintenanceKey") {

			onAlexDialogue = true;
			dialogueBox.SetActive (true);
			stringIndex = 40;
			characterIndex = 0;
			StartCoroutine ("DisplayTimer");
		}


		if (about == "Screwdriver") {

			onAlexDialogue = true;
			dialogueBox.SetActive (true);
			stringIndex = 42;
			characterIndex = 0;
			StartCoroutine ("DisplayTimer");
		}

	}

	IEnumerator DisplayTimer ()
	{

		//Debug.Log ("EN DISPLAY TIMER");
		//while (1 == 1) {
		while (onAlexDialogue == true) {
			yield return new WaitForSeconds (dialogueSpeed);

			if (characterIndex > strings [stringIndex].Length) {

				continue;
			}

			dialogueText.text = strings [stringIndex].Substring (0, characterIndex);
			characterIndex++;
			//onAlexDialogue = true; //pongo esto para esperar un poco en el tiempo de ejecucion. 


			if (characterIndex >= strings [stringIndex].Length) {

				logo.SetActive (true);

			}

		}
	}

	IEnumerator WaitForText ()
	{

		yield return new WaitForSeconds (1.2f);

		onAlexDialogue = true;
		dialogueBox.SetActive (true);
		characterIndex = 0;
		StartCoroutine ("DisplayTimer");

	}

	//ÑAPA
	IEnumerator WaitForFirstCard ()
	{

		yield return new WaitForSeconds (1.5f);

		AlexsObservations ("FirstCard");
		gameController.Inventory ();


	}
	//ÑAPA

	public void PropObservation (string propName)
	{

		if (propName == "TeddyBear") {

			dialogueText.text = "It is a Teddy Bear. It probably belonged to a child. But I don't hear her mother.";
		}

		if (propName == "Elevator") {

			dialogueText.text = "I know that icon. It will lead me to MAMA. Ummmm...The power does not seem to be working. I have to find the power panel. I'm so close";
		}

		if (propName == "FirstDoor") {

			dialogueText.text = "It is closed. I need some sort of card. There's gotta be one here...or back then";
		}

		if (propName == "EntranceDoor") {

			dialogueText.text = "It is blocked. I don't think this could be opened anymore";
		}

		if (propName == "PastEntranceDoor") {

			dialogueText.text = "I shouldn't. MAMA said I shouldn't get outside...I always have to get her permission first. She won't allow me to keep her company after this...But it was not my fault. I did as she said";
		}

		if (propName == "CoinFalse") {

			dialogueText.text = "No money here. I must keep searching";
		}

		if (propName == "CoffeeMachine") {

			dialogueText.text = "Never been a fan of coffee. It kept me awake.";
		}

		if (propName == "NotWorkingCoffeeMachine") {

			dialogueText.text = "No! The coffe machine is not working...Why is there always something on my way? I have to bring the coffee this guy needs. Otherwise the path will be forever blocked";
		}


	}

	public void ShowHideTextBox (bool show)
	{

		if (show == true) {
			dialogueBox.SetActive (true);

		} else {

			dialogueBox.SetActive (false);
		}
	}


	public void CloseTriggeredTutorial(){

		tutorialPanel.SetActive (false);
		closeTutorial.SetActive (false);
		nextTutorial.SetActive (true);
		welcomeToProjectEchoText.SetActive (true);
		tutorialName.text = "";
	}
}

