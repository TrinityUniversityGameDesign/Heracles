using UnityEngine;
using System.Collections;


public class GRE_PS_Checkpoint : MonoBehaviour {

	// Death Count Script Reference
	private DeathCount death;
	public static Vector2 respawnPos = new Vector2(); //Need to make a global spawn variable for each level
	private bool check = false;
	private bool check2 = false;
	public int seconds = 0;

	void Start() {
		death = GameObject.FindGameObjectWithTag("P1").GetComponent<DeathCount>();
		if (seconds == 0) {
			seconds = 2;		
		}
	}

	void OnTriggerEnter2D(Collider2D playerCollision)
	{
        if (playerCollision.gameObject.tag == "P1")
        {
            if (gameObject.tag == "DeathArea" && !check)
            {
				playerCollision.GetComponent<PlayerControl>().SetMove(false);
				playerCollision.GetComponent<ShootingScript>().active = false;
				playerCollision.renderer.enabled = false;
				StartCoroutine(wait(seconds, playerCollision));

            }
            if (gameObject.tag == "Checkpoint")
            {
                respawnPos = playerCollision.transform.position; //Not resetting global variable
            }

        }
	}

	// Ensures the death is only counted once
	void OnTriggerExit2D(Collider2D other) {
		check = false;
	}

	public Vector3 GetRespawnPos() {
		return respawnPos;
	}

	IEnumerator wait(int seconds, Collider2D playerCollision) {
		yield return new WaitForSeconds (seconds); 
		check = true;
		playerCollision.transform.position = respawnPos;
		playerCollision.renderer.enabled = true;
		playerCollision.GetComponent<PlayerControl>().SetMove(true);
		playerCollision.GetComponent<ShootingScript>().active = true;
		death.deathCount += 1;
	}
}