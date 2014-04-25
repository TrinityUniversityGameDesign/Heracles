using UnityEngine;
using System.Collections;

public class BT_HindScript : MonoBehaviour {

	public float speed = 6f;
	public string direction = "right";
	private Vector3 movement = Vector3.zero;
	private Vector2 force = Vector2.zero;
	private bool doStop = false;
	private bool doSlow = false;
	public float jumpForce;
	
	// Use this for initialization
	void Start () {
		SetDirection(direction);
	}
	
	// Update is called once per frame
	void Update () {
		if (!doStop) {
			SetDirection(direction);
			rigidbody2D.velocity = movement;
			rigidbody2D.AddForce(force);
			force = Vector2.zero;
		}
		if (doSlow) {
			rigidbody2D.velocity = Vector3.Lerp(rigidbody2D.velocity,Vector3.zero,Time.deltaTime*10);
			if (Vector3.Distance(rigidbody2D.velocity,Vector3.zero) < 0.2f) {
				doSlow = false;
				rigidbody2D.velocity = Vector3.zero;
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "P1") {
			doStop = false;
			GetComponent<CircleCollider2D>().enabled = false;
			GetComponents<BoxCollider2D>()[0].isTrigger = true;
		}
	}

	public void StopHind() {
		doStop = true;
	}

	public void SlowToStop() {
		doSlow = true;
	}

	public void SetJumpForce(float newForce) {
		jumpForce = newForce;
	}

	public void SetSpeed(float newSpeed) {
		speed = newSpeed;
	}

	public void SetDirection(string newDirection) {
		direction = newDirection;
		if (direction == "up") {
			movement = new Vector3 (rigidbody2D.velocity.x,speed,0f);
		}
		if (direction == "left") {
			movement = new Vector3 (-speed,rigidbody2D.velocity.y,0f);
		}
		if (direction == "right") {
			movement = new Vector3(speed,rigidbody2D.velocity.y,0f);
		}
		if (direction == "down") {
			movement = new Vector3(rigidbody2D.velocity.x,-speed,0f);
		}
		if (direction == "jumpLeft") {
			movement = new Vector3 (-speed,rigidbody2D.velocity.y,0f);
			force = new Vector2(0f,jumpForce);
			direction = "left";
		}
		if (direction == "jumpRight") {
			movement = new Vector3(speed,rigidbody2D.velocity.y,0f);
			force = new Vector2(0f,jumpForce);
			direction = "right";
		}
	}
}
