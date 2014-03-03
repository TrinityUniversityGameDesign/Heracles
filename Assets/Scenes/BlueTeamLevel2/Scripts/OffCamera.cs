using UnityEngine;
using System.Collections;

public class OffCamera : MonoBehaviour {
	
	public PlayerControl pc;
	public Camera cp;
	float cameraX;
	public float newCX = 400f;
	public float newCY = 400f;


	//Use this for initialization
	void Start () {
		pc.jumpPower = 0f;

		cameraX = cp.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

		float playerX = transform.position.x;

		if(playerX > cameraX) {
			cp.orthographicSize = 5;
			pc.jumpPower = 400f;
			cp.transform.position = new Vector3 (newCX, newCY, cp.transform.position.z);
		}
	}
}
