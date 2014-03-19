using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


//	bool facingRight = true;
	public Vector2 resetPosition = new Vector2 (-7.5f, -1.75f);

	public float walkSpeed;
	public float runSpeed;
	public float crouchSpeed;
	public float crouchHeight = .5f;
	
	public Transform groundCheck;
	float groundRadius = 0.3f;
	bool grounded = false;
	public LayerMask groundMask;
	public float jumpPower;
	public string horizAxisName = "Horizontal";
	public string jumpAxisName = "Vertical";
	public bool isCrouched = false;

	public Component boxcollider;

	BoxCollider2D bc = new BoxCollider2D();

//	bool dead = false;

//	Animator anim;
	void Awake() {
//		anim = GetComponent<Animator> ();
		bc = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update () {
				grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundMask);
				//anim.SetBool ("Grounded", grounded);
				bool jump = Input.GetButtonDown (jumpAxisName);
				if (jump && grounded) {
						rigidbody2D.AddForce (new Vector2 (0, jumpPower));
				}
				bool crouch = Input.GetKey (KeyCode.X);
				if (crouch) {
						if (!isCrouched) {
								isCrouched = true;
								walkSpeed = crouchSpeed;
								//BoxCollider2D = new BoxCollider2D (BoxCollider2D.size.x, crouchHeight);//BoxCollider2D.size.y = BoxCollider2D.size.y / 2;
								bc.size = new Vector2(bc.size.x,crouchHeight);
								bc.center = new Vector2(bc.center.x,-.25f);
						} else {
								isCrouched = false;
								walkSpeed = crouchSpeed*2f;
								bc.size = new Vector2(bc.size.x,1f);
								bc.center = new Vector2(bc.center.x,0f);
						}
				}
		}
	void FixedUpdate () {
		float inputX = Input.GetAxis (horizAxisName);
		float vel = inputX * runSpeed;
		rigidbody2D.velocity = new Vector2 (vel, rigidbody2D.velocity.y);
	}
}
