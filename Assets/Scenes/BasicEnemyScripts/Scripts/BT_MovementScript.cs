using UnityEngine;
using System.Collections;

public class BT_MovementScript : MonoBehaviour {

	// THIS IS NOT DONE AT ALL. WE PROBABLY/DEFINITELY WON'T USE IT, SO DON'T WORRY ABOUT IT.
	// THIS IS NOT DONE AT ALL. WE PROBABLY/DEFINITELY WON'T USE IT, SO DON'T WORRY ABOUT IT.
	// THIS IS NOT DONE AT ALL. WE PROBABLY/DEFINITELY WON'T USE IT, SO DON'T WORRY ABOUT IT.
	// THIS IS NOT DONE AT ALL. WE PROBABLY/DEFINITELY WON'T USE IT, SO DON'T WORRY ABOUT IT.
	// THIS IS NOT DONE AT ALL. WE PROBABLY/DEFINITELY WON'T USE IT, SO DON'T WORRY ABOUT IT.

	public string controlMethod = "ForceBased";

	// ConstantSpeed Variables
	public int directionX = 1;
	public int directionY = 1;
	public float speedX = 5f;
	public float speedY = 0f;

	// Use this for initialization
	void Start () {
		SetControlMethod(controlMethod);
	}
	
	// Update is called once per frame
	void Update () {
		if (controlMethod == "ConstantSpeed")
			transform.position = new Vector3 (transform.position.x+(speedX*directionX),transform.position.y+(speedY*directionY),transform.position.z);
	}

	public void SetControlMethod(string newMethod) {
		controlMethod = newMethod;
	}

	public void SetConstantSpeed(int dX, int dY, float sX, float sY) {
		directionX = dX;
		directionY = dY;
		speedX = sX;
		speedY = sY;
	}
}