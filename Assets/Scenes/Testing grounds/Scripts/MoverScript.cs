using UnityEngine;
using System.Collections;

public class MoverScript : MonoBehaviour {

	public Vector2 LocA = new Vector2 (-6.5f, .65f);
	public Vector2 LocB = new Vector2 (0f, .65f);
	public string state = "A"; 
	public float waitA = .5f;
	public float vel = 1f;


	// Use this for initialization
	void Start () {

		transform.position = LocA;
		state = "WaitA";

	}

	IEnumerator myWait(){
		yield return new WaitForSeconds(waitA);
	if( state == "WaitA")
		toB();
	if (state == "WaitB")
						toA ();
	}

	void toA(){
		if (state != "ToA") {
			rigidbody2D.velocity = new Vector2 (vel*(-1), 0);
			state = "ToA";
		}
		if (transform.position.x < LocA.x) {
			transform.position = LocA;
			rigidbody2D.velocity = new Vector2 (0, 0);
			state = "WaitA";
		}
	}

	void toB(){
		if (state != "ToB") {
			rigidbody2D.velocity = new Vector2 (vel, 0);
			state = "ToB";
				}
		if (transform.position.x > LocB.x) {
			transform.position = LocB;
			rigidbody2D.velocity = new Vector2 (0, 0);
			state = "WaitB";
		}
	}

	// Update is called once per frame
	void Update () {
		if (state == "WaitA") {
				StartCoroutine(	myWait());
				}
		if (state == "ToB")
						toB ();
		if (state == "WaitB")
			StartCoroutine(	myWait());
		if (state == "ToA")
						toA ();
	
	}
}
