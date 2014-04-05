using UnityEngine;
using System.Collections;

public class BT_DamagingScript : MonoBehaviour {

	// DamagingScript:
	//		When this object collides with any object of the predetemined Tags, damage is dealt to that object.

	public int damageAmount = 10;
	public string[] canHit = {"P1"};
	public bool destoryOnHit = true;

	// Damage is dealt to the player if this object collides with the player
	void OnTriggerEnter2D(Collider2D other) {
		foreach (string objTag in canHit) {
			if (other.tag == objTag) {
				other.GetComponent<BT_HealthScript>().DoDamage(damageAmount);
				if (destoryOnHit)
					Destroy(this.gameObject);
			}
		}
	}
}
