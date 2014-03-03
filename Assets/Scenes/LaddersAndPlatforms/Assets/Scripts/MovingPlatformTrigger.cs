﻿using UnityEngine;
using System.Collections;

public class MovingPlatformTrigger : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other) {
		other.transform.parent = gameObject.transform;
	}
	void OnTriggerExit2D(Collider2D other) {
		other.transform.parent = null;
	}
}
