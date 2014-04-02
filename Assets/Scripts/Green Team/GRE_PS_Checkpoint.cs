using UnityEngine;
using System.Collections;


public class GRE_PS_Checkpoint : MonoBehaviour {

	// Death Count Script Reference
	private DeathCount death;
	public static Vector2 respawnPos = new Vector2(); //Need to make a global spawn variable for each level

	void Start() {
		death = GameObject.FindGameObjectWithTag("P1").GetComponent<DeathCount>();
	}

	void OnTriggerEnter2D(Collider2D playerCollision)
	{
        if (playerCollision.gameObject.tag == "P1")
        {
            if (gameObject.tag == "DeathArea")
            {

                playerCollision.transform.position = respawnPos;
				death.deathCount += .5; // actually adds 1 to the deathcount, can't figure out why it is getting triggered twice.

            }
            if (gameObject.tag == "Checkpoint")
            {
                respawnPos = playerCollision.transform.position; //Not resetting global variable
            }

        }
	}
}