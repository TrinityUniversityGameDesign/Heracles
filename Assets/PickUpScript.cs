using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

	public GameObject playerObject;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindWithTag("P1");
	}

	void OnTriggerEnter2D (Collider2D other) {
		Destroy(gameObject);	
	}
}