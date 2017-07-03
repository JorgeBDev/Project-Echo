using UnityEngine;
using System.Collections;

public class CanMoveObject : MonoBehaviour {

	public GameObject player;
	bool grabbed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider collider){

		if (collider.CompareTag ("Player") && Input.GetKey (KeyCode.LeftControl)) {

			gameObject.transform.SetParent (player.transform);
			grabbed = true;
		}

		if (Input.GetKeyUp (KeyCode.LeftControl) && grabbed == true) {

			gameObject.transform.parent = null;
			grabbed = false;
		}



	}
		
}
