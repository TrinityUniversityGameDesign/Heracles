using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {
	
	public int damage = 1;
	public bool hit = false;
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(1,0);
	private Vector2 movement;
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 30);
	}
	
	// Update is called once per frame
	void Update () {
		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
		//if (gameObject.rigidbody2D.velocity.x < .01 && gameObject.rigidbody2D.velocity.y < .01)
			//Destroy (gameObject); 
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}

}