using UnityEngine;
using System.Collections;

public class CharacterBehaviour : MonoBehaviour
{

	public float speed = 7f, rotSpeed = 900f;
	public float jumpValue = 150f;
	public float jumpGravity = 2;
	public float jumpSpeed = 7;
	public float iniHeight = 1;
	public float iniJumpValue = 150;

	//fuerza de salto

	public bool onJump = false;
	public float height = 1;
	//vale 1 para fisiscas) //altura a la que llegará en Y
	public float gravity = 5f;

	public float movX = 0, movZ = 0;
	private bool floorContact = false;

	public bool lookingRight;
	public bool lookingLeft;

	public Animator animator;
	public bool goingToPoint = false;
	Vector3 stopPosition;
	public bool canIdle = true;

	bool jumpBug = true;

	public GameObject alexMesh;
	float waitTime;
	public bool playerDead,running,auxiliarRunning = false;
	//private float zPosition = -6.0f;

	public GameObject dialogueBox;
	public GameController gamecontroller;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

		if(playerDead == false){

			playerMovement ();
		}

		if(Input.GetKey(KeyCode.LeftShift)){
			running = true;
			Running ();
		}

		if(running == true && Input.GetKeyUp(KeyCode.LeftShift)){
			running = false;
			NotRunning ();
		}

		if(dialogueBox.activeInHierarchy && movX != 0){

			animator.SetBool ("Run",false);
		}
			

	}

	public void playerMovement(){

		if(!dialogueBox.gameObject.activeInHierarchy && gamecontroller.onTutorial == false){

			alexMesh.transform.localPosition = new Vector3 (0,0,0);

			movX = Input.GetAxis ("Horizontal");
			movZ = Input.GetAxis ("Vertical");

			/*

			if (Input.GetKeyDown (KeyCode.Space) && !onJump && (lookingRight == true || lookingLeft == true)) {

				onJump = true;
				animator.SetBool ("OnJump",true);
				animator.SetBool ("FloorContact",false);
			}

			if (onJump) {
				height = -jumpValue; // -valot jump se complementa con el -9.8 (gravity), dando asi un valor positivo: menos por menos = mas
				//jumpValue -= speed * Time.deltaTime; // comentado el 29/5 para ajustar la altura del salto
				jumpValue -= jumpSpeed * Time.deltaTime;


				if (jumpValue < 0 && floorContact) {
					//animator.Play ("Arriving");
					height = iniHeight;
					jumpValue = iniJumpValue;
					onJump = false;
					animator.SetBool ("OnJump",false);
					animator.SetBool ("FloorContact",true);
				}

				floorContact = false;
			}
			*/

			if (Time.timeScale == 1) {
				Vector3 moveDirection = new Vector3 (movX * speed, -gravity * height, movZ * speed * 0);
				moveDirection = transform.TransformDirection (moveDirection); //* Time.deltaTime * 100f
				//el 2 es para agilizar la velocidad, ya que 9.8 siempre está actuando sobre el cuerpo

				if (lookingRight) {
					GetComponent<Rigidbody> ().velocity = new Vector3 (moveDirection.x * 1.3f, moveDirection.y, moveDirection.z * 0f);
				}

				if (lookingLeft) {
					GetComponent<Rigidbody> ().velocity = new Vector3 (moveDirection.x * -1.3f, moveDirection.y, moveDirection.z * 0f);
				}

				GetComponent<Rigidbody> ().AddForce (Vector3.forward);

				if (Input.GetKey (KeyCode.D) && movX > 0 && !onJump) {
					//animator.Play ("Run");
					animator.SetBool ("Run", true);
					movX = 1;
					transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (new Vector3 (0, 0, 0)), rotSpeed * Time.deltaTime);
					lookingRight = true;
					lookingLeft = false;


				}


				if (Input.GetKey (KeyCode.A) && movX < 0 && !onJump) {
					animator.SetBool ("Run", true);
					movX = -1;
					transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (new Vector3 (0, -180f, 0)), rotSpeed * Time.deltaTime);
					lookingLeft = true;
					lookingRight = false;
				}

				if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) {
					//animator.Play ("Idle");
					animator.SetBool ("Run", false);
				}

				if (movX > 0.1f && movX < 0.9f) {

					movX = 0;
				}

				if (movX < -0.1f && movX > -0.9f) {

					movX = 0;
				}


			}
		}



		animator.SetFloat ("movX", movX); 
	} 

	void OnCollisionEnter (Collision suelo)
	{

		floorContact = true;
	}

	public void LookTowards (Transform closePosition)
	{

		Vector3 headingtarget = closePosition.transform.position - transform.position;

		if (transform.position.x < closePosition.transform.position.x) {

			transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (new Vector3 (0, 0, 0)), rotSpeed * Time.deltaTime);
		}

		if (transform.position.x > closePosition.transform.position.x) {

			transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (new Vector3 (0, -180f, 0)), rotSpeed * Time.deltaTime);
		}

	}

	public void PlayAlexAnim (string anim)
	{

		if (anim == "Run") {
			animator.SetBool ("Run", true);
		}

		//ESTOY HACIENDO QUE PARE AL GOINT TO POINT SER FALSE. QUE PASE A IDLE
		if (anim == "Idle") {
			animator.SetBool ("Run", false);
		}
		//

		if (anim == "Travel") {
			animator.SetBool ("Travel", true);
			StartCoroutine ("WaitForAlexAnimation", "TimeTravel");
		}


		if (anim == "Shot") {

			animator.SetBool ("TimeShot", true);
			StartCoroutine ("WaitForAlexAnimation", "TimeShot");

		}

		if (anim == "Jump") {
			animator.SetBool ("OnJump", true);
		}

		if(anim == "Card"){

			animator.SetBool("UseCard",true);
			StartCoroutine ("WaitForAlexAnimation","UseCard");
			//animator.SetBool("UseCard",false);
		}

		if (anim == "Shocked") {
			animator.SetBool ("Shocked", true);
		}

	}

	public void GoToPoint(bool going){

		if (going == true) {

			animator.SetBool ("Run", true);
		}else{
			animator.SetBool ("Run", false);
		}
	}

	IEnumerator WaitForAlexAnimation (string animation)
	{

		yield return new WaitForSecondsRealtime (0.1f);
		if (animation == "TimeTravel") {
			animator.SetBool ("Travel", false);
		}
		//animator.SetBool ("Travel", false); 19/6. Esto estaba fuera del if no sé por qué

		if (animation == "TimeShot") {

			animator.SetBool ("TimeShot", false);
		}

		if (animation == "UseCard") {

			animator.SetBool ("UseCard", false);
		}
	}

	void Running (){

		speed = 7.0f;
	}

	void NotRunning (){

		speed = 5.0f;
	}

	public void StopShockedAnimation(){

		animator.SetBool ("Shocked", false);
		animator.SetBool ("Run",false);
		animator.Play ("Idle");
	}

	public void CancelRunAnimation(){

		animator.SetBool ("Run",false);
	}

}

