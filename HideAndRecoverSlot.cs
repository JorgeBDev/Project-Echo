using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HideAndRecoverSlot : MonoBehaviour,IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
	public string keyItem;
	public LevelManager levelManager;
	public Inventory inventory;

	public GameObject referenceObject;
	public bool hasReference = false;

	HideAndRecover hideAndRecover;
	public GameObject itemParented;

	public GameObject card;
	GameObject gO;

	Draggable draggableItem;

	public GameObject slotOnEnter;



	void Update ()
	{
		if (referenceObject != null) {
			hideAndRecover = referenceObject.GetComponent<HideAndRecover> ();
		}


	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		if (gameObject.transform.childCount <= 0) {

			slotOnEnter.SetActive (true);
		}


	}

	public void OnDrop (PointerEventData eventData)
	{
		if(gameObject.transform.childCount <= 0){

			Debug.Log (eventData.pointerDrag.name + "was dropped on" + gameObject.name);
			draggableItem = eventData.pointerDrag.GetComponent<Draggable> ();

			if (draggableItem != null) {
				draggableItem.originalParent = this.transform;
				hideAndRecover.hasHiddenItem = true;
				//
				itemParented = draggableItem.gameObject;
				//
				if (draggableItem.name.Contains ("Card")) {

					hideAndRecover.hiddenItem = "card";
					inventory.itemsMoment0.Remove("AccessCard"); //esto ha sido añadido el 9/6 tras saber que la tarjeta si se dejaba en el slot, se viajaba y se volvia teniamos la tarjeta del slot y la del invrentario
				}

				if (draggableItem.name.Contains ("MaintenanceKey")) {

					hideAndRecover.hiddenItem = "MaintenanceKey";
					inventory.itemsMoment0.Remove("MaintenanceKey");
				}
			}
		}

		/*
		Debug.Log (eventData.pointerDrag.name + "was dropped on" + gameObject.name);
		draggableItem = eventData.pointerDrag.GetComponent<Draggable> ();

		if (draggableItem != null) {
			draggableItem.originalParent = this.transform;
			hideAndRecover.hasHiddenItem = true;
			//
			itemParented = draggableItem.gameObject;
			//
			if (draggableItem.name.Contains ("Card")) {

				hideAndRecover.hiddenItem = "card";
			}
		}
		*/

	}

	public void OnPointerExit (PointerEventData eventData)
	{

		slotOnEnter.SetActive (false);
	}

	public void ReferenceObject (GameObject reference)
	{

		referenceObject = reference;
	}

	public void ShowItem (string prefab)
	{

		if (prefab == "card") {

			gO = Instantiate (Resources.Load ("AccessCard"), gameObject.transform) as GameObject;
			RectTransform itemScale = gO.GetComponent<RectTransform> ();
			itemScale.localScale = new Vector3 (0.75f, 0.75f, 16.66f);

		}

		if (prefab == "MaintenanceKey") {

			gO = Instantiate (Resources.Load ("MaintenanceKey"), gameObject.transform) as GameObject;
			RectTransform itemScale = gO.GetComponent<RectTransform> ();
			itemScale.localScale = new Vector3 (0.75f, 0.75f, 16.66f);

		}
	}
}