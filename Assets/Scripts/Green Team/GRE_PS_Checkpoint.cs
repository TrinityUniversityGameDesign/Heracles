using UnityEngine;
using System.Collections;


public class GRE_PS_Checkpoint : MonoBehaviour {
	public Vector2 respawnPos = new Vector2(-1000f, 0.373f); //Need to make a global spawn variable for each level
	void OnTriggerEnter2D(Collider2D playerCollision)
	{
		if (gameObject.tag == "DeathArea") {
			playerCollision.transform.position = respawnPos; //Not sure about this
	} 
		if (gameObject.tag == "Checkpoint") {
			respawnPos = transform.position;
		}
	}
}
