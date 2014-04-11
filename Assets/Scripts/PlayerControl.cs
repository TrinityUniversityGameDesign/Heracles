﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	
	//	bool facingRight = true;
	public Vector2 resetPosition = new Vector2 (-7.5f, -1.75f);
	
	public float walkSpeed;
	public float runSpeed;
	public float crouchSpeed;
	private float crouchHeight = .5f;
	
	public Transform groundCheck;
	float groundRadius = 0.3f;
	bool grounded = false;
	public LayerMask groundMask;
	public float jumpPower;
	public string horizAxisName = "Horizontal";
	public string jumpAxisName = "Vertical";
	
	private bool crouch = false;
	private bool isCrouched = false;
	private float animIdleRate = 4f;
	private float idleCooldown;
	private bool facingRight = true;
	private bool isShooting = false;
	
	public Component boxcollider;
	
	BoxCollider2D bc = new BoxCollider2D();
	
	//	bool dead = false;
	
	Animator anim;
	void Awake() {
		idleCooldown = animIdleRate;
		anim = GetComponent<Animator> ();
		bc = GetComponent<BoxCollider2D>();
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
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundMask);
		
		bool jump = Input.GetButtonDown (jumpAxisName);
		if (jump && grounded && Input.GetAxis(jumpAxisName)>0) {
			rigidbody2D.AddForce (new Vector2 (0, jumpPower));
		}
		crouch = Input.GetButton("Shift"); // seems more user friendly than "X"
		if (crouch) {
			if (!isCrouched) {
				anim.SetBool("Crouch",true);
				isCrouched = true;
				walkSpeed = crouchSpeed;
				//BoxCollider2D = new BoxCollider2D (BoxCollider2D.size.x, crouchHeight);//BoxCollider2D.size.y = BoxCollider2D.size.y / 2;
				bc.size = new Vector2(bc.size.x,crouchHeight);
				bc.center = new Vector2(bc.center.x,-.25f);
			}
		} else {
			anim.SetBool("Crouch",false);
			isCrouched = false;
			walkSpeed = crouchSpeed * 2f;
			bc.size = new Vector2(bc.size.x, 1f);
			bc.center = new Vector2(bc.center.x, 0f);
		}
		if (Input.GetKey(KeyCode.Q)){
			gameObject.transform.position = GRE_PS_Checkpoint.respawnPos;
		}
		
		if (idleCooldown > 0)
			idleCooldown -= Time.deltaTime;
		if (idleCooldown < 0){
			idleCooldown = animIdleRate;
			anim.SetTrigger("doPuff");
		}
	}
	
	public void flipDirection() {
		facingRight = !facingRight;
		Vector3 transScale = transform.localScale;
		transScale.x *= -1;
		transform.localScale = transScale;
	}
	
	void FixedUpdate () {
		float inputX = Input.GetAxis (horizAxisName);
		float vel = inputX * runSpeed;
		rigidbody2D.velocity = new Vector2 (vel, rigidbody2D.velocity.y);
		
		if (Input.GetButton("Fire") && grounded) {
			isShooting = true;
			anim.SetBool("isShooting",isShooting);
		}
		if (!Input.GetButton("Fire") && isShooting) {
			isShooting = false;
			anim.SetTrigger("doShoot");
			anim.SetBool("isShooting",isShooting);
		}
		anim.SetFloat("Speed", Mathf.Abs(vel));
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		anim.SetBool("Grounded",grounded);
		
		if (inputX > 0 && !facingRight) flipDirection();
		else if (inputX < 0 && facingRight) flipDirection();
		if (inputX > 0) idleCooldown = animIdleRate;
	}
	
	public bool IsFacingRight() {
		return facingRight;
	}

	public bool IsGrounded() {
		return grounded;
	}
}
