using UnityEngine;
using System.Collections;

public class GroundBreak : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider.gameObject.tag == "P1") {
			Destroy(this.gameObject.transform.parent.gameObject);
		}
	}
}
