using UnityEngine;
using System.Collections;

public class ResponsiveZoom : MonoBehaviour {

	public float start;
	public float end;
	public bool isOneUse = true;

	private bool doZoom = false;
	private float zoom;
	private Vector3 lastPos;
	private Transform target;
	private float dist;

	// UNFINISHED DONT USE

	void Start() {
		//GetComponent<MeshRenderer>().enabled = false;
		zoom = Camera.main.orthographicSize;
		start = Camera.main.GetComponent<CameraZoom>().zoom;
		target = GameObject.FindGameObjectWithTag("P1").transform;
		dist = renderer.bounds.size.x;
	}

	void Update() {
		zoom = Camera.main.orthographicSize;
		if (doZoom) {
			Debug.Log(start);
			dist += (target.position.x-lastPos.x);
			zoom = start+end-((renderer.bounds.size.x/dist)*end);
			if (zoom < start) zoom = start;
			Camera.main.GetComponent<CameraZoom>().SetZoomSpeed(10);
			Camera.main.GetComponent<CameraZoom>().SetZoom(zoom);
		}
		lastPos.x = target.position.x;
		//Debug.Log(zoom);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "P1")
			doZoom = true;
	}
}
