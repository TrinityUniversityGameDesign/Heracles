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
	private bool isCrouched = false;
	private bool facingLeft = false;

	public Component boxcollider;

	BoxCollider2D bc = new BoxCollider2D();

//	bool dead = false;

	Animator anim;
	void Awake() {
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
		bool crouch = Input.GetKey (KeyCode.X);
		if (crouch) {
			if (!isCrouched) {
				isCrouched = true;
				walkSpeed = crouchSpeed;
				//BoxCollider2D = new BoxCollider2D (BoxCollider2D.size.x, crouchHeight);//BoxCollider2D.size.y = BoxCollider2D.size.y / 2;
				bc.size = new Vector2(bc.size.x,crouchHeight);
				bc.center = new Vector2(bc.center.x,-.25f);
            }
        } else {
            isCrouched = false;
            walkSpeed = crouchSpeed * 2f;
            bc.size = new Vector2(bc.size.x, 1f);
            bc.center = new Vector2(bc.center.x, 0f);
        }
	    if (Input.GetKey(KeyCode.Q)){
		    gameObject.transform.position = GRE_PS_Checkpoint.respawnPos;
	    }
	}
	void FixedUpdate () {
		float inputX = Input.GetAxis (horizAxisName);
		if (inputX < 0 && !facingLeft) {
			facingLeft = true;
			gameObject.transform.localScale = new Vector3 (-1 * transform.localScale.x, transform.localScale.y, transform.localScale.x);
		}
		if (inputX > 0 && facingLeft) {
			facingLeft = false;
			gameObject.transform.localScale = new Vector3 (-1 * transform.localScale.x, transform.localScale.y, transform.localScale.x);
		}
			
		float vel = inputX * runSpeed;
		anim.SetFloat("Speed", Mathf.Abs(vel));
		rigidbody2D.velocity = new Vector2 (vel, rigidbody2D.velocity.y);
	}
}
