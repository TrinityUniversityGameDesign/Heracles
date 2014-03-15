using UnityEngine;
using System.Collections;

public class PresetZoom : MonoBehaviour {

	// Preset Zoom Triggers will either zoom in/out to preset 

	public bool zoomOut = true;
	public float speed = 1;
	public bool isOneUse = true;

	void Start() {
		GetComponent<MeshRenderer>().enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "P1") {
			Camera.main.GetComponent<CameraZoom>().SetZoomSpeed(speed);
			if (zoomOut)
				Camera.main.GetComponent<CameraZoom>().ZoomOut();
			else
				Camera.main.GetComponent<CameraZoom>().ZoomIn();
			if (isOneUse)
				GetComponent<BoxCollider2D>().enabled = false;
		}
	}
}