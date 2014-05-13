using UnityEngine;
using System.Collections;

public class Artemismove : MonoBehaviour {

	int randmov = 0;
	public float genRate = 0.5f;
	public float genCooldown = 3f;

	private Animator anim;
	private bool facingRight = true;
	private float difficultyMod = 1;
	private GameObject hind;
	private bool canShoot = true;

	public GameObject deathFader;
	private GameObject deathfader;
	private bool fade = false;
	private bool check = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		StartCoroutine(WaitAndShoot(3f));
		hind = GameObject.Find("GoldenHindRider");
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag("P1").Length == 0) {
			if (!check) {
				canShoot = false;
				anim.SetBool("playerDead",true);
				rigidbody2D.gravityScale = 0.5f;
				deathfader = Instantiate(deathFader,new Vector3(0f,14f,Camera.main.transform.position.z+1),Quaternion.identity) as GameObject;
				deathfader.GetComponent<BT_DecayScript>().DecayNow(2f);
				Color tempColor = deathfader.GetComponent<MeshRenderer>().material.color;
				tempColor.a = 0.0f;
				deathfader.GetComponent<MeshRenderer>().material.color = tempColor;
				fade = true;
				check = true;
			}
		}
		if (GameObject.FindGameObjectsWithTag ("Hind").Length == 0 && !check) {
			canShoot = false;
			GameObject sceneChange = GameObject.Find ("SceneChangeCheckpoint");
			sceneChange.renderer.enabled = true;
			sceneChange.GetComponent<SceneChangeScript>().enabled = true;
			check = true;
		}
		if (canShoot) {
			if (GameObject.FindGameObjectWithTag("P1").transform.position.x < transform.position.x && facingRight)
				flipDirection();
			if (GameObject.FindGameObjectWithTag("P1").transform.position.x > transform.position.x && !facingRight)
				flipDirection();
			if (hind.GetComponent<BT_HealthScript>().GetHealth() < 3)
				difficultyMod = 1.5f;
			if (hind.GetComponent<BT_HealthScript>().GetHealth() < 3)
				difficultyMod = 2f;
		}
		if (fade) {
			Color tempColor = deathfader.GetComponent<MeshRenderer>().material.color;
			tempColor.a += 0.009f;
			deathfader.GetComponent<MeshRenderer>().material.color = tempColor;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Main Stage") {
			GetComponent<BoxCollider2D>().isTrigger = false;
			rigidbody2D.velocity = Vector3.zero;
			anim.SetBool("grounded",true);
			rigidbody2D.gravityScale = 0f;
			StartCoroutine(RestartLevel(2f));
		}
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

	// Starts shooting Animation
	IEnumerator WaitAndShoot(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (canShoot) {
			anim.SetTrigger("doShoot");
			StartCoroutine(Shoot(0.4f));
		}
	}

	// Shoots arrow, starts waiting to start teleport animation
	IEnumerator Shoot(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (canShoot) {
			GetComponent<BT_ObjGeneratorScript>().Generate();
			StartCoroutine(WaitAndTeleport(1.5f/difficultyMod));
		}
	}

	// Starts teleport animation
	IEnumerator WaitAndTeleport(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (canShoot) {
			anim.SetTrigger("doTeleport");
			StartCoroutine(WaitAndMove(0.4f));
		}
	}

	// Move Artemis, waits to shoot again
	IEnumerator WaitAndMove(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (canShoot) {
			MoveArtemis();
			StartCoroutine(WaitAndShoot(2.6f/difficultyMod));
		}
	}

	IEnumerator RestartLevel(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel("GWBoss");
	}
}
