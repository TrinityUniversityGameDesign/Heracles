using UnityEngine;
using System.Collections;

public class ShockwaveScript : MonoBehaviour {
	public float speed;
	public int life;
	private int time;
	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time++;
		this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x + speed / 10, this.gameObject.transform.position.y, 0);
		if (time > life) {
			Destroy(this.gameObject);
		}
	}
}
