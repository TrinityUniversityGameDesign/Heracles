using UnityEngine;
using System.Collections;

public class BT_MoveHind : MonoBehaviour {

	public bool stopHind = true;
	public bool slowHind = true;
	public string setDirection = "right";
	public float jumpForce;
	public float speed;
	public bool destroyHind = false;
	public bool beginSwitch = false;
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
		if (beginSwitch) {
			Destroy(GameObject.Find ("BlackAreaDeathZoneTrigger1"));
			GameObject[] hinds = GameObject.FindGameObjectsWithTag("Hind");
			foreach (GameObject hind in hinds) {
				hind.GetComponent<CircleCollider2D>().enabled = true;
				hind.GetComponent<BT_HindScript>().enabled = true;
				hind.GetComponent<SpriteRenderer>().enabled = true;
				hind.GetComponents<BoxCollider2D>()[0].enabled = true;
				hind.GetComponents<BoxCollider2D>()[1].enabled = true;
				hind.GetComponent<Animator>().enabled = true;
				hind.rigidbody2D.gravityScale = 2.7f;
			}
			GameObject[] paths = GameObject.FindGameObjectsWithTag("HindPath2");
			foreach (GameObject path in paths) {
				path.GetComponent<MoveHind2>().enabled = true;
				path.GetComponent<BoxCollider2D>().enabled = true;
			}
			GameObject[] oldPaths = GameObject.FindGameObjectsWithTag("HindPath1");
			foreach (GameObject path in oldPaths)
				Destroy(path);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		ignore = false;
	}

}
