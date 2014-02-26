using UnityEngine;
using System.Collections;

public class PositionLadderScript : MonoBehaviour {

	public GameObject playerObject;
	bool canClimb = false;
	public float speed = 1f;
	public float tick = .1f;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindWithTag("P1");
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == playerObject) {
						canClimb = true;
			playerObject.rigidbody2D.velocity = new Vector2(0, 0);
			// playerObject.rigidbody2D.gravityScale = 0;
				}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject == playerObject) {
						canClimb = false;

						playerObject.rigidbody2D.gravityScale = 2.7f;
				}
	}
	// Update is called once per frame
	void Update () {
		if (canClimb) {
			if(Input.GetKey(KeyCode.Q)) {
				playerObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y + tick, playerObject.transform.position.z);
				playerObject.rigidbody2D.gravityScale = 0; 

			/*	if(playerObject.transform.position.x < transform.position.x)
					playerObject.rigidbody2D.velocity = new Vector2 (1, playerObject.rigidbody2D.velocity.y) ;
				else
					playerObject.rigidbody2D.velocity = new Vector2 (-1, playerObject.rigidbody2D.velocity.y) ;
			*/
			}
			if(Input.GetKey (KeyCode.W)) {
				playerObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y + tick, playerObject.transform.position.z);
				playerObject.rigidbody2D.gravityScale = 0; 			}
		}
	}
}
