using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//Horizontal movement stuff...
	public float maxSpeed = 5f;

	//Jumping stuff...
	bool grounded = false;
	bool jump = false;
	public Transform groundCheck;
	float groundRadius = 0.02f;
	public LayerMask groundMask;
	public float jumpPower = 400f;

	//Sound stuff...
	public AudioClip jumpSound;
	public AudioClip deadSound;

	bool dead = false;

	void Reset() {
		AudioSource.PlayClipAtPoint (deadSound, transform.position);
		EffectsHelper.Instance.Explode (transform.position);
		rigidbody2D.velocity = new Vector2 (0f, 0f);
		transform.position = new Vector2 (-4f, 0f);
		dead = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (dead) {
			Reset ();
		} else {
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundMask);
			float horizVal = Input.GetAxis ("Horizontal");
			jump = Input.GetButtonDown ("Jump");
			if (grounded && jump) {
				AudioSource.PlayClipAtPoint (jumpSound, transform.position);
			}
			//Horizontal movement control
			float speed = horizVal * maxSpeed;
			rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
			//Jump control
			if (grounded && jump) {
				rigidbody2D.AddForce(new Vector2 (0f, jumpPower)); 
			}
		}
	}

	//Intersection with Death stuff...
	void OnTriggerEnter2D (Collider2D other) {
		if(!dead) {
			Debug.Log (other.gameObject.layer);
			//Is this a death pit?
			if(other.gameObject.layer == LayerMask.NameToLayer("Death")) {
				dead = true;
			}
		}
	}
}
