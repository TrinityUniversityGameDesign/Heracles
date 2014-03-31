using UnityEngine;
using System.Collections;

public class mainThemeAudio : MonoBehaviour {
	// Use this for initialization
	public AudioClip backgroundMusic;
	private static mainThemeAudio instance = null;
	public static mainThemeAudio Instance {
		get { return instance; }
	}
	void Awake() {
		audio.clip = backgroundMusic;
		audio.Play ();
		if (instance != null && instance != this) {
			Destroy(this.gameObject);

			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	void Start () {
	}

	void MusicChange(AudioClip changeMusic) {
		audio.Stop ();
		audio.clip = changeMusic;
		audio.Play ();
	}

	// Update is called once per frame
	void Update () {

	}
}
