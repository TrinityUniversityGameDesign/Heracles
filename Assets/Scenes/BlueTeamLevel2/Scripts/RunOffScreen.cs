using UnityEngine;
using System.Collections;

public class RunOffScreen : MonoBehaviour {

	public GameObject deer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 30) {
			deer.transform.Translate(.08f, 0, 0, Space.Self);		
		}
	}
}
