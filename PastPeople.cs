using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PastPeople : MonoBehaviour {

	public GameObject dialogueIcon;
	public GameController gameController;
	bool isIconOn,activateDialogue,onDialogue;
	public GameObject dialogueBox,logo;
	public Text dialogueText;

	public string [] strings; // array de lineas de textos
	public float dialogueSpeed = 0.05f;
	int stringIndex = 0; 
	int characterIndex = 0;
	int numberOfSentences = 3;

	bool playerCollides = false;
	LevelManager levelManager;

	public string person;
	AlexDialogueLvl_1andTutorial monologue;
	// Use this for initialization
	void Start () {

		levelManager = gameController.GetComponent<LevelManager> ();
		monologue = GameObject.FindGameObjectWithTag ("Player").GetComponent<AlexDialogueLvl_1andTutorial> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(isIconOn && Input.GetKeyDown(KeyCode.Mouse0)){

			activateDialogue = true;

			PastPeopleDialogue ();

			if(gameObject.name.Contains("HombreMantenimiento")){

				levelManager.searchForCoin.SetActive (true);
			}
		}

		if(onDialogue == true){

			if(Input.GetKeyDown(KeyCode.Mouse0)){


				if (characterIndex < strings [stringIndex].Length) {

					characterIndex = strings [stringIndex].Length;

				} else if (stringIndex < strings.Length) {

					Debug.Log (stringIndex);
					stringIndex++;
					characterIndex = 0;
					logo.SetActive (false);

					if(stringIndex >= strings.Length){

						dialogueBox.SetActive (false);
						activateDialogue = false;
						onDialogue = false;
						stringIndex = 0;
						characterIndex = 0;

					}

				}

			}

		}

	}

	void OnMouseOver ()
	{
		if(gameController.moment == 0){

			if(playerCollides == true){

				dialogueIcon.SetActive (true);
				isIconOn = true;
			}

		}

	}

	void OnMouseExit ()
	{
		if(gameController.moment == 0){

			if(playerCollides == true){

				dialogueIcon.SetActive (false);
				isIconOn = false;
			}

		}
	}

	public void PastPeopleDialogue(){

		monologue.talker.text = "" + person;

		dialogueBox.SetActive (true);
		stringIndex = 0;
		characterIndex = 0;
		StartCoroutine ("DisplayTimer");
	}

	IEnumerator DisplayTimer(){

		while (activateDialogue == true) { //1 == 1
			yield return new WaitForSeconds (dialogueSpeed);

				if(characterIndex > strings [stringIndex].Length){

					continue;
				}

			dialogueText.text = strings [stringIndex].Substring (0, characterIndex);
			characterIndex++;
			onDialogue = true; //pongo esto para esperar un poco en el tiempo de ejecucion. 


			if (characterIndex >= strings [stringIndex].Length) {

				logo.SetActive (true);

			}


		}
	}

	void OnTriggerEnter(Collider collider){

		if (collider.CompareTag ("Player")) {
			playerCollides = true;
			dialogueIcon.SetActive (true);
		}
	}

	void OnTriggerExit(Collider collider){

		if (collider.CompareTag ("Player")) {
			playerCollides = false;
			dialogueIcon.SetActive (false);
		}
	}
}
