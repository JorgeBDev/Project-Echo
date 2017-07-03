using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Please have in mind that this was my first big unity videogame. Some parts of the code are not properly done according to nice performance because I was just starting.
//This code is not cleaned and there are many lines that do nothing. Besides, I know that making variables public is not quite correct. I've worked on that on my new projects.


public class GameController : MonoBehaviour
{
	public int level = 1;
	public GameObject player;
	public Vector3 playerPosition;
	public Vector3 lastPlacePres;
	public Vector3 lastPlacePast;
	public int moment = 1;
	//
	public GameObject alexSpectre;
	//
	float yVanished1 = 433.8f; //antes era 433.8f
	//
	float posicionYPastFloor;
	//
	public float yVanished2 = 1.30f; //antes era 1.30f
	bool gameStarted = true;
	public int shotsNumber = 2;
	public GameObject canTravelObj1;
	public GameObject canTravelObj2;
	public GameObject savedCanTravelObj1;
	public GameObject savedCanTravelObj2;
	public bool firstShot = false;
	public bool canSwap = false;
	public bool swapped = false;
	public CharacterBehaviour playerStats;
	public Vector3 obj1position;
	public Vector3 savedObj1position;
	public HUD hud;
	//
	public bool CanStartShotProcess = true;
	public bool timeReset = false;
	public bool timeIsRunning = false;
	public bool canReset = true;

	//
	private float cooldownTime = 2.0f;
	private float timeStamp;
	//
	float maxDistance = 8000.0f; //ENCONTRAR LA MEDIDA
	//
	public bool switchOffHalo = false;
	// 
	//public Image inventory;
	public GameObject inventory;
	public ItemNeeded itemNeeded;
	public Text itemDescription;
	public Image itemIcon;


	bool justTravel = false;

	CanTravelObject obj1nameReference;

	public bool ableToTravel = true;
	public GameObject[] itemSlots;

	string[] itemsInInventory;
	public Inventory inventoryScript;

	public float secondsWait = 0.1f; //LA COMENTO EL 5/6 PORQUE NO SE UTILIZA. CREO
	public bool waitEnded = false;
	public GameObject travelSpritesGo, travelFlare;
	PlaySprite travelSprite;

	bool inPause,alreadyDone = false;

	public GameObject cameraQuad,timeBarAndShots,dialogueBox,pauseExitMenu,tutorialPanel,nextTutorial,closeTutorial,iconsTutorial,inventoryTutorial,takeHideAndUse,takeHide,use;
	int tutorialStep = 0;
	public Text tutorialText,projectEcho,correspondingInformation;
	public AlexDialogueLvl_1andTutorial alexDialogue;
	float waitingSeconds = 1.5f;
	public bool onTutorial = true;
	bool auxProjectEchoTutorial = false; 
	string toTutorial;

	public bool firstTimeHiding = false;
	public bool tutorialLock = true;
	public GameObject getCardIcon,plantPotsIcons;

