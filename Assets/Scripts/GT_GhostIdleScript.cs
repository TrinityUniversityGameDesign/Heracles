using UnityEngine;
using System.Collections;

public class GT_GhostIdleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 transScale = transform.localScale;
		transScale.x *= -1;
		transform.localScale = transScale;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
