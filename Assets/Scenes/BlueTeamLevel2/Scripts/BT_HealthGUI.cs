﻿using UnityEngine;
using System.Collections;

public class BT_HealthGUI : MonoBehaviour {

	public Texture2D healthUnit;
	private BT_HealthScript healthScript;

	void OnGUI() {
		int currentHealth = healthScript.GetHealth ();
		//Debug.Log ("current health: " + currentHealth.ToString ());
		int space = 50;
		for (int i=1; i <= currentHealth; i++)
		{
			GUI.DrawTexture (new Rect((20 + space*(i-1)),20,50,25), healthUnit, ScaleMode.ScaleToFit);
		}
	}

	// Use this for initialization
	void Start () {
		//healthUnit = (Texture2D)Resources.LoadAssetAtPath("Resources/TEMPheart.png", typeof(Sprite));
		healthScript = GetComponent<BT_HealthScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

