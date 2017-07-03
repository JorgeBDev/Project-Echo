using UnityEngine;
using System.Collections;

public class HighlightObject : MonoBehaviour {

	public GameObject player;
	public GameController gameController;
	Component halo;
	float maxDistance = 8.0f;
	bool switchOffControl = false;

	public bool activateHighLight = false;

	// Use this for initialization
	void Start () {

		halo = GetComponent("Halo");
		halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
		//halo.GetType ().GetProperty ("color").SetValue (halo, Color.green, null);
	}
	
	// Update is called once per frame
	void Update () {

		if(gameController.timeReset == true){

			halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
			Debug.Log ("1");
		}
		

		if (gameController.swapped == true && activateHighLight == true) {

			halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
			switchOffControl = true;
			Debug.Log ("2");
		} 
			
		if(gameController.swapped == false && switchOffControl == true){

			halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
			switchOffControl = false;
			Debug.Log ("3");
			
		}

		if(activateHighLight == true){

			halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
			Debug.Log ("4");
		}


		if(gameController.timeReset == true){
			halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
		}



		if(gameController.canTravelObj1 != null && gameObject.CompareTag("LevelPresent") && Vector3.Distance(gameObject.transform.position,player.transform.position) < maxDistance){

			halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
		}

		if(gameController.canTravelObj2 != null && gameObject.CompareTag("LevelPast") && Vector3.Distance(gameObject.transform.position,player.transform.position) < maxDistance){

			halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
		}
			
	
	}
		
	void OnMouseOver(){
		
		if(Vector3.Distance(gameObject.transform.position,player.transform.position) < maxDistance && gameController.timeReset == false){

		
			if(gameController.moment == 1 && gameObject.CompareTag("LevelPresent")){

				halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
			}

			if(gameController.moment == 0 && gameController.firstShot && gameObject.CompareTag("LevelPast")){

				halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
			}
		}

	}

	void OnMouseExit(){

		halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
	}


}
