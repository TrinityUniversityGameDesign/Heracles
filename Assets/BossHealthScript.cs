using UnityEngine;
using System.Collections;

public class BossHealthScript : MonoBehaviour {
	
	public int maxHealth = 2;
	public int currenthealth=2;
	//public Texture2D heart = Resources.Load("TEMPheart") as Texture2D;
	public Texture2D heart = (Texture2D)Resources.LoadAssetAtPath("Resources/TEMPheart.png", typeof(Sprite));
	//private GameObject dude = new GameObject.FindGameObjectsWithTag("P1");
	public static Vector2 respawnPos = new Vector2(21,2);
	
	
	public void damagePlayer(int damage)
	{
		currenthealth-=damage;
		if (currenthealth <= 0) {
			//Destroy (gameObject);
			gameObject.transform.position = GRE_PS_Checkpoint.respawnPos;
			currenthealth=maxHealth;
			if (GameObject.FindGameObjectsWithTag("ArtemisPoint").Length <= 0)
				GetComponent<GRE_PS_Checkpoint>().EnableDeathFade();
		}
	}
	
	public void healPlayer(int healing) {
		currenthealth += healing;
	}
	
	void OnGUI() {
		
		//TODO save pos as var, make ifs into loop
		if(currenthealth>=1) GUI.DrawTexture (new Rect(750,20,50,25), heart, ScaleMode.ScaleToFit);
		if(currenthealth>=2) GUI.DrawTexture (new Rect(800,20,50,25), heart, ScaleMode.ScaleToFit);
		if(currenthealth>=3) GUI.DrawTexture (new Rect(850,20,50,25), heart, ScaleMode.ScaleToFit);
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider.tag == "Shot" || otherCollider.tag == "Enemy") {
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
}
