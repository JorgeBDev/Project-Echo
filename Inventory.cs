using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

	public bool card1 = false;
	//public GameObject cardPrefab;
	public int itemsInInventory;
	//public int itemSlot = 0; ESTA ES LA VARIABLE DE BEÑAT

	public GameObject[] inventorySlots;

	//
	public GameController gameController;
	public UseSlot useSlot;
	public GameObject useSlotGo;
	public bool canUseObject = false;
	public bool hideAndRecover = false;
	public GameObject hideAndRecoverSlotGo;
	//public bool hideAndRecoverslotActive;
	HideAndRecoverSlot hideAndRecoverSlot;

	public GameObject inventoryPanel;

	private bool haveAChildren = false;

	public List<string> itemsMoment1 = new List<string> ();
	public List<string> itemsMoment0 = new List<string> ();
	Transform supportChildren;

	bool auxiliarCardBool, auxiliarStethoscope,auxiliarCoin,auxiliarCoffee,auxiliarMaintenanceKey,auxiliarScrewdriver = false;

	int itemPositionZ = 0;

	public GameObject itemIconGo;

	public int itemPlacementCounter = 1;

	//19/6 
	bool maintenaceKeyAdded,accessCardAdded = false;
	// Use this for initialization

	void Start ()
	{

		//inventorySlots = GameObject.FindGameObjectsWithTag ("ItemSlot");
		hideAndRecoverSlot = hideAndRecoverSlotGo.GetComponent<HideAndRecoverSlot> ();

	}

	// Update is called once per frame
	void Update ()
	{
		/*
		Debug.Log("item placement counter is" + itemPlacementCounter);
		Debug.Log("items in inventory" + itemsInInventory);
		*/


		if (canUseObject) {
			useSlotGo.gameObject.SetActive (true); 
		}

	}

	public void AddItem (string name, bool showInventory)
	{
		gameController.itemDescriptionNull ();

		if (showInventory == true) {

			gameController.Inventory ();
		}
		//gameController.Inventory ();
		//gameController.ableToTravel = false;

		if (name == "AccessCard") {

			if (auxiliarCardBool == false) {

				AddItemsInMoment (0, "AccessCard");
				//itemPlacementCounter++;
			}

			if(auxiliarCardBool == false){
				itemsInInventory++;
			}

			auxiliarCardBool = true;
			GameObject card = Instantiate (Resources.Load ("AccessCard"), gameObject.transform) as GameObject;
			card.transform.SetParent (inventorySlots [0].transform);
			RectTransform itemScale = card.GetComponent<RectTransform> ();
			itemScale.localScale = new Vector3 (0.531f, 0.531f, 0.531f);
			itemScale.localPosition = new Vector3 (itemScale.localPosition.x, itemScale.localPosition.y, 0.0f);

			itemPlacementCounter++;

		}

		if (name == "Stethoscope") {

			if (auxiliarStethoscope == false) {

				AddItemsInMoment (0, "Stethoscope");
				//itemPlacementCounter++;
			}
			if(auxiliarStethoscope == false){
				itemsInInventory++;
			}
			auxiliarStethoscope = true;
			GameObject stethoscope = Instantiate (Resources.Load ("Stethoscope"), gameObject.transform) as GameObject;
			Debug.Log ("ITEMS EN EL INVENTARIO = " + itemsInInventory);
			stethoscope.transform.SetParent (inventorySlots [1].transform);
			RectTransform itemScale = stethoscope.GetComponent<RectTransform> ();
			itemScale.localScale = new Vector3 (0.531f, 0.531f, 0.531f);
			itemScale.localPosition = new Vector3 (itemScale.localPosition.x, itemScale.localPosition.y, 0.0f);

			//itemPlacementCounter++;

		}

		if (name == "Coin") {

			if (auxiliarCoin == false) {

				AddItemsInMoment (0, "Coin");
				//itemPlacementCounter++;
				itemsInInventory++;
			}


			if (auxiliarCoin == false) {

				itemsInInventory++;

			}

			auxiliarCoin = true;

			GameObject coin = Instantiate (Resources.Load ("Coin"), gameObject.transform) as GameObject;

			coin.transform.SetParent (inventorySlots [2].transform);
			RectTransform itemScale = coin.GetComponent<RectTransform> ();
			itemScale.localScale = new Vector3 (0.531f, 0.531f, 0.531f);
			itemScale.localPosition = new Vector3 (itemScale.localPosition.x, itemScale.localPosition.y, 0.0f);

			itemPlacementCounter++; //AÑADIDOS EN LOS UILTIMOS ITEMS AÑADIDOS EL 8/6. NO SE MUY BIEN LO QUE HACE PERO LOS OTROS LO TIENEN
		}

		if (name == "Coffee") {

			if (auxiliarCoffee == false) {

				AddItemsInMoment (0, "Coffee");
				//itemPlacementCounter++;

			}
			if(auxiliarCoffee == false){
				itemsInInventory++;
			}

			auxiliarCoffee = true;
			GameObject coffee = Instantiate (Resources.Load ("Coffee"), gameObject.transform) as GameObject;

			coffee.transform.SetParent (inventorySlots [3].transform);
			RectTransform itemScale = coffee.GetComponent<RectTransform> ();
			itemScale.localScale = new Vector3 (0.531f, 0.531f, 0.531f);
			itemScale.localPosition = new Vector3 (itemScale.localPosition.x, itemScale.localPosition.y, 0.0f);

			itemPlacementCounter++;
		}

		if (name == "MaintenanceKey") {

			if (auxiliarMaintenanceKey == false) {

				AddItemsInMoment (0, "MaintenanceKey");
				//itemPlacementCounter++;
			}
			if(auxiliarMaintenanceKey == false){
				itemsInInventory++;
			}
			auxiliarMaintenanceKey = true;
			GameObject maintenanceKey = Instantiate (Resources.Load ("MaintenanceKey"), gameObject.transform) as GameObject;

			maintenanceKey.transform.SetParent (inventorySlots [4].transform);
			RectTransform itemScale = maintenanceKey.GetComponent<RectTransform> ();
			//itemScale.localScale = new Vector3 (0.5301678f, 0.5301678f, 0.5301678);
			itemScale.localScale = new Vector3 (0.531f, 0.531f, 0.531f);
			itemScale.localPosition = new Vector3 (itemScale.localPosition.x, itemScale.localPosition.y, 0.0f);

			itemPlacementCounter++;
		}

		if (name == "Screwdriver") {

			if (auxiliarScrewdriver == false) {

				AddItemsInMoment (0, "Screwdriver");
				//itemPlacementCounter++;
			}
			if(auxiliarScrewdriver == false){
				itemsInInventory++;
			}
			auxiliarScrewdriver = true;
			GameObject screwdriver = Instantiate (Resources.Load ("Screwdriver"), gameObject.transform) as GameObject;

			screwdriver.transform.SetParent (inventorySlots [5].transform);
			RectTransform itemScale = screwdriver.GetComponent<RectTransform> ();
			//itemScale.localScale = new Vector3 (0.5301678f, 0.5301678f, 0.5301678);
			itemScale.localScale = new Vector3 (0.38f, 0.38f, 0.38f);
			itemScale.localPosition = new Vector3 (itemScale.localPosition.x, itemScale.localPosition.y, 0.0f);

			itemPlacementCounter++;
		}

		//itemPlacementCounter = 0;

	}
	public void LoadItemsInMoment (string travelingToMoment)
	{

		if (travelingToMoment == "Past") {

			foreach (string itemSlot in itemsMoment0) {

				if (itemSlot != null) {

					if (itemSlot == "AccessCard") {
						AddItem ("AccessCard", false);
					}

					if (itemSlot == "Stethoscope") {

						AddItem ("Stethoscope", false);
					}

					if (itemSlot == "Coin") {

						AddItem ("Coin", false);
					}

					if (itemSlot == "Coffee") {

						AddItem ("Coffee", false);
					}

					if (itemSlot == "MaintenanceKey") {

						AddItem ("MaintenanceKey", false);
					}

					if (itemSlot == "Screwdriver") {

						AddItem ("Screwdriver", false);
					}
					//AddItem (itemSlot);
				}
			}

		}


		if (travelingToMoment == "Present") {

			foreach (string itemSlot in itemsMoment1) {

				if (itemSlot != null) {

					if (itemSlot == "AccessCard") {

						AddItem ("AccessCard", false);
					}

					if (itemSlot == "Stethoscope") {

						AddItem ("Stethoscope", false);
					}

					if (itemSlot == "Coin") {

						AddItem ("Coin", false);
					}

					if (itemSlot == "Coffee") {

						AddItem ("Coffee", false);
					}

					if (itemSlot == "MaintenanceKey") {

						AddItem ("MaintenanceKey", false);
					}
				}
			}

		}

	}

	public void DeleteChildren(){

		/*
		if(gameObject.transform.childCount >= 0){

			//Transform child = gameObject.transform.GetChild (0);
			Destroy (gameObject.transform.GetChild (0).gameObject);
		}
		*/

		foreach (GameObject slots in inventorySlots) {

			UseSlot slotScript;
			slotScript = slots.GetComponent<UseSlot> ();
			if (slots.transform.childCount > 0) {

				Destroy (slots.transform.GetChild (0).gameObject);
			}

		}
	}

	public void CloseInventory ()
	{
		//gameController.Inventory (); // voy a cambiar esto por set active false para que no ejecute el abletotravel del metodo inventory(). LO VOY A PONER ABAJO DE ESTE METODO
		canUseObject = false;
		useSlot.keyItem = null;
		useSlotGo.SetActive (false);
		hideAndRecoverSlotGo.SetActive (false);
		hideAndRecoverSlot.referenceObject = null;
		//SlotsHaveChildren (); //COMENTADO EL 18/5
		Destroy (hideAndRecoverSlot.itemParented);
		inventoryPanel.SetActive (false);

		if(gameController.tutorialPanel.activeInHierarchy){

			gameController.CloseTutorial ();
		}

	}

	public void UseSlotManager (bool isActive)
	{
		if (isActive == true) {

			useSlotGo.SetActive (true);

		} else {
			useSlotGo.SetActive (false);
		}
	}

	public void HideAndRecoverManager (bool isActive)
	{ 

		if (isActive == true) {
			Debug.Log ("HIDESLOT ACTIVO");
			hideAndRecoverSlotGo.SetActive (true);
		} else {
			hideAndRecoverSlotGo.SetActive (false);
			//hideAndRecoverslotActive = false;
		}
	}

	public void SlotsHaveChildren ()
	{

		foreach (GameObject slots in inventorySlots) {

			UseSlot slotScript;
			slotScript = slots.GetComponent<UseSlot> ();
			if (slots.transform.childCount > 0) {
				Debug.Log ("NOT ABLE TO TRAVEL SASDHSBAD");
				//gameController.ableToTravel = false;
				haveAChildren = true;
			} 

			if (haveAChildren == false) {
				gameController.ableToTravel = true;
				//Debug.Log ("ABLE TO TRAVEL SKDBSK"); COMENTADO EL 24/4/1017 PARA QUE NO MOLESTE EN CONSOLE

			} 

		}
		//LOQ SEA CON ALGUNHIJO = TRUE
		haveAChildren = false; //pongo esto aqui para que se vuelva falsa la variable auxiliar tras hacer todo el forEach
		//algunHijo = false;
	}

	public void AddItemsInMoment (int moment, string item)
	{
		if (moment == 1) {

			if (item == "AccessCard") {
				itemsMoment1.Add ("AccessCard");
			}

			if (item == "MaintenanceKey") {
				itemsMoment1.Add ("MaintenanceKey");
			}
		}

		if (moment == 0) {

			if (item == "AccessCard") {
				itemsMoment0.Add ("AccessCard");
			}

			if (item == "Stethoscope") {
				itemsMoment0.Add ("Stethoscope");
			}

			if (item == "Coin") {
				Debug.Log ("CREO COIN");
				itemsMoment0.Add ("Coin");
			}

			if (item == "Coffee") {
				itemsMoment0.Add ("Coffee");
			}

			if (item == "MaintenanceKey") {
				itemsMoment0.Add ("MaintenanceKey");
			}

			if (item == "Screwdriver") {
				itemsMoment0.Add ("Screwdriver");
			}
		}

	}



	public void NullItemsInInventory (string travelingToMoment)
	{

		if (travelingToMoment == "Past") {

			foreach (GameObject itemSlot in inventorySlots) {

				if (itemSlot.transform.childCount > 0) {

					supportChildren = itemSlot.transform.GetChild (0);
					Destroy (supportChildren.gameObject);

				}
				supportChildren = null;


			}
		}

		if (travelingToMoment == "Present") {

			foreach (GameObject itemSlot in inventorySlots) {

				if (itemSlot.transform.childCount > 0) {

					supportChildren = itemSlot.transform.GetChild (0);
					Destroy (supportChildren.gameObject);

				}
				supportChildren = null;

			}
		}
	}



	public void ShowItemIcon ()
	{

		itemIconGo.SetActive (true);
	}

	public void AddMaintenanceKeyOnDrop ()
	{
		if(maintenaceKeyAdded == false){
			AddItemsInMoment (1,"MaintenanceKey");
			maintenaceKeyAdded = true;
		}

	}

	public void AddAccessCardOnDrop ()
	{
		if(accessCardAdded == false){
			AddItemsInMoment (1,"AccessCard");
			maintenaceKeyAdded = true;
		}

	}



}