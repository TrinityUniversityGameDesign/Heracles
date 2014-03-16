using UnityEngine;
using System.Collections;

public class dragAudio : MonoBehaviour {
	public AudioClip dragSound;
	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter () {
		audio.clip = dragSound;
		audio.Play();
	}
	// Update is called once per frame
	void Update () {

	}
}
