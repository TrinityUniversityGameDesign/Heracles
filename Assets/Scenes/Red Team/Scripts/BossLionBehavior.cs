using UnityEngine;
using System.Collections;

public class BossLionBehavior : MonoBehaviour {


	bool left = false;
	bool right = false;
	int fallblock = rigidbody2D.velocity.y;

	// Use this for initialization
	void Start () {

		
	void OnTriggerEnter2D (Collider2D other) {
			if (other.gameObject.rigidbody2D.mass >= 1){
				fallblock == transform.ImagePosition.y;

				while (fallblock == transform.ImagePosition.y ){
					rigidbody2D.velocity.x = rigidbody2D.velocity.x*-1;


				}
			}
		}
	
	}
	


}
