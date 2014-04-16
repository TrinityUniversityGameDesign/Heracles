using UnityEngine;
using System.Collections;

public class TwoWayPlatform : MonoBehaviour {

	public bool AllowUp = true;
	public bool AllowDown = false;
	public bool isInvisible = false;

	// Use this for initialization
	void Start () {
		if (isInvisible) {
			//GetComponent<SpriteRenderer>().enabled = false;
			Color temp = GetComponent<SpriteRenderer>().material.color;
			temp.a = 0.14f;
			GetComponent<SpriteRenderer>().material.color = temp;
		}
		if (!AllowUp)
			GetComponents<BoxCollider2D>()[1].isTrigger = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (AllowDown && Input.GetButton("Down")) {
			GetComponents<BoxCollider2D>()[0].enabled = false;
			if (!AllowUp)
				GetComponents<BoxCollider2D>()[1].isTrigger = true;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "P1" && other.rigidbody2D.velocity.y > 0 && AllowUp || other.GetComponent<PlayerControl>().IsClimbing())
			GetComponents<BoxCollider2D>()[0].enabled = false;
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "P1") {
			GetComponents<BoxCollider2D>()[0].enabled = true;
			if (!AllowUp)
				GetComponents<BoxCollider2D>()[1].isTrigger = false;
		}
	}
}