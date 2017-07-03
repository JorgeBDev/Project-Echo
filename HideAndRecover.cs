using UnityEngine;
using System.Collections;

public class HideAndRecover : MonoBehaviour
{

	public GameObject hideAndRecoverIcon;
	public GameController gameController;
	//para acceder a la funcion Inventory
	public Inventory inventory;
	public GameObject inventoryPanel;

	public bool hasHiddenItem = false;
	public string hiddenItem;
	public GameObject canHideObject, canRecoverObject;
	public bool hasRecoveredItem;
	HideAndRecover sameObjectPast;
	public  HideAndRecoverSlot hideAndRecoverSlot;

	bool alreadyACardInPresent,alreadyMaintenanceKeyInPresent;

	public SetActiveIcon icon;
	Color goColor;
	SpriteRenderer goRenderer;
	bool isOn;


	// Use this for initialization
	void Start ()
	{

		goRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (isOn == true && Input.GetKeyDown (KeyCode.Mouse0)) {

			if (gameObject.CompareTag ("CanHideItem") && !inventoryPanel.activeInHierarchy) {

				if (hasHiddenItem == false) {

					///////// FIRST TIME HIDING
					if(gameController.firstTimeHiding == false){

						Debug.Log ("FIRS TIME HIDING");
						gameController.ShowTriggeredTutorial ("HideSlot");
						gameController.firstTimeHiding = true;
					}
					//////////// FIRST TIME HIDING
					gameController.Inventory ();
					inventory.HideAndRecoverManager (true);
					hideAndRecoverSlot.ReferenceObject (this.gameObject);
				}

				if (hasHiddenItem == true) {
					gameController.Inventory ();
					inventory.HideAndRecoverManager (true);
					hideAndRecoverSlot.ReferenceObject (this.gameObject);

					if (hiddenItem == "card") {

						hideAndRecoverSlot.ShowItem ("card");
					}

					if (hiddenItem == "MaintenanceKey") {

						hideAndRecoverSlot.ShowItem ("MaintenanceKey");
					}


				}

			} else if (gameObject.CompareTag ("CanRecoverItem") && !inventoryPanel.activeInHierarchy) {

				gameController.Inventory ();
				inventory.HideAndRecoverManager (true);
				hideAndRecoverSlot.ReferenceObject (this.gameObject);
				sameObjectPast = canHideObject.GetComponent<HideAndRecover> ();
				if (sameObjectPast.hasHiddenItem == true) {

					if (sameObjectPast.hiddenItem == "card" && alreadyACardInPresent == false) {
						Debug.Log ("SHOWITEMCARD");
						hideAndRecoverSlot.ShowItem ("card");
						alreadyACardInPresent = true;
					}

					if (sameObjectPast.hiddenItem == "MaintenanceKey" && alreadyMaintenanceKeyInPresent == false) {

						hideAndRecoverSlot.ShowItem ("MaintenanceKey");
						alreadyMaintenanceKeyInPresent = true;
					}
				}
			}

		}
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


	public void HideItem ()
	{
		

	}


	public void RecoverItem ()
	{

	}


}
