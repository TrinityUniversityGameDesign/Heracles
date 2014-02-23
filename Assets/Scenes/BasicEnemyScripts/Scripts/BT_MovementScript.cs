using UnityEngine;
using System.Collections;

public class BT_MovementScript : MonoBehaviour {

	// THIS IS NOT DONE AT ALL. WE PROBABLY/DEFINITELY WON'T USE IT, SO DON'T WORRY ABOUT IT.
	// THIS IS NOT DONE AT ALL. WE PROBABLY/DEFINITELY WON'T USE IT, SO DON'T WORRY ABOUT IT.
	// THIS IS NOT DONE AT ALL. WE PROBABLY/DEFINITELY WON'T USE IT, SO DON'T WORRY ABOUT IT.
	// THIS IS NOT DONE AT ALL. WE PROBABLY/DEFINITELY WON'T USE IT, SO DON'T WORRY ABOUT IT.
	// THIS IS NOT DONE AT ALL. WE PROBABLY/DEFINITELY WON'T USE IT, SO DON'T WORRY ABOUT IT.

	public string controlMethod = "Programmable";

	// ConstantSpeed Variables
	public int directionX = 1;
	public int directionY = 1;
	public float speedX = 5f;
	public float speedY = 0f;

	private float[][] Pattern = new float[2][];

	private int index = 0;
	private float mSpeedX = 0f, mSpeedY = 0f;
	private Vector3 destinationPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		SetControlMethod(controlMethod);
		Pattern[0] = new float[] {10f,0f,0.2f,0f};
		Pattern[1] = new float[] {-10f,0f,-0.2f,0f};
		destinationPosition = transform.position;
		IteratePattern();
	}
	
	// Update is called once per frame
	void Update () {
		if (controlMethod == "Programmable") {
			if (Vector3.Distance(transform.position, destinationPosition) > 0.1)
				transform.position = new Vector3(transform.position.x+mSpeedX, transform.position.y+mSpeedY,transform.position.z);
			else
				IteratePattern();
		}
		else if (controlMethod == "ConstantSpeed")
			transform.position = new Vector3 (transform.position.x+(speedX*directionX),transform.position.y+(speedY*directionY),transform.position.z);
	}
	
	void IteratePattern() {
		transform.position = destinationPosition;
		destinationPosition = new Vector3 (transform.position.x+Pattern[index][0],transform.position.y+Pattern[index][1],transform.position.z);
		mSpeedX = Pattern[index][2];
		mSpeedY = Pattern[index][3];
		index++;
		if (index > Pattern.Length-1)
			index = 0;
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