using UnityEngine;
using System.Collections;

public class BossLionBehavior : MonoBehaviour {

	 Transform target;
	public Transform enemyTransform;
	public float speed = 3f;
	public float rotationSpeed=10f;
	Vector3 upAxis = new Vector3 (0f, 0f, 1f);
	
	void Start () {
		
	}
	
	void FixedUpdate(){
		
		target = GameObject.FindWithTag ("P1").transform;
	}
	
	void Update(){
		//rotate to look at the player
		
		transform.LookAt (target.position, upAxis);
		transform.eulerAngles = new Vector3 (0f, 0f, transform.eulerAngles.z); 

		;
		
		
		
		//move towards the player
	
		if (enemyTransform.position.x < target.position.x ) {

			float x = enemyTransform.position.x;


			enemyTransform.position =  new Vector3( x + (1*speed * Time.deltaTime),enemyTransform.position.y, enemyTransform.position.z);
		}

		if (enemyTransform.position.x > target.position.x) {
		
			float x = enemyTransform.position.x;
			enemyTransform.position =  new Vector3( x + (-1*speed * Time.deltaTime),enemyTransform.position.y, enemyTransform.position.z);
		}
		//if on top of player
		if (enemyTransform.position.x == target.position.x) {
			enemyTransform.position = enemyTransform.position;
		}

		if(enemyTransform.position.x == target.position.x && enemyTransform.position.y == target.position.y)
		{

		}


	}

}
