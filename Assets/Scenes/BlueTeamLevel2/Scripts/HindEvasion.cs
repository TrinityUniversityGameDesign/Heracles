using UnityEngine;
//using System.Collections;
using System;

public class HindEvasion : MonoBehaviour {

	public GameObject startPlatform;
	public GameObject[] platforms;
	public float jumpTime;
	public bool facingRight = true;
	public Animator anim;

	private GameObject currentPlatform;
//	private GameObject previousPlatform;
	private GameObject[] adjacentPlatforms;
	private Vector2 currentPosition;
	private GameObject deer;
	private Rigidbody2D deerBody;
	private BT_HealthScript playerHealth;

	private void flip() 
	{
		facingRight = !facingRight;
		Vector3 transScale = transform.localScale;
		transScale.x *= -1;
		transform.localScale = transScale;
	}

	Vector2 GetAcceleration(Vector2 targetPosition)
	{
		float physicsTimestep = Time.fixedDeltaTime;
		float timestepsPerSecond = Mathf.Ceil(1f/physicsTimestep);
		float n = timestepsPerSecond * jumpTime;
		Vector2 gravity = Physics.gravity * deerBody.gravityScale;
		
		Vector2 a = physicsTimestep * physicsTimestep * gravity;
		Vector2 p = targetPosition;
//		Debug.Log ("targetPosition (y): " + targetPosition.y.ToString());
		Vector2 s = currentPosition;
//		Debug.Log ("current position (y): " + currentPosition.y.ToString ());
		
		Vector2 velocity = (s + (((n * n + n) * a) / 2f) - p) * -1 / n;

		return velocity * timestepsPerSecond * timestepsPerSecond;
	}

	void ChangePosition ()
	{
		Vector2 nextPosition = currentPlatform.transform.position;
		nextPosition.y += deer.renderer.bounds.extents.y;
//		Debug.Log ( "distance: " + Vector2.Distance(currentPosition, deer.transform.position).ToString());

		if ((nextPosition.x > deer.transform.position.x) != facingRight)
			flip ();

		if (Vector2.Distance(currentPosition, deer.transform.position) > .6)
		{
			deer.transform.position = nextPosition;
		}
		else
		{
			anim.SetBool("Grounded", false);
			anim.SetTrigger("doJump");
			currentPosition = deer.transform.position;
			Vector2 force = GetAcceleration (nextPosition) * deerBody.mass;
			deerBody.AddForce (force);
		}

		currentPosition = nextPosition;
		adjacentPlatforms = currentPlatform.GetComponent<PlatformScript> ().adjacentPlatforms;
	}

	public void CheckDistance (GameObject triggerPlatform)
	{
		//Debug.Log ("Current platform: " + currentPlatform.name);

		//Checks whether the platorm the player has just landed on is adjacent to currentPlatform
		if (Array.Exists (adjacentPlatforms, platform => platform == triggerPlatform)) {
			int i = 0;
			GameObject nextPlatform = adjacentPlatforms [i];
			GameObject[] adjacentToPlayer = triggerPlatform.GetComponent<PlatformScript> ().adjacentPlatforms;

			//Iterates through array of adjacent platforms until it finds one that is not adjacent to the player and is not the platform the player landed on
			while ((Array.Exists(adjacentToPlayer, platform => platform == nextPlatform) || nextPlatform == triggerPlatform) && i < adjacentPlatforms.Length-1) {
				i += 1;
				nextPlatform = adjacentPlatforms [i];
			}

			if (!Array.Exists (adjacentToPlayer, platform => platform == nextPlatform) && nextPlatform != triggerPlatform) 
			{
//				previousPlatform = currentPlatform;
				currentPlatform = nextPlatform;
//				if ((nextPlatform.transform.position.x > deer.transform.position.x) != facingRight)
//					flip ();
				ChangePosition ();
			}
		 	else 
			{
			print("deer has nowhere to go");
			}
		}
//		else
//		{
//			if ((triggerPlatform.transform.position.x > deer.transform.position.x) != facingRight)
//			{
//				flip ();
//			}
//		}
	}

//	void OnCollisionEnter2D(Collider2D coll)
//	{
//		if (coll.gameObject.layer == LayerMask.NameToLayer("Player")) 
//		{
//			Debug.Log ("Collision with player.");
//			System.Random random = new System.Random();
//			int i = random.Next(0, platforms.Length);
////			previousPlatform = currentPlatform;
//			currentPlatform = platforms[i];
//			Vector2 nextPosition = currentPlatform.transform.position;
//			nextPosition.y += deer.renderer.bounds.extents.y;
//			deer.transform.position = nextPosition;
//			currentPosition = nextPosition;
//			adjacentPlatforms = currentPlatform.GetComponent<PlatformScript> ().adjacentPlatforms;
//		}
//	}

	// Use this for initialization
	void Start ()
	{
		deer = this.gameObject;
		deerBody = deer.rigidbody2D;
		anim = GetComponent<Animator> ();
		anim.SetBool ("Grounded", true);
		currentPlatform = startPlatform;
		currentPosition = currentPlatform.transform.position;
		adjacentPlatforms = currentPlatform.GetComponent<PlatformScript> ().adjacentPlatforms;		
		currentPosition.y += deer.renderer.bounds.extents.y;	
		transform.position = currentPosition;

		playerHealth = GameObject.FindGameObjectWithTag ("P1").GetComponent<BT_HealthScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//for testing -- causes deer to jump to random adjacent platform
		if (Input.GetButtonDown ("Fire1"))
		{
//			deerBody.AddForce(new Vector2(100,200));
			System.Random random = new System.Random();
			int i = random.Next(0, adjacentPlatforms.Length);
//			previousPlatform = currentPlatform;
			currentPlatform = adjacentPlatforms[i];
			ChangePosition();
		}
	}

	void FixedUpdate() {
		anim.SetFloat("vSpeed", deerBody.velocity.y);
		anim.SetFloat("Speed", deerBody.velocity.x);
		//anim.SetBool("Grounded",grounded);
		if (playerHealth.GetHealth() <= 0)
		{
			anim.SetBool ("Grounded", true);
			currentPlatform = startPlatform;
			currentPosition = currentPlatform.transform.position;
			adjacentPlatforms = currentPlatform.GetComponent<PlatformScript> ().adjacentPlatforms;		
			currentPosition.y += deer.renderer.bounds.extents.y;	
			transform.position = currentPosition;
			GetComponent<BT_HealthScript>().ResetHealth();
		}
	}
}
