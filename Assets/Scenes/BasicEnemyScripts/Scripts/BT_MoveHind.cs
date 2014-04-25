using UnityEngine;
using System.Collections;

public class BT_MoveHind : MonoBehaviour {

	public bool stopHind = true;
	public bool slowHind = true;
	public string setDirection = "right";
	public float jumpForce;
	public float speed;
	public bool destroyHind = false;
	private bool ignore = false;
	private int count = 0;
	
	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer>().enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (destroyHind) {
			Destroy(other.gameObject);
			GetComponent<BoxCollider2D>().enabled = false;
		}
		if (other.tag == "Hind" && !ignore) {
			Debug.Log("hittinghind");
			ignore = true;
			if (stopHind) {
				other.gameObject.GetComponent<BT_HindScript>().StopHind();
				other.gameObject.GetComponent<CircleCollider2D>().enabled = true;
				other.gameObject.GetComponents<BoxCollider2D>()[0].isTrigger = false;
			}
			other.gameObject.GetComponent<BT_HindScript>().SetJumpForce(jumpForce);
			other.gameObject.GetComponent<BT_HindScript>().SetSpeed(speed);
			other.gameObject.GetComponent<BT_HindScript>().SetDirection(setDirection);
			if (slowHind)
				other.gameObject.GetComponent<BT_HindScript>().SlowToStop();
			GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		ignore = false;
	}

}
