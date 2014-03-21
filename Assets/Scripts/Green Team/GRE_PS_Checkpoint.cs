using UnityEngine;
using System.Collections;


public class GRE_PS_Checkpoint : MonoBehaviour {
	public static Vector2 respawnPos = new Vector2(); //Need to make a global spawn variable for each level
	void OnTriggerEnter2D(Collider2D playerCollision)
	{
		if (gameObject.tag == "DeathArea") {
			playerCollision.transform.position = respawnPos;
	} 
		if (gameObject.tag == "Checkpoint") {
			respawnPos = playerCollision.transform.position; //Not resetting global variable
		}
	}
}