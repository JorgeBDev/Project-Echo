using UnityEngine;
using System.Collections;

public class PlayAnim : MonoBehaviour {

	Animator animator;
	public Inventory inventory;
	public TextBoxController textBoxController;
	bool triggerCorrutine = false;


	float wait = 2.0f;

	public GameObject firstDoor;

	// Use this for initialization
	void Start () {

		//animator = GetComponent<Animator>(); 29/3

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider collider){
		/*
		if (collider.CompareTag ("Player") && Input.GetKeyDown(KeyCode.Q) && inventory.card1 == true) {
			//triggerCorrutine = true;
			//animator.SetBool ("Open",true);
			/*
			if(triggerCorrutine){
				StartCoroutine (NextStep (wait));
			}

				inventory.card1 = false;
			triggerCorrutine = false;
		}
		*/


	}

	IEnumerator NextStep(float wait){

		yield return new WaitForSeconds (wait);
		textBoxController.NextStep ();
	}

	public void PlayAnimation(string name){
		
		if(name == "FirstDoor"){

			animator = firstDoor.GetComponent<Animator>();
			Debug.Log (animator.transform.parent);
			animator.SetBool ("Opened",true);
		}
			
	}
		



		
}
