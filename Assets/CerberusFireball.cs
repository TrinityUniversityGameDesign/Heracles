using UnityEngine;
using System.Collections;

public class CerberusFireball : MonoBehaviour {
	public float speed; //How fast it goes
	private Transform pos; //The fireball's transform
	public Vector3 initDest;
	private bool hitDest;

	// Use this for initialization
	void Start () {
		hitDest = false;
		pos = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!hitDest) {
			moveToDestination();
		} else {
			headRight();
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.tag == "ShotDestroyer") {
			Destroy(this.gameObject);
		}
	}

	void moveToDestination() {
		pos.position = Vector3.MoveTowards (pos.position, initDest, speed);
		if (pos.position.x == initDest.x) {
			hitDest = true;
		}
	}

	void headRight() {
		pos.position = new Vector3 (pos.position.x + speed, pos.position.y, 0);
	}
}
