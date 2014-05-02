using UnityEngine;
using System.Collections;

public class Artemismove : MonoBehaviour {

	int randmov = 0;
	public float genRate = 0.5f;
	public float genCooldown = 3f;

	private Animator anim;
	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		StartCoroutine(WaitAndShoot(3f));
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag("P1").transform.position.x < transform.position.x && facingRight)
			flipDirection();
		if (GameObject.FindGameObjectWithTag("P1").transform.position.x > transform.position.x && !facingRight)
			flipDirection();
	}

	void MoveArtemis () {
		GameObject[] TeleportPoints = GameObject.FindGameObjectsWithTag("ArtemisPoint");
		randmov = Random.Range(0, TeleportPoints.Length);
		if (transform.position != TeleportPoints[randmov].transform.position)
			transform.position = TeleportPoints[randmov].transform.position;
		else
			MoveArtemis();
		anim.SetTrigger("doTeleport");
	}

	void flipDirection() {
		facingRight = !facingRight;
		Vector3 transScale = transform.localScale;
		transScale.x *= -1;
		transform.localScale = transScale;
	}

	IEnumerator WaitAndShoot(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		anim.SetTrigger("doShoot");
		StartCoroutine(Shoot(0.4f));
	}

	IEnumerator Shoot(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		GetComponent<BT_ObjGeneratorScript>().Generate();
		StartCoroutine(WaitAndTeleport(1f));
	}

	IEnumerator WaitAndTeleport(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		anim.SetTrigger("doTeleport");
		StartCoroutine(WaitAndMove(0.4f));
	}

	IEnumerator WaitAndMove(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		MoveArtemis();
		StartCoroutine(WaitAndShoot(2.2f));
	}
}
