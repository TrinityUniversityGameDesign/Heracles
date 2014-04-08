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

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	
	private bool dontStop = false; 
	private Vector2 topL;
	private Vector2 botR;

	private Transform platBox;
	private BoxCollider2D platCollider;
	private Vector2 platColSize;
	private Vector2 platColCntr;

	private bool oneDisable= true;

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


		platBox = gameObject.transform; 
		platCollider = gameObject.GetComponent<BoxCollider2D>();
		platColSize = platCollider.size;
		platColCntr = platCollider.center; 

		playerObject = GameObject.FindWithTag("P1");


		platX = platBox.position.x;
		platY = platBox.position.y;
		width = platBox.localScale.x * platCollider.size.x;
		height = platBox.localScale.y * platCollider.size.y;

		if (oneDisable) {
			oneDisable = false;
						this.enabled = false;
				}
	}

	// Update is called once per frame
	void Update () {
		PlatformCanDrop dropRef =  gameObject.GetComponent<PlatformCanDrop>();

		isClose = false;
		Collider2D[] allColliders = Physics2D.OverlapAreaAll(topL, botR);
		foreach (Collider2D thatCollider in allColliders){
			if (thatCollider.gameObject == playerObject)
				isClose = true; 
		}

		if (isClose) {
		
						float minx = platX - (width / 2.0f) + (platBox.localScale.x * platColCntr.x);
			float maxx = platX + (width / 2.0f) + (platBox.localScale.x * platColCntr.x);
			float maxy = platY + (height / 2.0f)+ (platBox.localScale.y * platColCntr.y);
			float miny = platY - (height / 2.0f) + (platBox.localScale.y * platColCntr.y);
		
						BoxCollider2D playerBox = playerObject.GetComponent<BoxCollider2D>();
		
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


			if(dropRef.dropping && over && !left && !right)   // this allows drop-down platforms to work on all one ways
			{ Ghost();
				dropRef.dropping = false;
			}
			else
				switch (whichWay){
			case "up":
				if(under && !left && !right)
					Ghost();
				else if(over || right || left)
					StopGhost();
				break;
			case "down":
				if(over && !left && !right)
					Ghost();
				else if(under || right || left)
					StopGhost();
				break;
			case "right":
				if(left && !over && !under)
					Ghost();
				else if(right || under || over)
					StopGhost();
				break;
			case "left":
				if(right && !over && !under)
					Ghost(); 
				else if(left || under || over)
					StopGhost();
				break;
			default:
				Debug.Log("which way match case var wrong, default case happened");
				break; 	
			}
				}
		//if (!isClose)
		//				this.enabled = false;

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
		this.enabled = true;
		if (other.gameObject == playerObject) {
						isClose = true;
						//non abreviated floats are the platforms, p+ floats are players
				}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject == playerObject) {
			isClose = false;
			StopGhost();
			//this.enabled = false; 
		}

	}
}
