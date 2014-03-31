using UnityEngine;
using System.Collections;

public class Lion_Boss_Flipper_Child_Script : MonoBehaviour {
	public bool activate_Me = false; 
	public GameObject Lion;
	private GameObject playerObject; 
	private BossLionBehavior Lion_Script;
	
	public bool alreadyGoing = false; 
	public Vector2 LocA = new Vector2 (0f, 0f);
	public Vector2 LocB = new Vector2 (0f, 0f);
	public string state = "A"; 
	public float waitA = .5f;
	public float Xvel = 1f;
	public float Yvel = 1f;
	public bool vertOnly = true;
	public bool horizOnly = false; 
	public bool resetWhenDone = false;
	public bool resetMe = false;
	public string resetState = "WaitB"; 
	
	// Use this for initialization
	void Start () {
		LocB = gameObject.transform.Find("LocB").position;
		LocA = transform.position;
		if(LocA.x > LocB.x){
			LocA.x = LocB.x;
			LocB.x = transform.position.x; 
		}
		if(LocA.y > LocB.y){
			LocA.y = LocB.y;
			LocB.y = transform.position.y; 
		}
		
		state = "Start";

		Lion = GameObject.FindWithTag("Lion");
		Lion = GameObject.FindGameObjectWithTag ("Lion");
		playerObject = GameObject.FindWithTag ("P1");
		Lion_Script = Lion.GetComponent<BossLionBehavior> ();
		
	}
	
	IEnumerator myWait(){
		yield return new WaitForSeconds(waitA);
		
	}
	
	void toA(){
		if (state == "ToA") {
			rigidbody2D.velocity = new Vector2 (Xvel*(-1f), Yvel*(-1f));
			
		}
		
	}
	
	void toB(){
		if (state == "ToB") {
			
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (resetState == state)
			resetMe = true; 
		
		if (activate_Me && !alreadyGoing) {
			rigidbody2D.velocity = new Vector2 (Xvel, Yvel);
			alreadyGoing = true; 
		}
		
		if(!vertOnly)
		if (transform.position.x > LocB.x) {
			transform.position = LocB;
			rigidbody2D.velocity = new Vector2 (0, 0);
			state = "WaitB";
			alreadyGoing = false;
		}
		if(!vertOnly)
		if (transform.position.x < LocA.x) {
			transform.position = LocA;
			rigidbody2D.velocity = new Vector2 (0, 0);
			state = "WaitA";
			alreadyGoing = false;
		}
		
		if(!horizOnly)
		if (transform.position.y < LocA.y) {
			transform.position = LocA;
			rigidbody2D.velocity = new Vector2 (0, 0);
			state = "WaitA";
			alreadyGoing = false;
		}
		if(!horizOnly)
		if (transform.position.y > LocB.y) {
			transform.position = LocB;
			rigidbody2D.velocity = new Vector2 (0, 0);
			state = "WaitB";
			alreadyGoing = false;
		}
		
		if (!activate_Me)
			alreadyGoing = false;
		
		if (resetMe && resetWhenDone && state == resetState) {
			transform.position = LocA; 
			state = "Start";
			resetMe = false; 
		}

		if (resetMe) {
			resetMe = false;
			transform.position = LocA;
			state = "Start"; 
			alreadyGoing = false;
			activate_Me = false;
			gameObject.renderer.material.color = Color.white;

		}
	}

	void OnTriggerEnter2D (Collider2D other) {


		if (other.gameObject == Lion) {
			gameObject.renderer.material.color = Color.red;
			Lion_Script.spike_hit = true;
		}
		if (other.gameObject == playerObject) {
			gameObject.renderer.material.color = Color.black;	
			playerObject.rigidbody2D.AddForce( new Vector2 (0, 1500f)); 
		}
		if (Lion == null)
			gameObject.renderer.material.color = Color.gray;
	}

}
