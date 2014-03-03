using UnityEngine;
using System.Collections;

public class DeathPart : MonoBehaviour {
	
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("P1")){
			player.transform.position = new Vector3 (18f, 4.3f, 0);
		}
	}
}
