using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UseSlot : MonoBehaviour,IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
	public string keyItem;
	public LevelManager levelManager;
	public Inventory inventory;

	HideAndRecoverSlot hideAndRecoverObjectReference;
	HideAndRecover hiddenObjectString;
	public GameObject hideAndRecoverSlot;

	GameObject gameControllerGo;
	GameController gameController;
	AlexDialogueLvl_1andTutorial alexMonologue;
	public bool hasChildren;
	public GameObject slotOnEnter;

	Transform slotChild;
	public bool firstDoorAux = false;

	void Start ()
	{
		gameControllerGo = GameObject.FindGameObjectWithTag ("GameController");
		gameController = gameControllerGo.GetComponent<GameController> ();
		alexMonologue = GameObject.FindGameObjectWithTag ("Player").GetComponent<AlexDialogueLvl_1andTutorial> ();
	}

	void Update ()
	{


	}

	public void OnPointerEnter (PointerEventData eventData)
	{

		slotOnEnter.SetActive (true);

	}

	public void OnDrop (PointerEventData eventData)
	{

		Debug.Log (eventData.pointerDrag.name + "was dropped on" + gameObject.name);
		Draggable draggableItem = eventData.pointerDrag.GetComponent<Draggable> ();
		if (draggableItem != null && !gameObject.CompareTag ("UseSlot")) {
			draggableItem.originalParent = this.transform;
			//tengo que referenciar el hidden object y decir que es null

			//19/6 VOY A HACER QUE LA MAINTENANCE KEY SE DUPLIQUE AÑADA AL INVENTARIO DEL PRESENTE AL METERLLA EN UN SLOT
			if(draggableItem.name.Contains("MaintenanceKey") && gameController.moment == 1 && gameController.maintenanceKeyAux == false){
				inventory.AddMaintenanceKeyOnDrop();
				Debug.Log ("Anadiendo MaintenanceKey");
				gameController.maintenanceKeyAux = true;
			}

			if(draggableItem.name.Contains("AccessCard") && gameController.moment == 1 && gameController.accessCardAddedAux == false){
				inventory.AddAccessCardOnDrop ();
				gameController.accessCardAddedAux = true;
			}


			if (inventory.hideAndRecoverSlotGo.gameObject.activeInHierarchy) {

				hideAndRecoverObjectReference = hideAndRecoverSlot.GetComponent<HideAndRecoverSlot> ();
				//hideAndRecoverObjectReference.referenceObject = null;
				hiddenObjectString = hideAndRecoverObjectReference.referenceObject.GetComponent<HideAndRecover> ();
				//hideAndRecoverObjectReference.hasReference = false;
				hiddenObjectString.hiddenItem = null;
				hiddenObjectString.hasHiddenItem = false;
				//hiddenObjectstring.hiddenItem = null;
			}
		}

		if (gameObject.CompareTag ("UseSlot")) {

			if (keyItem == "CardItem" && eventData.pointerDrag.CompareTag ("CardItem")) {


				if(levelManager.firstDoorAux == true){

					levelManager.PlayLevelAnim ("SecondDoor");
					Destroy (eventData.pointerDrag);
					slotOnEnter.SetActive (false);
					inventory.CloseInventory ();
					Destroy (gameController.toPointGameObject);
				}

				if(levelManager.firstDoorAux == false){
					//
					//inventory.itemsMoment0.Remove[0];
					//
					levelManager.PlayLevelAnim ("FirstDoor");
					Destroy (eventData.pointerDrag);
					slotOnEnter.SetActive (false);
					inventory.CloseInventory ();
					firstDoorAux = true;
					levelManager.firstDoorAux = true;

				}




			} else if (keyItem == "CardItem" && !eventData.pointerDrag.CompareTag ("CardItem")) {
				Debug.Log ("NO ES ESTE OBJETO");
			}

			if (keyItem == "Coin" && eventData.pointerDrag.name.Contains("Coin")) {

				levelManager.coffeeInteraction.SetActive (true);
				Destroy (eventData.pointerDrag);
				slotOnEnter.SetActive (false);
				inventory.CloseInventory ();

			} else if (keyItem == "Coin" && !eventData.pointerDrag.name.Contains ("Coin")) {
				Debug.Log ("NO CAFE");
			}

			if (keyItem == "Coffee" && eventData.pointerDrag.name.Contains("Coffee")) {

				Destroy (eventData.pointerDrag);
				slotOnEnter.SetActive (false);
				inventory.CloseInventory ();
				Debug.Log ("DESAPARECEN LOS ESCOMBROS");
				levelManager.DestroyDebris ();
				inventory.itemsMoment0.Remove("Coffee");
				alexMonologue.AlexsObservations ("DestroyDebris");

			} else if (keyItem == "Coffee" && !eventData.pointerDrag.name.Contains ("Coffee")) {
				Debug.Log ("POR QUÉ PONDRÍA CAFE AQUI");
			}

			if (keyItem == "Stethoscope" && eventData.pointerDrag.name.Contains("Stethoscope")) {

				Destroy (eventData.pointerDrag);
				slotOnEnter.SetActive (false);
				inventory.CloseInventory ();
				Debug.Log ("ESCUCHAR A TRAVES DE LA PUERTA");
				//AQUI VA LA LINEA QUE COMIENZA EL DIALOGO PRIVADO
				levelManager.ListenToPrivateConversation();

			} else if (keyItem == "Stethoscope" && !eventData.pointerDrag.name.Contains ("Stethoscope")) {
				Debug.Log ("Poner eso el la puerta sería totalmente inutil");
			}

			if (keyItem == "MaintenanceKey" && eventData.pointerDrag.name.Contains("MaintenanceKey") && levelManager.lightPanelDone == false && !gameController.toPointGameObject.name.Contains("Elevator")) {

				Destroy (eventData.pointerDrag);
				slotOnEnter.SetActive (false);
				inventory.CloseInventory ();
				Debug.Log ("Abrir Maintenance Door Present + panel");
				//AQUI VA LA LINEA QUE ABRE PANEL
				levelManager.OpenEnergyPanel();

			} else if (keyItem == "MaintenanceKey" && !eventData.pointerDrag.name.Contains ("MaintenanceKey")) {
				Debug.Log ("No creo que esto me ayude a abrir la puerta");
			}

			if (keyItem == "MaintenanceKey" && eventData.pointerDrag.name.Contains("MaintenanceKey") && levelManager.lightPanelDone == true) {

				Destroy (eventData.pointerDrag);
				slotOnEnter.SetActive (false);
				inventory.CloseInventory ();
				Debug.Log ("Pasar a siguiente fase");
				SceneManager.LoadScene ("ThanksForPlaying");
				//AQUI VA LA LINEA DE PASAR A SIGUIENTE FASE. METEMOS LA LLAVE Y PARA ABAJO


			} else if (keyItem == "MaintenanceKey" && !eventData.pointerDrag.name.Contains ("MaintenanceKey")) {
				Debug.Log ("No creo que esto me ayude a abrir la puerta");

			}else if((keyItem == "MaintenanceKey" && eventData.pointerDrag.name.Contains ("MaintenanceKey") && levelManager.lightPanelDone == false)){

				Debug.Log ("TODAVIA NO ESTÁ DADA LA LUZ DE ESTA PLANTA");
			}

			if (keyItem == "Screwdriver" && eventData.pointerDrag.name.Contains("Screwdriver")) {

				Destroy (eventData.pointerDrag);
				slotOnEnter.SetActive (false);
				inventory.CloseInventory ();
				levelManager.FixLightTubes ();

			} else if (keyItem == "Screwdriver" && !eventData.pointerDrag.name.Contains ("Screwdriver")) {
				Debug.Log ("No creo que un destornillador me ayude");
			}
		}

	}


	public void OnPointerExit (PointerEventData eventData)
	{
		slotOnEnter.SetActive (false);
	}


}

