using UnityEngine;
using System.Collections;

public class PositionLadderScript : MonoBehaviour {

	public GameObject playerObject;
	public bool canClimb = false;
	public float speed = 1f;
	public float tick = .1f;
	public float enterDelay = .2f;

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	private bool dontStop = false; 
	private Vector2 topL;
	private Vector2 botR;

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

		topL = new Vector2 (minX, maxY);
		botR = new Vector2 (maxX, minY); 


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

	void FixedUpdate() {
		canClimb = false; 

		Collider2D[] allColliders = Physics2D.OverlapAreaAll(topL, botR);
		foreach (Collider2D thatCollider in allColliders){
			if (thatCollider.gameObject == playerObject)
				canClimb = true; 
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
