using UnityEngine;
using System.Collections;

public class CharacterDead : MonoBehaviour {

	public string deathCause;
	public CharacterBehaviour alexController;
	public GameObject youDiedWindow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider collider){

		if (collider.CompareTag ("Player")) {

			if(deathCause == "Shock"){

				alexController.PlayAlexAnim ("Shocked");
				alexController.playerDead = true;
				StartCoroutine ("WaitForDeadWindow");
			}
		}
	}

	void OnTriggerExit(Collider collider){

		if(collider.CompareTag("Player")){


		}
	}

	IEnumerator WaitForDeadWindow(){
		yield return new WaitForSecondsRealtime (2.0f);

		youDiedWindow.SetActive (true);
	}
}
