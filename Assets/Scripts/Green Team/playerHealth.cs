using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

	public int maxHealth = 2;
	public int currenthealth=2;

	//private GameObject dude = new GameObject.FindGameObjectsWithTag("P1");
	public static Vector2 respawnPos = new Vector2(21,2);

	public void damagePlayer(int damage)
	{
		currenthealth-=damage;
		if (currenthealth <= 0) {
			//Destroy (gameObject);
			gameObject.transform.position = GRE_PS_Checkpoint.respawnPos;
		}
	}

	public void healPlayer(int healing) {
		currenthealth += healing;
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

		healthPack hp = otherCollider.gameObject.GetComponent<healthPack>();
		{
			if(currenthealth+hp.healAmount <= maxHealth) {
				healPlayer(hp.healAmount);
				Destroy(hp.gameObject);		 
			}
		}
	}
}
