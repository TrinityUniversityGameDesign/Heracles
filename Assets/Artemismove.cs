using UnityEngine;
using System.Collections;

public class Artemismove : MonoBehaviour {

	int randmov = 0;
	public float genRate = 0.5f;
	public float genCooldown = 3f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update (){
		if (genCooldown > 0f)
			genCooldown -= Time.deltaTime;
		else
			MoveArtemis();
	}

	void MoveArtemis () {
		randmov = Random.Range(1, 6);
		//randmov = 5;
		print (randmov.ToString());
		if (randmov == 1) {
			
			Vector3 temp = transform.position;
			temp.y = 7.0f; 
			temp.x = 0.0f;
			transform.position = temp;
			
		}
		
		if (randmov == 2) {
			
			Vector3 temp = transform.position; 
			temp.x = 10.0f;
			temp.y = 8.0f; 
			transform.position = temp; 
			
		}

		if (randmov == 3) {
			
			Vector3 temp = transform.position; 
			temp.x = -10.0f;
			temp.y = 4.0f; 
			transform.position = temp; 
			
		}

		if (randmov == 4) {
			
			Vector3 temp = transform.position; 
			temp.x = -5.0f;
			temp.y = 13.0f; 
			transform.position = temp; 
			
		}

		if (randmov == 5) {
			
			Vector3 temp = transform.position; 
			temp.x = 5f;
			temp.y = 13.0f; 
			transform.position = temp; 
			
		}
		genCooldown = genRate;
	}
}
