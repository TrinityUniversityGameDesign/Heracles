using UnityEngine;
using System.Collections;

public class OffCamera : MonoBehaviour {
	
	public PlayerControl pc;
	public Camera cp;
	float cameraX;
	public float newCX;
	public float newCY;


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
			cp.transform.position.Set(newCX, newCY, cp.transform.position.z);
		}
	}
}
