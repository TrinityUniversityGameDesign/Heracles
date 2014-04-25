using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	private GameObject playerObject;
	public GameObject childObj;
	private PressurePlateChildScript childScript;
	public int isPressed = 0;

	private Vector2 topL;
	private Vector2 botR;
	private BoxCollider2D myCollider;
	private Collider2D[] addedColliders;

	// Use this for initialization
	void Start () {
		myCollider = gameObject.GetComponent<BoxCollider2D>();

		playerObject = GameObject.FindWithTag("P1");
		GameObject childObj = gameObject.transform.Find("PressureChild").gameObject;
		childScript = childObj.GetComponent<PressurePlateChildScript>();

		float worldRight =  myCollider.transform.TransformPoint( myCollider.center + new Vector2( myCollider.size.x * 0.5f, 0)).x;
		float worldLeft =  myCollider.transform.TransformPoint( myCollider.center - new Vector2( myCollider.size.x * 0.5f, 0)).x;
		
		float worldTop =  myCollider.transform.TransformPoint( myCollider.center + new Vector2(0,  myCollider.size.y * 0.5f)).y;
		float worldBottom =  myCollider.transform.TransformPoint( myCollider.center - new Vector2(0,  myCollider.size.y * 0.5f)).y;
		
		topL = new Vector2 (worldLeft, worldTop);
		botR = new Vector2 (worldRight, worldBottom);

	}
	/*
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.rigidbody2D.mass >= 1 || other.gameObject == playerObject) {
			isPressed++;
			//other.gameObject.rigidbody2D.velocity = new Vector2(0, 0);
			gotPressed();
				}
	}
	*/

	/*
	void OnTriggerExit2D (Collider2D other) {
			isPressed -= 1;
		gotReleased (); 
	}
	*/

	void FixedUpdate () {
		int count = 0;

		Collider2D[] allColliders = Physics2D.OverlapAreaAll(topL, botR);
		bool wasInThere = false;

		foreach (Collider2D thatCollider in allColliders){

			if(thatCollider.rigidbody2D != null)
			if (thatCollider.gameObject == playerObject || thatCollider.gameObject.rigidbody2D.mass >= 1){
				count +=1 ;
			}
		}
		isPressed = count; 


		if (isPressed >= 1)
						gotPressed ();
		else
						gotReleased ();

	}

	void gotPressed() {
		if (isPressed >= 1) {
			gameObject.renderer.material.color = Color.grey; 
			childScript.activate_Me = true; 
		}
	}
	void gotReleased(){
		if (isPressed <= 0) {
			//isPressed = 0;
			gameObject.renderer.material.color = Color.yellow; 
			childScript.activate_Me = false; 
				}
		}
}
