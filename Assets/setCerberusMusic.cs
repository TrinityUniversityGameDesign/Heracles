using UnityEngine;
using System.Collections;

public class setCerberusMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "P1") {
			mainThemeAudio.cerberusFlag = true;
		}
	}
}
