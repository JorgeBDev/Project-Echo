using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform characterTarget;
	public GameObject player;
	private Vector3 offset;

	public bool smoothOn = true;
	private float smoothSpeed = 0.125f;

	public float limUp = 439;
	public float limDown = 437;

	float limRight = -3298;
	float limLeft = -3400;

	private GameController gameController;
	public int nivel;
	// Use this for initialization
	void Start () {

		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		offset = transform.position - player.transform.position; //OLD

		if(gameController.level == 2){

			limUp = 3.1f;
			limDown = -7.80f;
			
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate(){
		
		transform.position = new Vector3 (player.transform.position.x,this.transform.position.y,this.transform.position.z); //OLD

		Vector3 desiredPosition = new Vector3(player.transform.position.x+ offset.x,player.transform.position.y + offset.y, player.transform.position.z+ offset.z);
		desiredPosition.y = Mathf.Clamp (desiredPosition.y, limDown, limUp);

		if (smoothOn) {

			transform.position = Vector3.Lerp (new Vector3(transform.position.x, transform.position.y,transform.position.z), new Vector3(transform.position.x, desiredPosition.y,transform.position.z), smoothSpeed);
			//transform.position = Vector3.Lerp (new Vector3(transform.position.x, transform.position.y,transform.position.z), new Vector3(desiredPosition.x, desiredPosition.y,transform.position.z), smoothSpeed);

			transform.position= new Vector3 (player.transform.position.x+offset.x, this.transform.position.y, player.transform.position.z+offset.z);
			if(nivel == 1){

				desiredPosition.x = Mathf.Clamp (transform.position.x, limLeft, limRight);
			}

			transform.position= new Vector3 (desiredPosition.x, this.transform.position.y, this.transform.position.z);

		} else {

			transform.position = desiredPosition;
		}
	

	}


}
