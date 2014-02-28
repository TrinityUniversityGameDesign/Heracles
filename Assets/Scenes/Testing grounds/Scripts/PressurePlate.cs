using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	public GameObject playerObject;
	public int isPressed = 0;
	public float speed = 1f;
	public float tick = .1f;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindWithTag("P1");
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.rigidbody2D.mass >= 1) {
			isPressed++;
			//other.gameObject.rigidbody2D.velocity = new Vector2(0, 0);
			gotPressed();
				}
	}
	void OnTriggerExit2D (Collider2D other) {
			isPressed -= 1;
		gotReleased (); 
	}

	void gotPressed() {
				if (isPressed == 1) {
					gameObject.renderer.material.color = Color.grey; 
				}
	}
	void gotReleased(){
		if (isPressed == 0) {
					gameObject.renderer.material.color = Color.yellow; 

				}
		}
}
