﻿using UnityEngine;
using System.Collections;

public class videoplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		((MovieTexture)GetComponent<Renderer> ().material.mainTexture).loop = true;
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
