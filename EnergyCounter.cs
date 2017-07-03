using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnergyCounter : MonoBehaviour {

	[SerializeField]
	private float fillAmountEnergy;
	[SerializeField]
	private Image energyContent;

	public HUD gameController;

	public float MaxValue {
		get;
		set;
	}

	public float Value{
		set
		{
			fillAmountEnergy = Map(gameController.timeCounter,0,gameController.MaxtimeCounter,0,1);
		}
	}
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
		EnergyBar ();
	}

	private void EnergyBar(){

		if(fillAmountEnergy != energyContent.fillAmount){

			energyContent.fillAmount = fillAmountEnergy;
		}

	}

	private float Map(float value,float inMin, float inMax,float outMin, float outMax){

		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