	//
	public GameObject toPointGameObject;
	public bool accessCardAddedAux,maintenanceKeyAux = false;
	//Use this for initialization
	void Start ()
	{
		playerStats = player.GetComponent<CharacterBehaviour>();
		hud = gameObject.GetComponent<HUD>();
		travelSprite = travelSpritesGo.GetComponent<PlaySprite>();

		if(level == 2){

			Debug.Log ("FUNCIONA VANISHED Y");
			yVanished2 = -3.1f;
			yVanished1 = -10.4f;
		}

		alexDialogue = player.GetComponent<AlexDialogueLvl_1andTutorial> ();

		if(level == 2){
			onTutorial = false;
		}

	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Escape) && alreadyDone == false){


			if(inPause == true && alreadyDone == false){
				Debug.Log ("FUNCIONA quitar pause");
				inPause = false;
				ShowEscapeWindow (false);
				alreadyDone = true;
			}

			if(inPause == false && alreadyDone == false){

				Debug.Log ("FUNCIONA pause");
				inPause = true;
				ShowEscapeWindow (true);
				alreadyDone = true;
			}

			alreadyDone = false;


		}

		playerPosition = player.transform.position;

		if(Input.GetKeyDown (KeyCode.E) && playerStats.onJump == false && timeStamp <= Time.time && Time.timeScale == 1 && !dialogueBox.activeInHierarchy){

			if(ableToTravel == true){

				inventoryScript.itemPlacementCounter = 0;
				travelFlare.SetActive (true);

				playerStats.PlayAlexAnim ("Travel");
				travelSprite.PlaySpriteAnim ();
				StartCoroutine ("WaitForAnimation","Travel");
				//TravelMethod ();
			}else{

				Debug.Log("UNABLE TO TRAVEL");
			}


			if(alexDialogue.stringIndex == 10){

				if(auxProjectEchoTutorial == false){

					StartCoroutine ("WaitForTutorial","ProjectEcho");
					auxProjectEchoTutorial = true;
				}

			}



		}



		TimeShots ();

		if (Input.GetKeyDown (KeyCode.F) && canSwap && Time.timeScale == 1) {

			Debug.Log ("CAMBIO");
			obj1position = canTravelObj1.transform.position;
			canTravelObj1.transform.position = canTravelObj2.transform.position;
			canTravelObj1.gameObject.tag = ("LevelPast");
			canTravelObj2.transform.position = obj1position;
			canTravelObj2.gameObject.tag = ("LevelPresent");
			swapped = true;
			hud.ChangeSquareColors (3);
			canTravelObj1 = null;
			canTravelObj2 = null;
			canSwap = false;
			shotsNumber = 2;
			firstShot = false;

		}



		if(Input.GetKeyDown(KeyCode.R) && canReset == true && !dialogueBox.activeInHierarchy){

			switch (timeReset) {
			case true:
				//timeReset = false;
				break;
			case false:
				timeReset = true;
				//hud.ResetHighlight ();
				ableToTravel = false;
				canReset = false;
				timeIsRunning = false;
				canTravelObj1 = null;
				canTravelObj2 = null;
				//savedCanTravelObj1 = null;
				//savedCanTravelObj2 = null;
				firstShot = false;
				shotsNumber = 2;
				if(moment == 0){
					Vanished2 ();
					moment = 1;
				}
				break;
			}


		}


		if(Input.GetKeyDown(KeyCode.I) && Time.timeScale == 1 && !dialogueBox.activeInHierarchy){
			Inventory ();
		}

	}

	public void Vanished1 ()
	{	
		travelFlare.SetActive (false);

		lastPlacePres = playerPosition;

		if (gameStarted) {
			player.transform.position = new Vector3 (lastPlacePres.x, yVanished1, lastPlacePres.z);
			gameStarted = false;

			alexSpectre.transform.position = lastPlacePres;
		} else {

			player.transform.position = lastPlacePast;
			//
			alexSpectre.transform.position = lastPlacePres;
			//alexSpectre.transform.position = player.transform.position;
		}

	}

	public void Vanished2 ()
	{
		travelFlare.SetActive (false);

		lastPlacePast = player.transform.position;
		player.transform.position = lastPlacePres;

		alexSpectre.transform.position = lastPlacePast;

	}


	public void TimeShots ()
	{
		if (Input.GetMouseButtonDown (0) && Time.timeScale == 1) {

			Ray toMouse = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit rhInfo;
			bool didHit = Physics.Raycast (toMouse, out rhInfo, 1000.0f); //EL ULTIMO VALOR ESTABA EN 500.0F
			if (didHit) {
				//Debug.Log (rhInfo.collider.name + ("..." + rhInfo.point)); COMENTADO EL 24/4/1017 PARA QUE NO MOLESTE EN CONSOLE
				CanTravelObject canTravelObj = rhInfo.collider.GetComponent<CanTravelObject> ();
				if (canTravelObj && timeReset == false) {
					playerStats.PlayAlexAnim ("shot");
					if (moment == 1) {

						//WaitForAnimation ();
						//StartCoroutine("WaitForAnimation","shot"); 28/3/2017. HE COMENTADO ESTA LINEA
						playerStats.PlayAlexAnim ("Shot");

						if (!firstShot) {
							if (rhInfo.collider.gameObject.CompareTag ("LevelPresent") && Vector3.Distance(rhInfo.collider.transform.position,player.transform.position) < maxDistance) {

								canTravelObj1 = rhInfo.collider.gameObject;
								obj1nameReference = canTravelObj1.GetComponent<CanTravelObject> ();
								//HighlightObject highLight1 = canTravelObj1.GetComponent<HighlightObject> ();
								//highLight1.activateHighLight = true;
								savedCanTravelObj1 = rhInfo.collider.gameObject;
								firstShot = true;
								hud.ChangeSquareColors (1);
								timeIsRunning = true;
								CanStartShotProcess = false;
								shotsNumber = 1;
							}

							if (rhInfo.collider.gameObject.CompareTag ("LevelPast")) {

								Debug.Log ("Debes empezar por el level 1");
							}


						}

						if (firstShot) {

							if (rhInfo.collider.gameObject.CompareTag ("LevelPresent")) {

								Debug.Log ("Ya has disparado en el presente");
							}

							if (rhInfo.collider.gameObject.CompareTag ("LevelPast")) {

								Debug.Log ("Imposible realizarlo desde aqui");
							}


						}

					}

					if (moment == 0) {

						if (!firstShot) {

							if (rhInfo.collider.gameObject.CompareTag ("LevelPresent")) {

								Debug.Log ("Debes subir para realizar la accion");

							}

							if (rhInfo.collider.gameObject.CompareTag ("LevelPast")) {

								Debug.Log ("Debes empezar por el level 1");
							}


						}

						if (firstShot) {

							if (rhInfo.collider.gameObject.CompareTag ("LevelPresent")) {

								Debug.Log ("Ya ha habido un disparo en el presente");
							}

							if (rhInfo.collider.gameObject.CompareTag ("LevelPast") && Vector3.Distance(rhInfo.collider.transform.position,player.transform.position) < maxDistance && canTravelObj.objectName == obj1nameReference.objectName) {
								playerStats.PlayAlexAnim ("Shot");
								canTravelObj2 = rhInfo.collider.gameObject;
								//HighlightObject highLight2 = canTravelObj1.GetComponent<HighlightObject> ();
								//highLight2.activateHighLight = true;
								savedCanTravelObj2 = rhInfo.collider.gameObject;
								hud.ChangeSquareColors (2);
								shotsNumber = 0;
								canSwap = true;
							}


						}

					}




				} else {
					//Debug.Log ("NO TRAVEL OBJECT"); COMENTADO EL 24/4/1017 PARA QUE NO MOLESTE EN CONSOLE
				}

			} else {
				//Debug.Log ("Clicked on Empty Space");
			}
		}


	}



	public void ResetObjectPositions(){
		//hud.ResetHighlight ();

		savedObj1position = savedCanTravelObj1.transform.position;
		savedCanTravelObj1.transform.position = savedCanTravelObj2.transform.position;
		savedCanTravelObj1.gameObject.tag = ("LevelPresent");
		savedCanTravelObj2.transform.position = savedObj1position;
		savedCanTravelObj2.gameObject.tag = ("LevelPast");
		swapped = false;
		canSwap = true;
		savedCanTravelObj1 = null;
		savedCanTravelObj2 = null;
		switchOffHalo = true;

	}


	public bool Inventory(){

		itemDescriptionNull ();

		//inventoryScript.SlotsHaveChildren ();
		bool isInventoryActive = inventory.activeInHierarchy;
		inventory.gameObject.SetActive (!isInventoryActive);
		//inventoryScript.SlotsHaveChildren ();//COMENTADO EL 18/5
		return !isInventoryActive;

	}


	IEnumerator WaitForAnimation(string action){
		for(bool a=true;a==true;a=false){
			//Debug.Log ("" + playerStats.canIdle);
			playerStats.canIdle = false;
			yield return new WaitForSecondsRealtime (0.5f); //antes estaba en 0.5
		}
		if(action == "Travel"){
			TravelMethod ();
		}
		if(action == "shot"){
			Debug.Log ("skdlasdnk");
		}
		playerStats.canIdle = true;

	}

	void TravelMethod(){
		//Debug.Log ("TRAVELMETHOD");
		if (ableToTravel == true) {

			timeStamp = Time.time + cooldownTime;
			//
			itemDescriptionNull ();
			//

			if(toPointGameObject != null){

				CancelGoToPointInteraction ();
			}

			//playerStats.PlayAlexAnim ("Travel");

			if (moment == 1 && ableToTravel == true) {

				inventoryScript.DeleteChildren ();
				inventoryScript.LoadItemsInMoment ("Past");
				Vanished1 ();

				if (shotsNumber == 2) {
					timeIsRunning = true;
					justTravel = true;
				}


			}

			if (moment == 0 && ableToTravel == true) {
				//inventoryScript.LoadItemsInMoment ("Present");
				inventoryScript.NullItemsInInventory("Present");
				inventoryScript.LoadItemsInMoment ("Present");
				Vanished2 ();
				//
				//inventoryScript.NullItemsInInventory("Present");
				//
				if (justTravel == true && shotsNumber == 2) {
					justTravel = false;
					timeIsRunning = false;
					timeReset = true;

				}
			}

			switch (moment) {

			case 0:
				moment = 1;
				break;
			case 1:
				moment = 0;
				break;

			}
		} else {
			Debug.Log ("Tienes objetos");
		}

	}

	void ShowEscapeWindow(bool show){

		if (show == true) {
			Time.timeScale = 0;
			cameraQuad.SetActive (true);
			pauseExitMenu.SetActive (true);
			timeBarAndShots.SetActive (false);

			if(!dialogueBox.gameObject.activeInHierarchy){

				dialogueBox.SetActive (false);
			}



		} else {
			Time.timeScale = 1;
			cameraQuad.SetActive (false);
			pauseExitMenu.SetActive (false);
			timeBarAndShots.SetActive (true);

		}


	}

	public void ToMainMenu(){

		SceneManager.LoadScene ("MainMenu");
	}

	public void ExitPause(){
		Time.timeScale = 1;
		cameraQuad.SetActive (false);
		pauseExitMenu.SetActive (false);
		timeBarAndShots.SetActive (true);
		inPause = false;
	}

	public void ShowTutorialPanel(){

		tutorialPanel.SetActive (true);
		tutorialText.text = "Project Echo";
		projectEcho.gameObject.SetActive (true);
		closeTutorial.SetActive (false);

		if(!nextTutorial.activeInHierarchy){
			nextTutorial.SetActive (true);
		}

		if(onTutorial){
			tutorialStep++;
		}
	}

	public void HideTutorialPanel(){

		tutorialPanel.SetActive (false);
	}

	public void ChangeTutorial(){

		if(onTutorial == false){

			tutorialStep++;
		}


		if(tutorialStep == 1){

			if(onTutorial == true){
				nextTutorial.SetActive (false);
				closeTutorial.SetActive (true);
				onTutorial = false;
			}

			projectEcho.gameObject.SetActive (false);
			iconsTutorial.SetActive (true);
			tutorialText.text = "Icons";
		}	

		if(tutorialStep == 2){

			iconsTutorial.SetActive (false);
			inventoryTutorial.SetActive (true);
			tutorialText.text = "Inventory";
			correspondingInformation.text = "This is your inventory. The slots in the left are your item slots. They hold the items you pick and have in you inventory. If you select them you can see a brief description of them. Maybe it could give you a clue about their use";


			if(onTutorial == true){

				Debug.Log ("ON TUTORIAL");
				closeTutorial.SetActive (false);
				nextTutorial.SetActive (true);
				toTutorial = "UseSlot";
			}


		}

		if(tutorialStep == 3){

			inventoryTutorial.SetActive (false);
			takeHideAndUse.SetActive (true);
			tutorialText.text = "Take/Hide and Use Slot";
			correspondingInformation.text = "The slots Take/Hide and Use are essential in your adventure. \nThey appear in your inventory panel when you interact          with the level. Their function is activated when you drop an item inside.";

		}

		if(tutorialStep == 4 ){

			takeHideAndUse.SetActive (false);
			takeHide.SetActive (true);
			tutorialText.text = "Take/Hide Slot";
			correspondingInformation.text = "The Take/Hide slot appears when you interact         with an object.\nIt is used to hide items and then recover them. \n\nIf you are in the past and you drag and drop an item in the Take/Hide slot you HIDE the item. That same item can be recovered in the present if you search in the SAME prop you hid it and drag it back tou your inventory.";

			if(onTutorial == true){

				nextTutorial.SetActive (false);
				closeTutorial.SetActive (true);
				onTutorial = false;
			}
		}

		if(tutorialStep == 5){

			takeHide.SetActive (false);
			use.SetActive (true);
			tutorialText.text = "Use Slot";
			correspondingInformation.text = "The Use item slot appears in your inventory panel when you interact\nwith the level and can use an item to get over and obstacle or unlock \na new event to keep forward in your adventure. \n\nTo use an item you have to drag and drop it in the Use Slot. If it's the correct one, something will happen. If not,the item gets back to its item slot";

		}

		if(tutorialStep == 6){

			use.SetActive (false);
			tutorialPanel.SetActive (false);
			tutorialText.text = "";
			correspondingInformation.text = "";
			tutorialStep = 0;

		}
		//ÑAPA. QUERIA PASAR DE INVENTORY A USE SLOT

		if(toTutorial == "UseSlot" && auxProjectEchoTutorial == true && onTutorial == true){


			inventoryTutorial.SetActive (false);
			use.SetActive (true);
			tutorialText.text = "Use Slot";
			correspondingInformation.text = "The Use item slot appears in your inventory panel when you interact\nwith the level and can use an item to get over and obstacle or unlock \na new event to keep forward in your adventure. \n\nTo use an item you have to drag and drop it in the Use Slot. If it's the correct one, something will happen. If not,the item gets back to its item slot";

			nextTutorial.SetActive (false);
			closeTutorial.SetActive (true);
			onTutorial = false;

		}

		auxProjectEchoTutorial = true;

	}

	public void CloseTutorial(){

		tutorialPanel.SetActive (false);
		projectEcho.gameObject.SetActive (true); //para que aparezca cuand volvamos a abrirlo

		use.SetActive (false);
		takeHide.SetActive (false);
		takeHideAndUse.SetActive (false);
		inventoryTutorial.SetActive (false);
		iconsTutorial.SetActive (false);

		tutorialText.text = "";
		correspondingInformation.text = "";
		tutorialStep = 0;

		if(onTutorial == true){

			onTutorial = false;
		}
	}

	IEnumerator WaitForTutorial (string tutorial)
	{

		yield return new WaitForSecondsRealtime (waitingSeconds);

		if(tutorial == "ProjectEcho"){

			//alexDialogue.OpenTriggeredTutorial (tutorial);
			ShowTriggeredTutorial(tutorial);
		}


	}

	public void ShowTriggeredTutorial(string tutorial){

		if(tutorial == "ProjectEcho"){

			ShowTutorialPanel ();


		}

		if(tutorial == "InventoryAndUseSlot"){

			onTutorial = true;
			tutorialPanel.SetActive (true);
			projectEcho.gameObject.SetActive (false);
			inventoryTutorial.SetActive (true);
			auxProjectEchoTutorial = false;
			tutorialStep = 2;
			ChangeTutorial ();
		}

		if(tutorial == "HideSlot"){

			onTutorial = true;
			tutorialPanel.SetActive (true);
			projectEcho.gameObject.SetActive (false);
			tutorialStep = 4;
			ChangeTutorial ();
		}
	}

	public void ShowTutorialLockedIcon(string icon){
		if(icon == "GetCardIcon"){

			getCardIcon.SetActive (true);
		}

		if(icon == "PlantPotIcons"){

			plantPotsIcons.SetActive (true);
		}
	}

	public void UpdateGotoPointGo(GameObject newGotoPointGo){

		Debug.Log ("OhShitWaddap");
		toPointGameObject = newGotoPointGo;
	}

	public void CancelGoToPointInteraction(){

		playerStats.CancelRunAnimation ();

		if(toPointGameObject.CompareTag("ItemNeeded")){

			ItemNeeded itemNeeded = toPointGameObject.GetComponent<ItemNeeded> ();
			itemNeeded.moveToClosePosition = false;
			playerStats.goingToPoint = false;
		}

		if(toPointGameObject.CompareTag("Observation")){

			Observation observation = toPointGameObject.GetComponent<Observation> ();
			observation.moveToClosePosition = false;
			playerStats.goingToPoint = false;
		}

	}

	public void itemDescriptionNull(){

		itemDescription.text = "";
		itemIcon.sprite = null;
		itemIcon.gameObject.SetActive (false);
	}

}