using UnityEngine;
using System.Collections;

public class mainThemeAudio : MonoBehaviour {
	// Use this for initialization
	public AudioClip backgroundMusic;
	public AudioClip cerberusTheme;
	private static mainThemeAudio instance = null;
	public static mainThemeAudio Instance {
		get { return instance; }
	}
	public static bool cerberusFlag = false;
	bool cerbLoopStop = false;
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
		if (cerberusFlag && !cerbLoopStop) {
			audio.Stop ();
			audio.clip = cerberusTheme;
			audio.Play();
			cerbLoopStop = true;
		}

	}
}
