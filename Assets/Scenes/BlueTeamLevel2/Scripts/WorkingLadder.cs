using UnityEngine;
using System.Collections;

public class WorkingLadder : MonoBehaviour {

	public float climbSpeed = 4;
	private GameObject player;
	private bool isClimbing = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("P1");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isClimbing) {
			float inputY = Input.GetAxis("Vertical");
			player.rigidbody2D.velocity = new Vector2 (player.rigidbody2D.velocity.x/3, inputY*climbSpeed);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "P1") {
			isClimbing = true;
			other.GetComponent<PlayerControl>().SetClimbing(true);
			other.rigidbody2D.gravityScale = 0;
			other.rigidbody2D.velocity = new Vector3();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "P1") {
			isClimbing = false;
			other.GetComponent<PlayerControl>().SetClimbing(false);
			other.rigidbody2D.gravityScale = 2.7f;
		}
	}
}