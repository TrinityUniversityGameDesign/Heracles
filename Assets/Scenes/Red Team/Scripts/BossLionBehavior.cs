using UnityEngine;
using System.Collections;

public class BossLionBehavior : MonoBehaviour {

	Transform target;
	public Transform enemyTransform;
	public float speed = 3f;
	public float attackDist = 3f;


	void Start () {
		
	}
	
	void FixedUpdate(){
		
		target = GameObject.FindWithTag ("P1").transform;
	
	}
	void Update(){
		
			// move towards the player if on the same plane

		if (enemyTransform.position.y - target.position.y < 2f) {


			if ((enemyTransform.position.x < target.position.x) && (target.position.x - enemyTransform.position.x  > attackDist)) {

								//rotates right
								if (enemyTransform.localScale.x < 0) {
										float rot = enemyTransform.localScale.x;
										enemyTransform.localScale = new Vector3 (-1 * rot, enemyTransform.localScale.y, enemyTransform.localScale.x);
								}

								//chase to the right
								float x = enemyTransform.position.x;
								enemyTransform.position = new Vector3 (x + (1 * speed * Time.deltaTime), enemyTransform.position.y, enemyTransform.position.z);

				if(target.position.x - enemyTransform.position.x < attackDist)
					GetComponent<SpriteRenderer>().color = Color.red; 
				else 
					if(target.position.x - enemyTransform.position.x > attackDist)
						GetComponent<SpriteRenderer>().color = Color.green;
			}

			if ((enemyTransform.position.x > target.position.x )&& (enemyTransform.position.x - target.position.x  > attackDist)) {

								//rotates left
								if (enemyTransform.localScale.x > 0) {
										float rot = enemyTransform.localScale.x;
										enemyTransform.localScale = new Vector3 (-1 * rot, enemyTransform.localScale.y, enemyTransform.localScale.x);
								}
		   
								//chase to the left
								float x = enemyTransform.position.x;
								enemyTransform.position = new Vector3 (x + (-1 * speed * Time.deltaTime), enemyTransform.position.y, enemyTransform.position.z);

				if(enemyTransform.position.x - target.position.x < attackDist)
					GetComponent<SpriteRenderer>().color = Color.red; 
				else 
					if(enemyTransform.position.x - target.position.x > attackDist)
						GetComponent<SpriteRenderer>().color = Color.green;
						}
			}
	}
}