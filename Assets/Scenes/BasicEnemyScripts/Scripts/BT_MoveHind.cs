using UnityEngine;
using System.Collections;

public class BT_MoveHind : MonoBehaviour {

	public bool stopHind = true;
	public bool slowHind = true;
	public string setDirection = "right";
	private bool ignore = false;
	private int count = 0;
	
	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer>().enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Hind" && !ignore) {
			if (stopHind)
				other.gameObject.GetComponent<BT_HindScript>().StopHind();
			other.gameObject.GetComponent<BT_HindScript>().SetDirection(setDirection);
			if (slowHind)
				other.gameObject.GetComponent<BT_HindScript>().SlowToStop();
			ignore = true;
			//GetComponent<BoxCollider2D>().isTrigger = true;
			GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		ignore = false;
	}

}
