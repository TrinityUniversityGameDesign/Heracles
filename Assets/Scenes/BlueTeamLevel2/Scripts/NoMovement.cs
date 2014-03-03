using UnityEngine;
using System.Collections;

public class NoMovement : MonoBehaviour {

	float x;
	float y;
	float z;

	// Use this for initialization
	void Start () {
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		transform.position = new Vector3(x, y, z);
	}
}
