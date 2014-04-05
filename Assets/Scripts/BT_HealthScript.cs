using UnityEngine;
using System.Collections;

public class BT_HealthScript : MonoBehaviour {

	// HealthScript:
	//		Handles object health using different phases. Phases
	//		are mostly provided to give flexibility in boss fights.
	//		i.e. traditional enemies are one phases bosses.

	public int[] healthPhases = {100};
	public bool isInvincible = false;
	
	private int currentHealth, currentPhase;

	void Start() {
		currentPhase = healthPhases.Length-1;
		currentHealth = healthPhases[currentPhase];
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

	// Returns the current phase
	public int GetPhase() {
		return currentPhase;
	}

	// Called when out of phases and health
	void DoDie() {
		if (!isInvincible)
			Destroy(this.gameObject);
		if (gameObject.tag == "P1") {
			transform.position = GameObject.FindGameObjectWithTag("DeathArea").GetComponent<GRE_PS_Checkpoint>().GetRespawnPos();
			GameObject.FindGameObjectWithTag("P1").GetComponent<DeathCount>().deathCount += 1;
		}
	}


	// Called when entering a new phase
	void setupNewPhase() {
		// A way to call custom functions/Scripts will be provided here
	}
}
