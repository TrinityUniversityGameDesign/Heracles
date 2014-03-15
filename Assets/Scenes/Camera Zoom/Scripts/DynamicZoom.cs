using UnityEngine;
using System.Collections;

public class DynamicZoom : MonoBehaviour {

	// Dynamic Zoom Triggers allow the level designer to specify a zoom level between 1 and 10

	public float newZoom = 5;
	public float speed = 1;
	public bool isOneUse = true;

	void Start() {
		GetComponent<MeshRenderer>().enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "P1") {
			Camera.main.GetComponent<CameraZoom>().SetZoomSpeed(speed);
			Camera.main.GetComponent<CameraZoom>().SetZoom(newZoom);
			if (isOneUse)
				GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	public void setZoomSize(float newZoomSize) {
		newZoom = newZoomSize;
	}
}
