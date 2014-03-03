using UnityEngine;
using System.Collections;

public class PlayerControl1 : MonoBehaviour {


	bool facingRight = true;
	public Vector2 resetPosition = new Vector2 (-7.5f, -1.75f);

	public float walkSpeed;
	public float runSpeed;
	
	public Transform groundCheck;
	float groundRadius = 0.2f;
	bool grounded = false;
	public LayerMask groundMask;
	public float jumpPower;
	public string horizAxisName = "Horizontal";
	public string jumpAxisName = "Vertical";

	bool dead = false;

//	Animator anim;


	void Awake() {
		//anim = GetComponent<Animator> ();
	}

	public void Reset() {
		transform.position = resetPosition;

		grounded = false;
	}

	// Update is called once per frame
	void Update () {

	}


	void FixedUpdate () {
			float inputX = Input.GetAxis (horizAxisName);
			float vel = inputX * runSpeed;
			rigidbody2D.velocity = new Vector2 (vel, rigidbody2D.velocity.y);

			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundMask);
			//anim.SetBool ("Grounded", grounded);
			bool jump = Input.GetButtonDown (jumpAxisName);
			if (jump && grounded) {
				rigidbody2D.AddForce (new Vector2 (0, jumpPower));
			}
		
	}

	void OnTriggerEnter2D ( Collider2D other ) {


	}

}
