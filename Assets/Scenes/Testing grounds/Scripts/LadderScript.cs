using UnityEngine;
using System.Collections;

public class LadderScript : MonoBehaviour {

	public GameObject playerObject;
	bool canClimb = false;
	public float speed = 1f;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindWithTag("P1");
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
						playerObject.rigidbody2D.gravityScale = 1;
				}
	}
	// Update is called once per frame
	void Update () {
		if (canClimb) {
			if(Input.GetKey(KeyCode.Q)) {
				playerObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime*speed);
			}
			if(Input.GetKey (KeyCode.E)) {
				playerObject.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime*speed);
			}
		}
	}
}
