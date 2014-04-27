using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	//public delegate void EventHandler();
	//public event EventHandler CollideWithPlayer;
	
	public GameObject[] adjacentPlatforms;

	public GameObject hunter;
	public GameObject prey;

	private Animator hindAnimator;

	// Use this for initialization
	void Start () {
		hunter = GameObject.FindWithTag("P1");
		prey = GameObject.FindWithTag("Hind");
		hindAnimator = prey.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D ( Collider2D collider )
	{
		GameObject other = collider.gameObject;	
		if (other == hunter) 
		{
			HindEvasion preyScript = prey.GetComponent<HindEvasion>();
			preyScript.CheckDistance(this.gameObject);
			System.Console.WriteLine ("Collision detected.");
		}
		if (other == prey) 
		{
			prey.rigidbody2D.velocity = Vector2.zero;
			hindAnimator.SetBool("Grounded", true);
		}
		
	}
}
