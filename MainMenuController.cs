using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public Image selectedOption;

	bool onSettings = false;
	public GameObject settingsOptions;

	public GameObject gameSettings;
	bool onGameSettings, onSoundSettings, onGraphicSettings, onControlSettings = false;

	string chosenLanguage = "English";
	public Text chosenLanguageText;

	public GameObject[] OptionsSlots;

	public string graphicOption;
	public GameObject enabled, disabled;
	bool antialiasingOn,ssAOOn,DoFOn = false;
	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){

		selectedOption.gameObject.SetActive (true);
	}

	void OnMouseOver(){

	}

	void OnMouseExit(){

		selectedOption.gameObject.SetActive (false);
	}

	public void NewGame(){

		SceneManager.LoadScene ("ProjectEcho");
	}

	public void Credits(){

		SceneManager.LoadScene ("Credits");
	}

	public void SeeLevel2(){

		SceneManager.LoadScene ("Level2");
	}

	public void Settings(){

		ShowSettings ();
	}

	//Exit game

	public void GameSettings(){

		ShowGameSettings ();

	}

	public void SoundSettings(){

		ShowSoundSettings ();

	}

	public void GraphicSettings(){

		ShowGraphicSettings ();

	}

	public void GraphicOptions(){
		GraphicOptionsManager ();
	}

	public void ControlSettings(){

		ControlsManager ();
	}

	public void MainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void ExitApplication(){

		Application.Quit ();
	}

	void ShowSettings(){

		if (onSettings == false) {

			onSettings = true;
			settingsOptions.SetActive (true);

		} else {
			onSettings = false;
			settingsOptions.SetActive (false);
		}

	}

	void ShowGameSettings(){

		if (onGameSettings == false) {

			onGameSettings = true;
			gameSettings.SetActive (true);
			DesactivateOptions ("GameSettings");
		} else {

			onGameSettings = false;
			gameSettings.SetActive (false);
		}

	}

	void ShowSoundSettings(){

		if (onSoundSettings == false) {
			onSoundSettings = true;
			gameSettings.SetActive (true);
			DesactivateOptions ("SoundSettings");
		} else {

			onSoundSettings = false;
			gameSettings.SetActive (false);
		}

	}

	void ShowGraphicSettings(){

		if (onGraphicSettings == false) {
			onGraphicSettings = true;
			gameSettings.SetActive (true);
			DesactivateOptions ("GraphicSettings");
		} else {

			onGraphicSettings = false;
			gameSettings.SetActive (false);
		}

	}

	public void ChangeLanguage(){

		if(chosenLanguage == "English"){

			chosenLanguage = "Spanish";
			chosenLanguageText.text = "" + chosenLanguage;

		}else if(chosenLanguage == "Spanish"){

			chosenLanguage = "English";
			chosenLanguageText.text = "" + chosenLanguage;
		}
	}

	void GraphicOptionsManager(){

		if(graphicOption == "AntiAliasing"){

			if (antialiasingOn == false) {
				antialiasingOn = true;
				enabled.SetActive (true);
			} else {

				antialiasingOn = false;
				enabled.SetActive (false);
			}
		}
		if(graphicOption == "SSAO"){

			if (ssAOOn == false) {
				ssAOOn = true;
				enabled.SetActive (true);
			} else {

				ssAOOn = false;
				enabled.SetActive (false);
			}
		}

		if(graphicOption == "DoF"){

			if (DoFOn == false) {
				DoFOn = true;
				enabled.SetActive (true);
			} else {

				DoFOn = false;
				enabled.SetActive (false);
			}
		}
	}

	void ControlsManager(){

		if (onControlSettings == false) {
			onControlSettings = true;
			gameSettings.SetActive (true);
			DesactivateOptions ("ControlSettings");
		} else {

			onControlSettings = false;
			gameSettings.SetActive (false);
		}

	}

	void DesactivateOptions(string notDesactivate){

		if(notDesactivate == "GameSettings"){

				OptionsSlots [1].gameObject.SetActive (false);
				OptionsSlots [2].gameObject.SetActive (false);
				OptionsSlots [3].gameObject.SetActive (false);
		}

		if(notDesactivate == "SoundSettings"){

			OptionsSlots [0].gameObject.SetActive (false);
			OptionsSlots [2].gameObject.SetActive (false);
			OptionsSlots [3].gameObject.SetActive (false);
		}

		if(notDesactivate == "GraphicSettings"){

			OptionsSlots [0].gameObject.SetActive (false);
			OptionsSlots [1].gameObject.SetActive (false);
			OptionsSlots [3].gameObject.SetActive (false);
		}

		if(notDesactivate == "ControlSettings"){

			OptionsSlots [0].gameObject.SetActive (false);
			OptionsSlots [1].gameObject.SetActive (false);
			OptionsSlots [2].gameObject.SetActive (false);
		}
	}



}
