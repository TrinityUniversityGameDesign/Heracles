using UnityEngine;
//using System.Collections;
using System;

public class HindEvasion : MonoBehaviour {

	public GameObject startPlatform;
	public float jumpTime;

	private GameObject currentPlatform;
	private GameObject[] adjacentPlatforms;
	private Vector2 currentPosition;
	private GameObject deer;
	private Rigidbody2D deerBody;

	Vector2 GetAcceleration(Vector2 targetPosition)
	{
		float physicsTimestep = Time.fixedDeltaTime;
//		Debug.Log ("secondsPerTimestep: " + physicsTimestep.ToString ());
		float timestepsPerSecond = Mathf.Ceil(1f/physicsTimestep);
//		Debug.Log ("timestepsPerSecond: " + timestepsPerSecond.ToString ());
		
		//By default we set n so our projectile will reach our target point in 1 second
		float n = timestepsPerSecond * jumpTime;
//		Debug.Log ("n: " + n.ToString ());
		Vector2 gravity = Physics.gravity * deerBody.gravityScale;
//		Debug.Log ("gravity: " + gravity.y.ToString ());
		
		Vector2 a = physicsTimestep * physicsTimestep * gravity;
		Vector2 p = targetPosition;
//		Debug.Log ("targetPosition (y): " + targetPosition.y.ToString());
		Vector2 s = currentPosition;
//		Debug.Log ("current position (y): " + currentPosition.y.ToString ());
		
		Vector2 velocity = (s + (((n * n + n) * a) / 2f) - p) * -1 / n;
		
		//This will give us velocity per timestep.
//		Debug.Log ("velocity: " + velocity.y.ToString());
		return velocity * timestepsPerSecond * timestepsPerSecond;
	}

	void ChangePosition ()
	{
		Vector2 nextPosition = currentPlatform.transform.position;
		nextPosition.y += deer.renderer.bounds.extents.y;
		Vector2 force = GetAcceleration (nextPosition) * deerBody.mass;
		deerBody.AddForce (force);
		currentPosition = nextPosition;
//		transform.position = currentPosition;
		adjacentPlatforms = currentPlatform.GetComponent<PlatformScript> ().adjacentPlatforms;
	}

	public void CheckDistance (GameObject triggerPlatform)
	{
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

			if (!Array.Exists (adjacentToPlayer, platform => platform == nextPlatform) && nextPlatform != triggerPlatform) {
				currentPlatform = nextPlatform;
				ChangePosition ();
			}
		 	else 
			{
			print("deer has nowhere to go");
			}
		}
	}

	// Use this for initialization
	void Start ()
	{
		deer = this.gameObject;
		deerBody = deer.rigidbody2D;


		currentPlatform = startPlatform;
		currentPosition = currentPlatform.transform.position;
		adjacentPlatforms = currentPlatform.GetComponent<PlatformScript> ().adjacentPlatforms;
		
		currentPosition.y += deer.renderer.bounds.extents.y;	
		transform.position = currentPosition;
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
			currentPlatform = adjacentPlatforms[i];
			ChangePosition();

		}
	}
}
