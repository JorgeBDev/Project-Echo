using UnityEngine;
using System.Collections;

public class SetActiveIcon : MonoBehaviour {

	public GameObject hideAndRecoverIcon;
	//public bool isOn = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider collider){

		if (collider.CompareTag ("Player")) {

			hideAndRecoverIcon.gameObject.SetActive (true);
			//isOn = true;
		}
	}

	void OnTriggerExit(Collider collider){

		if(collider.CompareTag("Player")){
			hideAndRecoverIcon.gameObject.SetActive(false);
			//isOn = false;
		}
	}
}
