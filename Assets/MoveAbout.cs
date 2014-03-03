using UnityEngine;
using System.Collections;

public class MoveAbout : MonoBehaviour {

	public float CoolDown = 3f;
	public int phase = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CoolDown > 0f)
				CoolDown -= Time.deltaTime;
		else{
				Moveit ();
				CoolDown = 3f;
			}
	}

	void Moveit(){
				if (phase == 0) {
						transform.position = new Vector3 (-5f, 0f, transform.position.z);
						phase += 1;
				} else if (phase == 1) {
						transform.position = new Vector3 (8f, 0f, transform.position.z);
						phase += 1;
				} else if (phase == 2) {
						transform.position = new Vector3 (8f, -4f, transform.position.z);
						phase += 1;
				} else{
						transform.position = new Vector3 (-5f, -4f, transform.position.z);
						phase = 0;
				}
	}
}
