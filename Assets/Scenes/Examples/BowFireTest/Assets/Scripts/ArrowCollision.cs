using UnityEngine;
using System.Collections;

public class ArrowCollision : MonoBehaviour {
    //This will destroy the arrow when it impacts an object. Use this script for anything that needs to collide with arrows!
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
           Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
        }
    }
}
