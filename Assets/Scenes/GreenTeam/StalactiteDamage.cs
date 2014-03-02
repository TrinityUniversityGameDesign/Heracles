using UnityEngine;
using System.Collections;

public class StalactiteDamage : MonoBehaviour {
		// This is an edited copy of HealthScript:
		//		Handles stalactite "health" using phase system similar to boss.  
		
		public int[] healthPhases = {1};
		public bool isInvincible = false;
	 	bool stopFall = true;
		
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
				stopFall = false;
		}
		
		
		// Called when entering a new phase
		void setupNewPhase() {
			// A way to call custom functions/Scripts will be provided here
		}
	}
