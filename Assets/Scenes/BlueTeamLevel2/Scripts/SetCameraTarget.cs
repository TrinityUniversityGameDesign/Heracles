using UnityEngine;
using System.Collections;

public class SetCameraTarget : MonoBehaviour {

	public Transform target;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "P1")
			Camera.main.GetComponent<CameraFollow>().SetTarget(target);
	}
}
