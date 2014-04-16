using UnityEngine;
using System.Collections;

public class SceneChangeScript : MonoBehaviour {

	public GameObject playerObject;
	public string level;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindWithTag("P1");
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == playerObject) {
			Application.LoadLevel (level);
		}
	}

}

