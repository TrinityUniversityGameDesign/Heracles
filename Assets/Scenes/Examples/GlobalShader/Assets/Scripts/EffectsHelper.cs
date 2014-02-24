using UnityEngine;
using System.Collections;

public class EffectsHelper : MonoBehaviour {

	public static EffectsHelper Instance;

	public GameObject explosion;

	void Awake() {
		if(Instance != null)
			Debug.LogError ("EffectsHelper Instance already made!");
		Instance = this;
	}

	public void Explode(Vector2 position) {
		GameObject instance = Instantiate (explosion, position, Quaternion.identity) as GameObject;
		Destroy (instance, 1);
	}

}
