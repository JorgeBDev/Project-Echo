using UnityEngine;
using System.Collections;

public class PlaySprite : MonoBehaviour {

	Animator anim;
	public GameObject rightHand;
	float posx,posy,posz;
	GameObject travelFlare;
	void Start () {

		anim = gameObject.GetComponent<Animator> ();
		posz = this.gameObject.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = rightHand.transform.rotation;
		//posx = rightHand.transform.position.x;
		//posy = rightHand.transform.position.y;
		//this.transform.Translate (posx, posy, posz);
	}

	public void PlaySpriteAnim(){

		anim.SetBool ("On",true);
		StartCoroutine ("CloseSpritesWait");
	}

	IEnumerator CloseSpritesWait(){

		for(bool a=true;a==true;a=false){
			yield return new WaitForSecondsRealtime (0.1f);
			anim.SetBool ("On",false);
		}
	}
}
