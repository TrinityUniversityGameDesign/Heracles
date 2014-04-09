using UnityEngine;
using System.Collections;

public class MovingPlatformTrigger2 : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "P1")
			other.transform.parent = gameObject.transform;
	}
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "P1")
			other.transform.parent = null;
	}
}
