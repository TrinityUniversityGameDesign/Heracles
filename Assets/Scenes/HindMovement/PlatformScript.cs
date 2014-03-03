using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	//public delegate void EventHandler();
	//public event EventHandler CollideWithPlayer;

	public GameObject hunter;
	public GameObject prey;
	public GameObject[] adjacentPlatforms;

	// Use this for initialization
	void Start () {
	
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

	}
}
