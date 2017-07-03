using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public bool checkpointActivated;
	public GameObject[] checkPointList;
	private LevelManager levelManager;
	public GameObject lastCheckpoint;

	// Use this for initialization
	void Start () {

		checkPointList = GameObject.FindGameObjectsWithTag ("CheckPoint");
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		levelManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.J)){

			levelManager.BackToCheckPoint ();
		}
	}

	private void ActivateCheckPoint(){
		foreach(GameObject checkPoint in checkPointList){

			checkPoint.GetComponent<CheckPoint>().checkpointActivated = false;
		}
		checkpointActivated = true;
		lastCheckpoint = this.gameObject;
	}

	void OnTriggerEnter(Collider collider){

		if(collider.CompareTag("Player")){

			ActivateCheckPoint ();
			levelManager.UpdateCheckPoint (this.gameObject);
		}
	}

	public Vector3 GetActiveCheckpointPosition(){

		Vector3 result = new Vector3 (0,0,0);

		if(checkPointList != null){

			foreach(GameObject checkPoint in checkPointList){

				if(checkPoint.GetComponent<CheckPoint>().checkpointActivated == true){
					result = checkPoint.transform.position;
					break;
				}
			}
		}

		return result;
	}


}
