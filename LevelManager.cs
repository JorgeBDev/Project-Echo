using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public CharacterBehaviour playerAnim;
	public Inventory inventory;
	public TextBoxController textBoxController;
	bool triggerCorrutine = false;
	float wait = 2.0f;

	public PlayAnim animGO;

	public GameObject firstDoor;
	Animator interactionAnimator;
	public bool doorsOpened;

	bool searchingCoin = false;
	bool coffeTaken = false;
	public GameObject coffeeInteraction,searchForCoin,debris,secondDoor;
	//

	public Renderer renTechoRoto;
	public Texture rotoArregado;

	//
	GameObject character;
	public GameObject maintenanceKey,electricityGo,sparks,brokenLightTubes,fixedLightTube,emergencyLights,fixedPresentLights,fixLightInteraction;
	Collider electricityCollider;
	public bool lightPanelDone,firstDoorAux = false;
	public GameObject energyPanel;

	GameObject lastCheckPoint;
	GameObject player;

	CharacterBehaviour characterBehaviour;
	public GameObject youDiedWindow;

	public int energPanelButtonRequired = 1;
	public int secondRowButtonCounter = 0;
	public bool isRow1Done,canTurnFirstLever,isSecondRowDone,canTurnSecondLever = false;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

	}

	// Update is called once per frame
	void Update () {

		character = playerAnim.gameObject;

	}

	public void PlayLevelAnim(string name){

		if(name == "FirstDoor"){


			playerAnim.PlayAlexAnim ("Card");
			StartCoroutine("WaitAnim", "FirstDoor");
			//StartCoroutine (NextStep (wait));
		}

		if(name == "SecondDoor"){

			playerAnim.PlayAlexAnim ("Card");
			StartCoroutine("WaitAnim", "SecondDoor");
		}

	}

	void PlayInteractionAnimation(string name){

		if(name == "FirstDoor"){

			interactionAnimator = firstDoor.GetComponent<Animator> ();
			Debug.Log (interactionAnimator.transform.name);
			interactionAnimator.SetBool ("Opened",true);
			doorsOpened = true;
		}

		if(name == "SecondDoor"){

			interactionAnimator = secondDoor.GetComponent<Animator> ();
			interactionAnimator.SetBool ("Opened",true);
			doorsOpened = true;
		}

	}

	IEnumerator NextStep(float wait){

		yield return new WaitForSeconds (wait);
		textBoxController.NextStep ();
	}

	public void CloseDoors(){

		if(doorsOpened == true){

			interactionAnimator.SetBool ("Opened",false);
		}

	}
	IEnumerator WaitAnim(string door){
		yield return new WaitForSeconds (2.2f);
		if(door == "FirstDoor"){

			PlayInteractionAnimation ("FirstDoor");
		}

		if(door == "SecondDoor"){

			PlayInteractionAnimation ("SecondDoor");
		}

	}

	public void DestroyDebris(){

		Destroy (debris.gameObject);
		secondDoor.SetActive (true);

		if (renTechoRoto != null) {
			renTechoRoto.materials [4].SetTexture ("_MainTex", rotoArregado);
		}
	}

	public void ListenToPrivateConversation(){

		AlexDialogueLvl_1andTutorial alexMonologue = character.GetComponent<AlexDialogueLvl_1andTutorial> ();
		alexMonologue.AlexsObservations ("PrivateConversation");

	}

	public void CanGetMaintenanceKey(){

		if(maintenanceKey !=null){

			maintenanceKey.SetActive (true);
		}

	}

	public void OpenEnergyPanel(){

		energyPanel.SetActive (true);
		//EnergyPanelDone ();
	}

	public void EnergyPanelDone(){

		energyPanel.SetActive (false);
		electricityGo.SetActive (true);
		sparks.SetActive (true);
		emergencyLights.SetActive (false);
		fixedPresentLights.SetActive (true);
		lightPanelDone = true;
		fixLightInteraction.SetActive (true);

	}

	public void BackToCheckPoint(){

		//player.transform.position = lastCheckPoint.GetComponent<CheckPoint> ().GetActiveCheckpointPosition ();
		player.transform.position = lastCheckPoint.transform.position;
		youDiedWindow.SetActive (false);
		playerAnim.playerDead = false;
		playerAnim.StopShockedAnimation ();


	}

	public void UpdateCheckPoint(GameObject currentCheckPoint){

		Debug.Log ("CHECKPOINTACTUALIZADO");
		//currentCheckPoint = lastCheckPoint;
		lastCheckPoint = currentCheckPoint;
	}

	public void EnergyPanelManager(string command){

		if(command == "ButtonRequired++"){

			energPanelButtonRequired++;
		}
	}

	public void secondButtonRowCounter(){

		secondRowButtonCounter++;
		if(secondRowButtonCounter >= 6){

			canTurnSecondLever = true;
		}

	}

	public void FixLightTubes(){

		Destroy (electricityGo);
		Destroy (sparks);
		Destroy (brokenLightTubes);
		fixedLightTube.SetActive (true);
	}



}

