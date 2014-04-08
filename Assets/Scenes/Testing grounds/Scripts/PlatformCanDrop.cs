using UnityEngine;
using System.Collections;

public class PlatformCanDrop : MonoBehaviour {
	
	public GameObject playerObject;
	public bool canDrop = false;
	public bool dropping = false;
	public string horizAxisName = "Horizontal";
	public string jumpAxisName = "Vertical";
	public float vertAx = 0.0f;
	public bool isColliding = false;
	private OneWayPlatform otherScript;


	// Update is called once per frame
	void Update () {
		otherScript = gameObject.GetComponent<OneWayPlatform>();

		vertAx = Input.GetAxis (jumpAxisName); 
		bool drop = false;

		
		if(Input.GetAxis (jumpAxisName) < 0)
			drop = true;
		
		 if (drop && canDrop) {
			Drop();
		}
		if (isColliding)
						otherScript.isClose = true; 
	}

	void Drop(){
		dropping = true;
		gameObject.collider2D.enabled = false;
	}
	void StopDrop(){
		gameObject.collider2D.enabled = true;
		dropping = false; 
	}
	
	void Start () {
		playerObject = GameObject.FindWithTag("P1");
		this.enabled = false;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		isColliding = true;
		if (other.gameObject == playerObject) {
			canDrop = true;
			this.enabled = true;
			otherScript.enabled = true;
			otherScript.isClose = true;
		}
	}
	void OnTriggerExit2D (Collider2D other) {
		isColliding = false;
		if (other.gameObject == playerObject) {
			canDrop = false;
			if(dropping)
				StopDrop();
		}
	}
}
