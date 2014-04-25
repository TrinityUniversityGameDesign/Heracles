using UnityEngine;
using System.Collections;

public class BossLionBehavior : MonoBehaviour {

	Transform target;
	public Transform enemyTransform;
	public float speed = 3f;
	public float attackDist = 3f;
	public int HP = 3;
	public bool spike_hit = false; 
	public float stun_time = 2f;
	public float attack_ko_power = 99900f;
	public float hit_delay = 1.0f;
	public bool can_hit = false;
	public float flee_time = 1.3f;
	public bool fleeing = false; 
	
	private GameObject mouth;
	private GameObject player;
	Animator anim;

	private bool stun = false;

	void Start () {
		mouth = gameObject.transform.Find("Lion_Mouth").gameObject;
		player = GameObject.FindWithTag ("P1");
		mouth.active = false;
		anim = GetComponent<Animator> ();
	}

	IEnumerator hitDelay(){
		yield return new WaitForSeconds(hit_delay);
		if (can_hit) {
			Vector2 temp = player.transform.position;
			temp.y= temp.y + .3f;
		

			if( player.transform.position.x > gameObject.transform.position.x){
				temp.x += .3f;
				player.rigidbody2D.AddForce( new Vector2 (attack_ko_power , 350f));
			}
			else {
				player.rigidbody2D.AddForce( new Vector2 (-1 * attack_ko_power , 350f));
				temp.x -=.3f;
			}

			player.transform.position = temp; 

		}
	}
	IEnumerator stunTime(){
		yield return new WaitForSeconds(stun_time);
		stun = false; 
		GetComponent<SpriteRenderer> ().color = Color.green; 
		mouth.active = false;

	}
	IEnumerator flee(){
		yield return new WaitForSeconds (flee_time); 
		fleeing = false; 
		}

	void FixedUpdate(){
		
		target = GameObject.FindWithTag ("P1").transform;
	
	}
	void Update(){

		// if hit by spike
		if (spike_hit) {
			spike_hit = false;
			GetComponent<SpriteRenderer> ().color = Color.white; 
			anim.SetBool ("movingState", false);
			anim.SetBool ("attackState", false);
			anim.SetBool ("roarState", true);
			stun = true;
			mouth.active = true;
			StartCoroutine(stunTime());
			anim.SetBool ("roarState", false);
				}



		//if stunned


		
			// move towards the player if on the same plane
		if (!stun)						
		if (enemyTransform.position.y - target.position.y < 2f) {

			if(fleeing){
				StartCoroutine(flee()); 
				stun = false; 


				
			}

						if(!fleeing)
						if ((enemyTransform.position.x < target.position.x) && (target.position.x - enemyTransform.position.x > attackDist)) {

								//rotates right
								if (enemyTransform.localScale.x < 0) {
										float rot = enemyTransform.localScale.x;
										enemyTransform.localScale = new Vector3 (-1 * rot, enemyTransform.localScale.y, enemyTransform.localScale.x);
								}

								//begin chase animation
								anim.SetBool ("movingState", true);

								//chase to the right
								float x = enemyTransform.position.x;
								enemyTransform.position = new Vector3 (x + (1 * speed * Time.deltaTime), enemyTransform.position.y, enemyTransform.position.z);

								if (target.position.x - enemyTransform.position.x < attackDist) {
										GetComponent<SpriteRenderer> ().color = Color.red; 
										anim.SetBool ("attackState", true);
										can_hit = true;
										StartCoroutine(hitDelay());
								} else 
					if (target.position.x - enemyTransform.position.x > attackDist) {
										GetComponent<SpriteRenderer> ().color = Color.green;
										anim.SetBool ("attackState", false);
										can_hit = false;
								}
						}

						if(!fleeing)
						if ((enemyTransform.position.x > target.position.x) && (enemyTransform.position.x - target.position.x > attackDist)) {

								//rotates left
								if (enemyTransform.localScale.x > 0) {
										float rot = enemyTransform.localScale.x;
										enemyTransform.localScale = new Vector3 (-1 * rot, enemyTransform.localScale.y, enemyTransform.localScale.x);
								}
		   
								//begin chase animation
								anim.SetBool ("movingState", true);

								//chase to the left
								float x = enemyTransform.position.x;
								enemyTransform.position = new Vector3 (x + (-1 * speed * Time.deltaTime), enemyTransform.position.y, enemyTransform.position.z);

								// if in attack range
								if (enemyTransform.position.x - target.position.x < attackDist) {
										GetComponent<SpriteRenderer> ().color = Color.red; 
										anim.SetBool ("attackState", true);
										can_hit = true;
										StartCoroutine(hitDelay());
				} else 
					if (enemyTransform.position.x - target.position.x > attackDist) {
										GetComponent<SpriteRenderer> ().color = Color.green;
										anim.SetBool ("attackState", false);
										can_hit = false;
								}
						}

				} else {
						//begin chase animation
						anim.SetBool ("movingState", false);
						anim.SetBool("attackState",false );
				}
	}
}