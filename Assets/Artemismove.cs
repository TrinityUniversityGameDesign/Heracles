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
		GameObject[] TeleportPoints = GameObject.FindGameObjectsWithTag("ArtemisPoint");
		randmov = Random.Range(0, TeleportPoints.Length);
		transform.position = TeleportPoints[randmov].transform.position;
		genCooldown = genRate;
	}
}
