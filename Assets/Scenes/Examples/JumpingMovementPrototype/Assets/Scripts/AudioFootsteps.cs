using UnityEngine;
using System.Collections;

public class AudioFootsteps : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var Sound = AudioClip
		footstepsEvent()
	}

	void  footstepsEvent (){
		var footstepsEvent= new AnimationEvent();
		footstepsEvent.functionName = "footstepsSound";        
		footstepsEvent.time = 0.0f;
		animation["footsteps"].layer = 1;
			animation["footsteps"].clip.AddEvent(footstepsEvent); // Add the event to an AnimationClip
			animation["footsteps"].wrapMode = WrapMode.Once;
			animation.Play("footsteps");
	}

	// Update is called once per frame
	void Update () {
			if (PlayerControl.grounded) {

			}
			//if something; map input
				//if footsteps is not playing
			//audio.Play();
	}
}
