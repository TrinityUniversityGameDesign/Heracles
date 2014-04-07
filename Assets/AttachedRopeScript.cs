using UnityEngine; 
using System.Collections;

public class AttachedRopeScript : MonoBehaviour {


	public GameObject rope;
	private RopeScript ropeS;
	private Transform pos;
	// Use this for initialization
	void Start () {
		pos = this.gameObject.GetComponent<Transform>();
		ropeS = rope.GetComponent<RopeScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (pos.eulerAngles.z > 10 && ropeS.severed) {
			pos.Rotate (new Vector3 (0f, 0f, 0.5f));
		}
	}
}
