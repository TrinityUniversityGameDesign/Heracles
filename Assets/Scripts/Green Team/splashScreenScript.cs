﻿using UnityEngine;
using System.Collections;

public class splashScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) Application.LoadLevel("PS_Checkpoint_TestScene");
	
	}
}