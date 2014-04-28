using UnityEngine;
using System.Collections;

public class DisableRenderer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer>().enabled = false;
	}

}
