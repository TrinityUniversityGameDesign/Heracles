using UnityEngine;
using System.Collections;

public class EnableFeatureScript : MonoBehaviour {
	
	public GameObject playerObject;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindWithTag("P1");
		playerObject.GetComponent<ShootingScript>().enabled = false;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		playerObject.GetComponent<ShootingScript>().enabled = true;
	}
}