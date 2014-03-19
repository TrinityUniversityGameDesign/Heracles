using UnityEngine;
using System.Collections;

public class dragAudio : MonoBehaviour {
	public AudioClip dragSound;
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter (Collider col) {
		//if (col.gameObject.tag == "Crate") {
			audio.clip = dragSound;
			audio.Play();
		//}
	}

	void OnTriggerExit (Collider col) {
		audio.Stop ();
	}

	// Update is called once per frame
	void Update () {
	}
}
