using UnityEngine;
using System.Collections;

public class PressurePlateChildScript : MonoBehaviour {
	public bool activate_Me = false; 

	public bool alreadyGoing = false; 
	public Vector2 LocA = new Vector2 (0f, 0f);
	public Vector2 LocB = new Vector2 (0f, 0f);
	public Vector2 currentLocation = new Vector2(0f,0f);
	public string state = "A"; 
	public float waitA = .5f;
	public float Xvel = 1f;
	public float Yvel = 1f;
	public float speed = 2f; 
	public float triggerDelay = 0f; 
	public bool vertOnly = true;
	public bool horizOnly = false; 
	public bool resetWhenDone = false;
	public bool resetMe = false;
	public string resetState = "waitB";
	public bool currentlyBetween = false; 
	private bool btwnX = false;
	private bool btwnY = false; 

	private bool left = false;
	private int xMult = 1;
	private bool down = false;
	private int yMult = 1; 
	private float angle;
	private int waitCounter = 0;


	// Use this for initialization
	void Start () {
		LocB = gameObject.transform.Find("LocB").position;
		LocA = transform.position;
		if(LocA.x < LocB.x){
			left = true;
			xMult = -1;
		}
		if(LocA.y < LocB.y){
			down = true;
			yMult = -1; 
		}
	// Trigonometry here
		/*
		float adj = LocA.x - LocB.x;
		if (adj < 0)
			adj *= -1;
		float opp = LocA.y - LocB.y;
		if (opp < 0)
			opp *= -1;

		angle = Mathf.Atan ((opp / adj));

		xMult *= Mathf.
	*/
			state = "start";
	}
	
	IEnumerator myWait(float myWait, string nextState){
		state = "waiting";
		yield return new WaitForSeconds(myWait);
		state = nextState;
		if (nextState == "start")
			alreadyGoing = false; 
	}

	
	// Update is called once per frame
	void Update () {
		currentLocation = transform.position; 

		if (transform.position.x >= Mathf.Min (LocA.x, LocB.x) && transform.position.x <= Mathf.Max (LocA.x, LocB.x))
			btwnX = true;
		else
			btwnX = false;
		if (transform.position.y >= Mathf.Min (LocA.y, LocB.y) && transform.position.y <= Mathf.Max (LocA.y, LocB.y))
			btwnY = true;
		else 
			btwnY = false; 

		if (btwnX && btwnY)
			currentlyBetween = true;
		else 
			currentlyBetween = false; 


		switch(state){
		case "waiting":
			waitCounter +=1; 
			break;
		case "start":
			if(activate_Me)
				if(!alreadyGoing){
				alreadyGoing = true;
				if(triggerDelay == 0f){
					rigidbody2D.velocity = new Vector2 (Xvel*xMult, Yvel*xMult);
					state = "toB";
				}
				else
					StartCoroutine(myWait(triggerDelay,"otherStart"));
				}
			break;

		case "otherStart":
			if(alreadyGoing){ 
				rigidbody2D.velocity = new Vector2 (Xvel*xMult, Yvel*xMult);
				state = "toB"; 
			}
			break;
		case "toB":
			if(!currentlyBetween){
				transform.position = LocB;
				rigidbody2D.velocity = new Vector2 (0, 0);
				StartCoroutine(myWait(waitA,"toA"));
			}
			else
				rigidbody2D.velocity = new Vector2 (Xvel*xMult, Yvel*xMult);
			break;

		case "toA":
			if(!currentlyBetween){
				transform.position = LocA;
				rigidbody2D.velocity = new Vector2 (0, 0);
				StartCoroutine(myWait(waitA,"start"));
			}
			else
				rigidbody2D.velocity = new Vector2 (Xvel*xMult*(-1), Yvel*xMult*(-1));
			break;

		default:
			Debug.Log("didn't have a valid state");
			break; 
		}


		if (vertOnly)
			rigidbody2D.velocity = new Vector2 (0f, rigidbody2D.velocity.y);
		if (horizOnly)
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0f);

	}
}
