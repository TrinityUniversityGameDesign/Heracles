using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.IO;

public class GT_GhostScript : MonoBehaviour {

	public Vector2 speed = new Vector2(5,5);
	public static float d = 1;
	public Vector2 direction = new Vector2(d,0.0f);
	public static Stopwatch timer = new Stopwatch();

	private Vector2 movement;

	// Use this for initialization
	void Start () {
		timer.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer.Elapsed > System.TimeSpan.FromSeconds(3)) {
			d = -d;
			direction = new Vector2(d,0);
			timer = new Stopwatch();
			timer.Start ();
		}

		movement = new Vector2 (
			speed.x * direction.x,
			speed.y * direction.y);
	}

	void FixedUpdate () {
		rigidbody2D.velocity = movement;
	}
}
