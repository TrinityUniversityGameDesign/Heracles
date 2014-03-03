using UnityEngine;
using System.Collections;

public class StalactiteArrowCollisionScriptA : MonoBehaviour {
	Rigidbody2D beep;
    Transform pos;
    Vector3 origPos;
    int counter;
    bool counting;
	public AudioClip stalacFall;
    public int timeToDisappear;

	void Start()
	{
		beep = this.gameObject.GetComponent<Rigidbody2D>();
        pos = this.gameObject.GetComponent<Transform>();
        origPos = pos.position;
        counting = false;
        counter = 0;
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		WaterScript water = otherCollider.gameObject.GetComponent<WaterScript> ();
		if (water != null) {
			beep.drag = 10;
			beep.gravityScale = 0.2f;
            counting = true;
		}
		else if (shot != null && !counting)
		{
			Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			beep.gravityScale = 1;
			audio.clip = stalacFall;
			audio.PlayOneShot(stalacFall);
		}
	}

    void FixedUpdate()
    {
        if (counting)
        {
            counter += 1;
        }
        if (counter > timeToDisappear)
        {
            pos.position = origPos;
            counting = false;
            beep.drag = 0;
            beep.gravityScale = 0;
            counter = 0;
            beep.velocity = new Vector3(0, 0, 0);
        }
    }
}



