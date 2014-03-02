using UnityEngine;
using System.Collections;

public class LadderScript : MonoBehaviour {

	public GameObject playerObject;
	bool canClimb = false;
	public float speed = 1f;
	float grav = 1;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindWithTag("P1");
		grav = playerObject.rigidbody2D.gravityScale;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == playerObject) {
						canClimb = true;
						playerObject.rigidbody2D.gravityScale = 0;
				}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject == playerObject) {
						canClimb = false;
						playerObject.rigidbody2D.gravityScale = grav;
				}
	}
	// Update is called once per frame
	void Update () {
		if (canClimb) {
			//playerObject.gameObject.GetComponent<PlayerControl>().enabled = false;
			if(Input.GetKey(KeyCode.W)) {
				playerObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime*speed);
			}
			if(Input.GetKey (KeyCode.S)) {
				playerObject.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime*speed);
			}
		}
		//else
			//playerObject.gameObject.GetComponent<PlayerControl>().enabled = true;
	}
}
