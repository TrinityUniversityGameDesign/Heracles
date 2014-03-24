using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	public GameObject childObj;
	private PressurePlateChildScript childScript;
	public int isPressed = 0;

	// Use this for initialization
	void Start () {
		GameObject childObj = gameObject.transform.Find("PressureChild").gameObject;
		childScript = childObj.GetComponent<PressurePlateChildScript>();
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
			childScript.activate_Me = true; 
		}
	}
	void gotReleased(){
		if (isPressed <= 0) {
			isPressed = 0;
					gameObject.renderer.material.color = Color.yellow; 
			childScript.activate_Me = false; 
				}
		}
}
