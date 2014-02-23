using UnityEngine;
using System.Collections;

public class BT_DecayScript : MonoBehaviour {

	// DecayScript:
	// 		Destroys self after given delay

	public bool doDecay = true;
	public float destroyAfter = 2;

	// Use this for initialization
	void Start () {
		if (doDecay)
			Destroy (this.gameObject, destroyAfter);
	}
}
