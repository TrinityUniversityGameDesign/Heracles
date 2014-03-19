using UnityEngine;
using System.Collections;

public class audioScript : MonoBehaviour {
	//public GameObject player;
	//public AudioClip theme;
	public AudioClip footsteps;

	// Use this for initialization
	void Start () {
		//player = gameObject.FindWithTag("P1");
		PlayerControl playerControl = this.GetComponent<PlayerControl>();
		if (playerControl.groundCheck) {
			audio.clip = footsteps;
			audio.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
