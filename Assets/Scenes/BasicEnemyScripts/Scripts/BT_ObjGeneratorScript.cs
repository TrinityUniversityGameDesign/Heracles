using UnityEngine;
using System.Collections;

public class BT_ObjGeneratorScript : MonoBehaviour {

	// ObjGeneratorScript:
	// 		Generates any pre-determined object on a given interval.
	//		NEEDS WORK AND ADDED FUNCTIONALITY. IN PROGRESS.

	public GameObject obj;
	public float genRate = 0.5f;
	public float genCooldown = 0f;
	public int angle;
	public float force;

	public bool aimForTarget;
	//public Transform target; Original Script
	private bool haveFiringSolution = false;
	private bool directFire = true;

	// Update is called once per frame
	void Update () {
		if (genCooldown > 0f)
			genCooldown -= Time.deltaTime;
		else
			Generate();
	}

	public void Generate() {
		if (CanGenerateNew) {
			genCooldown = genRate;
			GameObject newObj = Instantiate(obj) as GameObject;
			newObj.transform.position = transform.position;
			newObj.AddComponent<BT_TragectoryScript>();
			newObj.GetComponent<BT_TragectoryScript>().objShot = this.gameObject;
			newObj.GetComponent<BT_TragectoryScript>().sightLine = newObj.GetComponent<LineRenderer>();
			if (!aimForTarget) {
				float angleRad = angle / 180.0f * Mathf.PI;
				newObj.rigidbody2D.AddForce( (Mathf.Sin(angleRad) * newObj.transform.up + Mathf.Cos(angleRad) * newObj.transform.right) * force);
				newObj.GetComponent<BT_TragectoryScript>().SetTragectory(angle,force);
			}
			else {
				Vector2 direction = GameObject.FindGameObjectWithTag("P1").transform.position - transform.position;
				float distance = Mathf.Abs(GameObject.FindGameObjectWithTag("P1").transform.position.x - transform.position.x);
				float tempAngle = (Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg);
				//float tempForce = BallisticVel(GameObject.FindGameObjectWithTag("P1").transform.position,tempAngle);
				float angleRad = tempAngle / 180.0f * Mathf.PI;
				newObj.rigidbody2D.AddForce( (Mathf.Sin(angleRad) * newObj.transform.up + Mathf.Cos(angleRad) * newObj.transform.right) * force*49);
				newObj.GetComponent<BT_TragectoryScript>().SetTragectory(tempAngle,force);
			}
		}
	}

	float BallisticVel(Vector3 target,float newAngle) {
		Vector3 dir = target - transform.position; 
		float h = dir.y;
		dir.y = 0;
		float dist = dir.magnitude;
		float a = angle * Mathf.Deg2Rad;
		dir.y = dist * Mathf.Tan(a);
		dist += h / Mathf.Tan(a);
		return Mathf.Sqrt(Mathf.Abs(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a)));
	}
	
	public bool CanGenerateNew {
		get {
			return genCooldown <= 0f;
		}
	}	
}
