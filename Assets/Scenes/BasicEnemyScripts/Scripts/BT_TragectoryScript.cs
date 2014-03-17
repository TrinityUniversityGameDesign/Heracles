using UnityEngine;
using System.Collections;

public class BT_TragectoryScript : MonoBehaviour {

	public LineRenderer sightLine;
	public GameObject objShot;
	public int segmentCount = 20;
	public float segmentScale = 1;

	private float angle = 0;
	private float force = 0f;

	private Collider _hitObject;
	public Collider hitObject {get {return _hitObject; }}
	
	// Use this for initialization
	void Start () {

	}

	public void SetTragectory(float newAngle, float newForce) {
		angle = newAngle;
		force = newForce;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		SimulatePath();
        if(!Input.GetButton("Fire")) {
            sightLine.SetWidth(0f, 0f);
        }
	}

	void SimulatePath() {
		Vector3[] segments = new Vector3[segmentCount];
		segments[0] = objShot.transform.position;
		float angleRad = angle / 180.0f * Mathf.PI;
		Vector3 segVelocity = ((Mathf.Sin(angleRad) * transform.up + Mathf.Cos(angleRad) * transform.right) * force);
		_hitObject = null;
		for (int i = 1; i < segmentCount; i++) {
			float segTime = (segVelocity.sqrMagnitude != 0) ? segmentScale/segVelocity.magnitude : 0;
			segVelocity = segVelocity+(Physics.gravity*rigidbody2D.gravityScale) * segTime;
			RaycastHit hit;
			if (Physics.Raycast (segments[i-1], segVelocity, out hit, segmentScale)) {
				_hitObject = hit.collider;
				segments[i] = segments[i-1]+segVelocity.normalized * hit.distance;
				segVelocity = segVelocity - (Physics.gravity*rigidbody2D.gravityScale) * (segmentScale - hit.distance) / segVelocity.magnitude;
				segVelocity = Vector3.Reflect(segVelocity, hit.normal);
			}
			else {
				segments[i] = segments[i-1] + segVelocity * segTime;
			}
		}
        Color startColor = Color.black;
		Color endColor =  Color.red;
		startColor.a = 0.25f;
		endColor.a = 0;
		sightLine.SetWidth(0.1f,0.1f);
		sightLine.SetColors(startColor,endColor);
		sightLine.SetVertexCount(segmentCount);
		for (int i = 0; i < segmentCount; i++)
			sightLine.SetPosition(i, segments[i]);
	}
}
