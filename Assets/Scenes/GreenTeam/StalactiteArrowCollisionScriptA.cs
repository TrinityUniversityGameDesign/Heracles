using UnityEngine;
using System.Collections;

public class StalactiteArrowCollisionScriptA : MonoBehaviour {
	Rigidbody2D beep;
	public AudioClip stalacFall;

	void Start()
	{
		beep = this.gameObject.GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		WaterScript water = otherCollider.gameObject.GetComponent<WaterScript> ();
		if (water != null) {
			beep.drag = 10;
			beep.gravityScale = 0.2f;
		}
		else if (shot != null)
		{
			Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			beep.gravityScale = 1;
			audio.clip = stalacFall;
			audio.PlayOneShot(stalacFall);
		}
	}
}



