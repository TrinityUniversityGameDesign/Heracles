using UnityEngine;
using System.Collections;

public class audioScript : MonoBehaviour {
	//public GameObject player;
	//public AudioClip theme;
	public AudioClip footsteps;

	private static audioScript instance = null;
	public static audioScript Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

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
