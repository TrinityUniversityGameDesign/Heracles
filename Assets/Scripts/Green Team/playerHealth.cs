using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

	public int health=2;

	//private GameObject dude = new GameObject.FindGameObjectsWithTag("P1");
	public static Vector2 respawnPos = new Vector2(21,2);

	public void damagePlayer(int damage)
	{
		health-=damage;
		if (health <= 0) {
			Destroy (gameObject);
			//dude.transform.position = respawnPos;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		projectile proj = otherCollider.gameObject.GetComponent<projectile>();
		if (proj!= null)
		{
			damagePlayer(proj.damage);
			Destroy(proj.gameObject); 
		}
	}
}
