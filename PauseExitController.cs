using UnityEngine;
using System.Collections;

public class PauseExitController : MonoBehaviour {

	GameObject child;
	// Use this for initialization
	void Start () {

		child = gameObject.transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HighLighted(){

		child.SetActive (true);
	}

	public void NoHighLighted(){

		child.SetActive (false);
	}


}
