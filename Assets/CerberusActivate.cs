using UnityEngine;
using System.Collections;

public class CerberusActivate : MonoBehaviour {
	public GameObject Cerberus;
	public GameObject rocks;
	public CameraFollow camera;
	public Transform bossCameraMarker;
	public static bool CerberusActive = false;
	// Use this for initialization

	void Start() {
		Cerberus.SetActive (false);
		rocks.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "P1" && !CerberusActive) {
			Cerberus.SetActive(true);
			Cerberus.GetComponent<CerberusScript>().returnToStart();
			rocks.SetActive(true);
			camera.player = bossCameraMarker;
			camera.xMargin = 0;
			camera.yMargin = 0;
			CerberusActive = true;
		}
	}
}

//45.75,56.4