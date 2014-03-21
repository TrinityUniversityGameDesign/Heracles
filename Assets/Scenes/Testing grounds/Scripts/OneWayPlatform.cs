using UnityEngine;
using System.Collections;

public class OneWayPlatform : MonoBehaviour {
	
	private GameObject playerObject;
	public bool isClose = false;
	public bool isGhost = false;
	public string whichWay = "up"; 
	public float platX;
	public float platY;
	private float height;
	private float width;
	public bool under;
	public bool over;
	public bool left;
	public bool right;

	void Awake() {
	}
	
	void Start () {
		Transform platBox = gameObject.transform; 
		
		playerObject = GameObject.FindWithTag("P1");
		platX = platBox.position.x;
		platY = platBox.position.y;
		width = platBox.localScale.x;
		height = platBox.localScale.y;
	}

	// Update is called once per frame
	void Update () {
		if (isClose) {
		
						float minx = platX - (width / 2.0f);
						float maxx = platX + (width / 2.0f); 
						float maxy = platY + (height / 2.0f);
						float miny = platY - (height / 2.0f);
		
						BoxCollider2D playerBox = playerObject.GetComponent<BoxCollider2D> (); 
		
						float psX = playerObject.transform.localScale.x;
						float psY = playerObject.transform.localScale.y;
						float poX = playerObject.transform.position.x;
						float poY = playerObject.transform.position.y; 
		
						float pminx = poX - ((playerBox.size.x * psX) / 2.0f) + playerBox.center.x;
						float pminy = poY - ((playerBox.size.y * psY) / 2.0f) + playerBox.center.y;
						float pmaxx = poX + ((playerBox.size.x * psX) / 2.0f) + playerBox.center.x;
						float pmaxy = poY + ((playerBox.size.y * psY) / 2.0f) + playerBox.center.y;


						under = (pmaxy < maxy);
						over = (pminy > maxy);
						left = (pmaxx < minx);
						right = (pminx > maxx); 

				switch (whichWay){
			case "up":
				if(under && !left && !right)
					Ghost();
				else if(over)
					StopGhost();
				break;
			case "down":
				if(over && !left && !right)
					Ghost();
				else if(under)
					StopGhost();
				break;
			case "right":
				if(left && !over && !under)
					Ghost();
				else if(right)
					StopGhost();
				break;
			case "left":
				if(right && !over && !under)
					Ghost(); 
				else if(left)
					StopGhost();
				break;
			default:
				Debug.Log("which way match case var wrong, default case happened");
				break; 	
			}
				}
	}
	
	void Ghost(){
		isGhost = true;
		gameObject.collider2D.enabled = false;
	}
	void StopGhost(){
		isGhost = false; 
		gameObject.collider2D.enabled = true;
	}

	

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == playerObject) {
						isClose = true;

						//non abreviated floats are the platforms, p+ floats are players
				}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject == playerObject) {
			isClose = false;
			StopGhost();
		}
	}
}
