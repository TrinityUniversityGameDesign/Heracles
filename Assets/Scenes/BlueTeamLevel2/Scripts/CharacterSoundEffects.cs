using UnityEngine;
using System.Collections;

public class CharacterSoundEffects : MonoBehaviour {
	
	AudioClip jumpAudio;
	bool jump;
	public string jumpAxisName = "Vertical";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		bool jump = Input.GetButtonDown (jumpAxisName);
		if (jump) {
			//audio.PlayOneShot();							
		}
	}
}
