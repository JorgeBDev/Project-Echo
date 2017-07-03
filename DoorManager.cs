using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

	public LevelManager levelManager;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){

	}

	void OnTriggerExit(){

		if(levelManager.doorsOpened == true){

			//levelManager.CloseDoors ();
		}
	}
}
