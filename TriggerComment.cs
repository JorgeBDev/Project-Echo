using UnityEngine;
using System.Collections;

public class TriggerComment : MonoBehaviour {

	public AlexDialogueLvl_1andTutorial alexDialogue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){

		if (collider.CompareTag ("Player")) {

			alexDialogue.AlexsObservations ("PrivateConversationComing");
		}
	}
		


}
