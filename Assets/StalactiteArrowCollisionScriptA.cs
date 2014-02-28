using UnityEngine;
using System.Collections;

public class StalactiteArrowCollisionScriptA : MonoBehaviour {
	Rigidbody2D beep;

	void Start()
	{
		beep = this.gameObject.GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			beep.gravityScale = 1;
		}
	}
}
