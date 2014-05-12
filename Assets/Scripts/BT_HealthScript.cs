using UnityEngine;
using System.Collections;

public class BT_HealthScript : MonoBehaviour {

	// HealthScript:
	//		Handles object health using different phases. Phases
	//		are mostly provided to give flexibility in boss fights.
	//		i.e. traditional enemies are one phases bosses.

	public int[] healthPhases = {100};
	public bool isInvincible = false;
	public float seconds = 1.4f;
	public GameObject deathFader;
	public bool fadeOnDeath = false;

	private GameObject deathfader;
	private bool fade = false;
	private int deathCount = 0;	
	private int currentHealth, currentPhase;
	private GameObject player;
	public Vector2 respawnPos;

	void Start() {
		currentPhase = healthPhases.Length-1;
		currentHealth = healthPhases[currentPhase];
		if (gameObject.tag == "P1")
		{
			player = gameObject;
			respawnPos = GetComponent<PlayerControl>().resetPosition;
		}
		else
			player = GameObject.FindWithTag("P1");
	}

	// Deals damage to this object
	// Checks if object should enter new phase or just die
	public void DoDamage(int amount) {
		currentHealth -= amount;
		if (currentHealth <= 0) {
			currentPhase--;
			setupNewPhase();
			if (currentPhase < 0)
				DoDie();
			else
				currentHealth = healthPhases[currentPhase];
		}
		if (currentHealth <= 0 && currentPhase < 0)
			DoDie();
	}

	// Returns the current health value
	public int GetHealth() {
		return currentHealth;
	}

	public void ResetHealth() {
		currentHealth = healthPhases [currentPhase];
	}

	// Returns the current phase
	public int GetPhase() {
		return currentPhase;
	}

	public int GetDeathCount() {
		return deathCount;
	}

	// Called when out of phases and health
	void DoDie() {
		if (gameObject.tag == "P1") {
			if (fadeOnDeath == false)
				transform.position = respawnPos;
			//transform.position = GameObject.FindGameObjectWithTag("DeathArea").GetComponent<GRE_PS_Checkpoint>().GetRespawnPos();
			deathCount += 1;
			GetComponent<DeathCount>().deathCount = (double)deathCount;
			currentPhase = 0;
			ResetHealth();
		}
		else 
		{
			if (!isInvincible)
			Destroy(this.gameObject);
		}
		if (fadeOnDeath == true) 
		{
			player.GetComponent<PlayerControl>().SetMove(false);
			player.GetComponent<ShootingScript>().active = false;
			player.renderer.enabled = false;
			StartCoroutine(wait(seconds, player.collider2D));
			deathfader = Instantiate(deathFader,new Vector3(player.transform.position.x,player.transform.position.y,Camera.main.transform.position.z+1),Quaternion.identity) as GameObject;
			deathfader.GetComponent<BT_DecayScript>().DecayNow(seconds);
			Color tempColor = deathfader.GetComponent<MeshRenderer>().material.color;
			tempColor.a = 0.0f;
			deathfader.GetComponent<MeshRenderer>().material.color = tempColor;
			fade = true;
		}
	}


	// Called when entering a new phase
	void setupNewPhase() {
		// A way to call custom functions/Scripts will be provided here
	}

	void Update() {
		if (fade) {
			Color tempColor = deathfader.GetComponent<MeshRenderer>().material.color;
			tempColor.a += 0.015f;
			deathfader.GetComponent<MeshRenderer>().material.color = tempColor;
		}
	}

	IEnumerator wait(float seconds, Collider2D playerCollider) {
		yield return new WaitForSeconds (seconds); 
		playerCollider.transform.position = respawnPos;
		playerCollider.renderer.enabled = true;
		playerCollider.GetComponent<PlayerControl>().SetMove(true);
		playerCollider.GetComponent<ShootingScript>().active = true;
		Color tempColor = deathfader.GetComponent<MeshRenderer>().material.color;
		tempColor.a = 0.0f;
		deathfader.GetComponent<MeshRenderer>().material.color = tempColor;
		fade = false;
	}
}
