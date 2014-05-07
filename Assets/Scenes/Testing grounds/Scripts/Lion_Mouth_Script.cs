using UnityEngine;
using System.Collections;

public class Lion_Mouth_Script : MonoBehaviour {
	private GameObject shot;
	private GameObject Lion;
	private BossLionBehavior Lion_Script;
	public AudioClip lionroar;

	public float hit_power = 9999f;
	public float flee_increase = .5f; 
	Animator anim;

	private BossHealthScript BHScript;


	// Use this for initialization
	void Start () {
		Lion = GameObject.FindWithTag("Lion");
		Lion_Script = Lion.GetComponent<BossLionBehavior> (); 
		BHScript = Lion.GetComponent<BossHealthScript> ();
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
			BHScript.currenthealth -= 1;
			Lion.audio.PlayOneShot (lionroar);
			Lion_Script.fleeing = true;

			Lion_Script.flee_time += flee_increase; 

			gameObject.active = false;

			if(Lion_Script.HP <=0){
			 anim =	Lion.GetComponent<Animator>();
			anim.SetBool ("roarState", false);
			anim.SetBool("deathState", true);
			anim.SetBool("permaState", true);
				Lion_Script.enabled = false;
			}
			Destroy(other.gameObject); 
				}
	}
}
