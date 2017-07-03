using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerEnterHandler,IPointerClickHandler {

	public Transform originalParent = null;

	GameObject placeHolder = null;

	GameObject gameControllerGo;
	GameController gameController;

	Text itemDescription;
	Image itemIcon;

	GameObject inventoryGo;
	Inventory inventory;
	void Start ()
	{
		gameControllerGo = GameObject.FindGameObjectWithTag ("GameController");
		gameController = gameControllerGo.GetComponent<GameController> ();

	}

	void Update ()
	{	
		
	}

	public void OnBeginDrag(PointerEventData eventData){

		itemDescription = GameObject.Find ("ItemDescriptionGO").GetComponent<Text>();
		originalParent = transform.parent;
		transform.SetParent (transform.parent.parent);
		GetComponent<CanvasGroup> ().blocksRaycasts = false;

		if(gameObject.name.Contains("AccessCard")){

			ItemDescription ("AccessCard");
		}

		if(gameObject.name.Contains("Stethoscope")){

			ItemDescription ("Stethoscope");
		}

		if(gameObject.name.Contains("Coin")){

			ItemDescription ("Coin");
		}


	}

	public void OnDrag(PointerEventData eventData){
		transform.position = eventData.position;
		//Debug.Log ("ARRASTRANDO");

	}

	public void OnEndDrag(PointerEventData eventData){
		transform.SetParent (originalParent);
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

	public void OnPointerClick(PointerEventData eventData){

		Draggable draggableItem = eventData.pointerDrag.GetComponent<Draggable> ();
		if (draggableItem != null && !gameObject.CompareTag ("UseSlot")) {
			Debug.Log ("ESTE OBJETO ES" + eventData.pointerPress.name);
			//ItemDescription ("Card");
			if(eventData.pointerPress.name.Contains("AccessCard")){
				ItemDescription ("AccessCard");
			}
			if(eventData.pointerPress.name.Contains("Stethoscope")){
				ItemDescription ("Stethoscope");
			}
			if(eventData.pointerPress.name.Contains("Coin")){
				ItemDescription ("Coin");
			}

			if(eventData.pointerPress.name.Contains("Coffee")){
				ItemDescription ("Coffee");
			}

			if(eventData.pointerPress.name.Contains("MaintenanceKey")){
				ItemDescription ("MaintenanceKey");
			}

			if(eventData.pointerPress.name.Contains("Screwdriver")){
				ItemDescription ("Screwdriver");
			}
		}
	}

	public void OnPointerEnter(PointerEventData evenData){

		//Debug.Log ("PointClickLmao");
	}

	void ItemDescription(string item){

		if (item == "AccessCard") {

			itemDescription = GameObject.Find ("ItemDescriptionGO").GetComponent<Text>();
			itemDescription.text = "Apparently this is an access card. It's weird that a hospital needs so much security";
		
			inventoryGo = GameObject.FindGameObjectWithTag ("Inventory");
			inventory = inventoryGo.GetComponent<Inventory> ();
			itemIcon = inventory.itemIconGo.GetComponent<Image>(); //inventory.ItemIconGo.GetComponent<Image> ();
			itemIcon.sprite = Resources.Load<Sprite> ("CardIcon");
			inventory.ShowItemIcon ();

		}

		if (item == "Stethoscope") {

			itemDescription = GameObject.Find ("ItemDescriptionGO").GetComponent<Text>();
			itemDescription.text = "Ummm...I am not a doctor but I'm sure I can make use of it somehow.";

			inventoryGo = GameObject.FindGameObjectWithTag ("Inventory");
			inventory = inventoryGo.GetComponent<Inventory> ();
			itemIcon = inventory.itemIconGo.GetComponent<Image>(); //inventory.ItemIconGo.GetComponent<Image> ();
			itemIcon.sprite = Resources.Load<Sprite> ("Stethoscope_Icon");
			inventory.ShowItemIcon ();

		}

		if (item == "Coin") {

			itemDescription = GameObject.Find ("ItemDescriptionGO").GetComponent<Text>();
			itemDescription.text = "It's just a coin. You can't buy many things with it but it's worth something";

			inventoryGo = GameObject.FindGameObjectWithTag ("Inventory");
			inventory = inventoryGo.GetComponent<Inventory> ();
			itemIcon = inventory.itemIconGo.GetComponent<Image>(); //inventory.ItemIconGo.GetComponent<Image> ();
			itemIcon.sprite = Resources.Load<Sprite> ("Coin_Icon");
			//EN LA LINEA DE ARRIBA TENGO QUE CARGAR EL SPRITE DE LA MONEDICA
			inventory.ShowItemIcon ();

		}

		if (item == "MaintenanceKey") {

			itemDescription = GameObject.Find ("ItemDescriptionGO").GetComponent<Text>();
			itemDescription.text = "This opens the maintenance door on this floor. It also has that icon in the elevator panel.";

			inventoryGo = GameObject.FindGameObjectWithTag ("Inventory");
			inventory = inventoryGo.GetComponent<Inventory> ();
			itemIcon = inventory.itemIconGo.GetComponent<Image>(); //inventory.ItemIconGo.GetComponent<Image> ();
			itemIcon.sprite = Resources.Load<Sprite> ("MaintenanceKey_Icon");
			//EN LA LINEA DE ARRIBA TENGO QUE CARGAR EL SPRITE DE LA MONEDICA
			inventory.ShowItemIcon ();

		}

		if (item == "Coffee") {

			itemDescription = GameObject.Find ("ItemDescriptionGO").GetComponent<Text>();
			itemDescription.text = "Meh. Never liked coffee. It keeps me awake.";

			inventoryGo = GameObject.FindGameObjectWithTag ("Inventory");
			inventory = inventoryGo.GetComponent<Inventory> ();
			itemIcon = inventory.itemIconGo.GetComponent<Image>(); //inventory.ItemIconGo.GetComponent<Image> ();
			itemIcon.sprite = Resources.Load<Sprite> ("Coffee_Icon");
			//EN LA LINEA DE ARRIBA TENGO QUE CARGAR EL SPRITE DE LA MONEDICA
			inventory.ShowItemIcon ();

		}

		if (item == "Screwdriver") {

			itemDescription = GameObject.Find ("ItemDescriptionGO").GetComponent<Text>();
			itemDescription.text = "I'm sure can fix things with this";

			inventoryGo = GameObject.FindGameObjectWithTag ("Inventory");
			inventory = inventoryGo.GetComponent<Inventory> ();
			itemIcon = inventory.itemIconGo.GetComponent<Image>(); //inventory.ItemIconGo.GetComponent<Image> ();
			itemIcon.sprite = Resources.Load<Sprite> ("Screwdriver_Icon");
			//EN LA LINEA DE ARRIBA TENGO QUE CARGAR EL SPRITE DE LA MONEDICA
			inventory.ShowItemIcon ();

		}
	}

	void ShowItemIcon(string item){

		itemIcon.gameObject.SetActive (true);
	}

}
