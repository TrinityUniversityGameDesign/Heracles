using UnityEngine;
using System.Collections;

public class ArrowCollision : MonoBehaviour {
    //This will destroy the arrow when it impacts an object. Use this script for anything that needs to collide with arrows!
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null ) {
            if (this.gameObject.layer == 8)
            { //Arrows stick to ground
                shot.rigidbody2D.gravityScale = 0;
                shot.rigidbody2D.velocity = new Vector3();
            } else if(this.gameObject.layer == 4) {
				otherCollider.gameObject.GetComponent<Rigidbody2D>().drag = 20;
				otherCollider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2.2f;
				//otherCollider.gameObject.GetComponent<PointTowardsMovementScript>().enabled = false;
			} else {
				Destroy(otherCollider.gameObject);
			}
		}
    }


}
