using UnityEngine;
using System.Collections;

public class Lion_Mouth_Script : MonoBehaviour {
	private GameObject shot;
	private GameObject Lion;
	private BossLionBehavior Lion_Script;

	public float hit_power = 9999f;
	public float flee_increase = .5f; 



	// Use this for initialization
	void Start () {
		Lion = GameObject.FindWithTag("Lion");
		Lion_Script = Lion.GetComponent<BossLionBehavior> (); 
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Shot"){
			if(other.transform.position.x < Lion.transform.position.x)
				Lion.rigidbody2D.AddForce( new Vector2(hit_power, 0));
			else
				Lion.rigidbody2D.AddForce( new Vector2( -1 * hit_power, 0));

			Lion_Script.HP -= 1;
			Lion_Script.fleeing = true;
			Lion_Script.flee_time += flee_increase; 

			gameObject.active = false;

			if(Lion_Script.HP <=0)
				Destroy(Lion); 

			Destroy(other.gameObject); 
				}
	}
}
