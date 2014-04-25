using UnityEngine;
using System.Collections;

public class BT_HindScript : MonoBehaviour {

	public Transform groundCheck;
	public float groundRadius = 0.3f;
	public LayerMask groundMask;
	public float speed = 6f;
	public string direction = "right";
	private Vector3 movement = Vector3.zero;
	private Vector2 force = Vector2.zero;
	private bool doStop = true;
	private bool doSlow = false;
	private bool facingRight = true;
	public float jumpForce;
	private bool grounded;

	public Animator anim;
	
	// Use this for initialization
	void Awake () {
		SetDirection(direction);
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate() {
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		anim.SetFloat("Speed", rigidbody2D.velocity.x);
		anim.SetBool("Grounded",grounded);
		if (doStop)
			SetIdle(false);
		else
			SetIdle(true);
	}

	// Update is called once per frame
	void Update () {
		Collider2D[] GroundList = Physics2D.OverlapCircleAll (groundCheck.position, groundRadius,groundMask);
		grounded = false;
		if (GroundList.Length > 0) {
			for (int a =0; a<GroundList.Length; a++) {
				if (!GroundList [a].isTrigger) {
					grounded = true;
				}
			}
		}
		if (!doStop) {
			SetDirection(direction);
			if (direction == "jumpRight" || direction == "jumpLeft")
				DoJump ();
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

	public void SetIdle(bool value) {
		anim.SetBool("isIdle",value);
	}

	public void DoJump() {
		anim.SetTrigger("doJump");
	}

	public void flipDirection() {
		facingRight = !facingRight;
		Vector3 transScale = transform.localScale;
		transScale.x *= -1;
		transform.localScale = transScale;
	}

	public void SetDirection(string newDirection) {
		direction = newDirection;
		if (direction == "up") {
			movement = new Vector3 (rigidbody2D.velocity.x,speed,0f);
		}
		if (direction == "left") {
			if (facingRight)
				flipDirection();
			movement = new Vector3 (-speed,rigidbody2D.velocity.y,0f);
		}
		if (direction == "right") {
			if (!facingRight)
				flipDirection();
			movement = new Vector3(speed,rigidbody2D.velocity.y,0f);
		}
		if (direction == "down") {
			movement = new Vector3(rigidbody2D.velocity.x,-speed,0f);
		}
		if (direction == "jumpLeft") {
			if (facingRight)
				flipDirection();
			movement = new Vector3 (-speed,rigidbody2D.velocity.y,0f);
			force = new Vector2(0f,jumpForce);
			direction = "left";
		}
		if (direction == "jumpRight") {
			if (!facingRight)
				flipDirection();
			movement = new Vector3(speed,rigidbody2D.velocity.y,0f);
			force = new Vector2(0f,jumpForce);
			direction = "right";
		}
	}
}
