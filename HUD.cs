using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

	public Text timeCounterTxt;
	public float timeCounter = 30f;
	public float MaxtimeCounter = 30f;
	private float savedTimeCounter;
	public float timeHandicap = 1.0f;
	public bool timeFlies = false;
	GameController gameController;

	[SerializeField]
	private float fillAmountEnergy;
	[SerializeField]
	private Image energyContent;

	//
	public Image shot1Square, shot2Square,swapSquare;
	public Image shot1,shot2,swapShot;

	public AlexDialogueLvl_1andTutorial alexDialogue;
	GameObject hud;
	Inventory inventory;
	// Use this for initialization
	void Start ()
	{

		gameController = gameObject.GetComponent<GameController> ();
		hud = GameObject.FindGameObjectWithTag ("Inventory");
		inventory = hud.GetComponent<Inventory> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		

		//timeCounterTxt.text = "" + timeCounter; LO HE QUITADO
		if(alexDialogue.onAlexDialogue == false){

			TimeIsRunning ();
		}
		//TimeIsRunning ();
		TimeReset ();

		EnergyBar ();

		fillAmountEnergy = Map(timeCounter,0,MaxtimeCounter,0,1);


	}


	public void TimeIsRunning(){
		/*
		while(alexDialogue.onAlexDialogue == true){
			Debug.Log ("OnWHILE");
		}*/

		if (gameController.timeIsRunning == true) {

			timeCounter -= Time.deltaTime * timeHandicap;

			if (gameController.shotsNumber == 2) {

				timeHandicap = 1;
			}

			if (gameController.shotsNumber == 1) {

				timeHandicap = 2;
			}

			if (gameController.shotsNumber == 0) {

				timeHandicap = 4;
			}

			if (gameController.swapped == true) {

				timeHandicap = 5;
			}

			if (timeCounter <= 0) {
				if (gameController.moment == 0) {
					//Añado la linea de abajo el 18/5 para poner lo de borrar los objetos del inventario cuando volvamos al presente repentinamente
					inventory.NullItemsInInventory ("Present");
					gameController.Vanished2 ();
					gameController.ableToTravel = false;
					gameController.moment = 1;
				}
				gameController.timeIsRunning = false;
				timeCounter = 0;
				gameController.timeReset = true;
				gameController.canSwap = false;
				gameController.canReset = false;
				gameController.canTravelObj1 = null;
				gameController.canTravelObj2 = null;
				gameController.firstShot = false;
			}
		} else {

			if(timeCounter < MaxtimeCounter){
				gameController.ableToTravel = false;
			}
		}

	}

	public void TimeReset(){

		if(gameController.timeReset == true){

			if(gameController.swapped == true){

				//gameController.ResetObjectPositions();
			}
				

			timeHandicap = 3.0f;
			timeCounter += Time.deltaTime * timeHandicap;
			if(timeCounter >= MaxtimeCounter){
				ResetSquareColors ();
				gameController.timeReset = false;
				timeCounter = MaxtimeCounter;
				gameController.CanStartShotProcess = true;
				gameController.canReset = true;
				gameController.canSwap = false;
				gameController.ableToTravel = true;


			}
		}
	}

	private void EnergyBar(){

		if(fillAmountEnergy != energyContent.fillAmount){

			energyContent.fillAmount = fillAmountEnergy;
		}

	}

	private float Map(float value,float inMin, float inMax,float outMin, float outMax){

		return (value - inMin) * (outMax - outMin
		) / (inMax - inMin) + outMin;
	}

	public void ChangeSquareColors(int square){

		if (square == 1) {

			//shot1Square.sprite = Resources.Load<Sprite> ("ShotSquareRed");
			shot1Square.gameObject.SetActive (false);

		}

		if (square == 2) {

			//shot2Square.sprite = Resources.Load<Sprite> ("ShotSquareRed");
			shot2Square.gameObject.SetActive (false);
		}

		if (square == 3) {

			//swapSquare.sprite = Resources.Load<Sprite> ("ShotSquareRed");
			swapSquare.gameObject.SetActive (false);
		}
	}

	private void ResetSquareColors(){
		/*
		swapSquare.sprite = Resources.Load<Sprite> ("ShotSquareBlue");
		shot2Square.sprite = Resources.Load<Sprite> ("ShotSquareBlue");
		shot1Square.sprite = Resources.Load<Sprite> ("ShotSquareBlue");
		*/
		shot1Square.gameObject.SetActive (true);
		shot2Square.gameObject.SetActive (true);
		swapSquare.gameObject.SetActive (true);
	}


}
