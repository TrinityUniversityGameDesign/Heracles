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

		if (instance != null && instance != this) {
			Destroy(this.gameObject);

			return;
		} else {
			instance = this;
			audio.clip = backgroundMusic;
			audio.Play();
		}
		DontDestroyOnLoad(this.gameObject);
	}

	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
		}
	}
}
