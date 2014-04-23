using UnityEngine;
using System.Collections;

public class PositionLadderScript : MonoBehaviour {

	public GameObject playerObject;
	public bool canClimb = false;
	public float speed = 1f;
	public float tick = .1f;
	public float enterDelay = .2f;
	public float exitDelay = .2f;

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	private bool dontStop = false; 
	private bool checkingPlayer = false;
	public Vector2 topL;
	public Vector2 botR;
	private PlayerControl playerScript;


	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindWithTag("P1");
		BoxCollider2D myCollider = gameObject.GetComponent<BoxCollider2D>();
		Vector2 size = myCollider.size;
		Vector2 center = myCollider.center; 

		minX = center.x - (size.x / 2f) + gameObject.transform.position.x;
		maxX = center.x + (size.x / 2f) + gameObject.transform.position.x;
		minY = center.y - (size.y / 2f) + gameObject.transform.position.y;
		maxY = center.y + (size.y / 2f) + gameObject.transform.position.y; 

//		topL = new Vector2 (minX, maxY);
//		botR = new Vector2 (maxX, minY); 

		float worldRight =  myCollider.transform.TransformPoint( myCollider.center + new Vector2( myCollider.size.x * 0.5f, 0)).x;
		float worldLeft =  myCollider.transform.TransformPoint( myCollider.center - new Vector2( myCollider.size.x * 0.5f, 0)).x;
		
		float worldTop =  myCollider.transform.TransformPoint( myCollider.center + new Vector2(0,  myCollider.size.y * 0.5f)).y;
		float worldBottom =  myCollider.transform.TransformPoint( myCollider.center - new Vector2(0,  myCollider.size.y * 0.5f)).y;
		
		topL = new Vector2 (worldLeft, worldTop);
		botR = new Vector2 (worldRight, worldBottom);



		this.enabled = false;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == playerObject) {
			this.enabled = true; 
			canClimb = true;
			playerObject.rigidbody2D.velocity = new Vector2(0, 0);
			StartCoroutine(enterWait()); 
			}
	}
	/*
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject == playerObject) {
						canClimb = false;
				}
	}
	*/
	// Update is called once per frame

	IEnumerator enterWait(){
		dontStop = true;
		yield return new WaitForSeconds (enterDelay);
		dontStop = false; 
	}

	IEnumerator exitWait(){

		yield return new WaitForSeconds (exitDelay);
	}

	void FixedUpdate() {
	//	if( !dontStop)

		Collider2D[] allColliders = Physics2D.OverlapAreaAll(topL, botR);
		bool wasInThere = false;
		foreach (Collider2D thatCollider in allColliders){
			if (thatCollider.gameObject == playerObject){
				wasInThere = true; 
			}
			if(!wasInThere){
				canClimb = false; 
				}
		}
		if (!dontStop)
		if (!canClimb) {
			this.enabled = false; 
				}
	}

	void Update () {


		if (canClimb) {
			playerObject.rigidbody2D.velocity = new Vector2(0f,0f);


			if(Input.GetButton ("Vertical") && Input.GetAxis("Vertical") > 0) {
				playerObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y + tick, playerObject.transform.position.z);
				//playerObject.rigidbody2D.gravityScale = 0; 

			/*	if(playerObject.transform.position.x < transform.position.x)
					playerObject.rigidbody2D.velocity = new Vector2 (1, playerObject.rigidbody2D.velocity.y) ;
				else
					playerObject.rigidbody2D.velocity = new Vector2 (-1, playerObject.rigidbody2D.velocity.y) ;
			*/
			}
			if(Input.GetButton ("Vertical") && Input.GetAxis("Vertical") < 0) {
				playerObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y - tick, playerObject.transform.position.z);
			//	playerObject.rigidbody2D.gravityScale = 0; 			
			}
		}
	}
}
