using UnityEngine;
using System.Collections;


public class GRE_PS_Checkpoint : MonoBehaviour {
	public Vector2 pos = new Vector2(1.30785f, 0.10806f); //Need to make a global spawn variable for each level
	void OnTriggerEnter2D(Collider2D playerCollision)
	{
		Debug.Log("Wut");
		if (playerCollision.tag == "DeathArea") {
			gameObject.transform.position = pos;
		} 
		else if (playerCollision.tag == "Checkpoint") {
			pos = transform.position;
		}
	}
}
