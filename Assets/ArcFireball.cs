using UnityEngine;
using System.Collections;

public class ArcFireball : MonoBehaviour {
	public Rigidbody2D body;
	public float baseX;
	public float baseY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Launch(float speed) {
		body.AddForce (new Vector2 (baseX * speed, baseY));
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.tag == "ShotDestroyer") {
			Destroy(this.gameObject);
		}
	}
}
