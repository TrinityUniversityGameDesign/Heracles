using UnityEngine;
using System.Collections;

public class OnToSecondLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("P1")) {
			Application.LoadLevel("Level Blue 2");		
		}

	}
}
