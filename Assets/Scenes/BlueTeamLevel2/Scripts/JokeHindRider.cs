using UnityEngine;
using System.Collections;

public class JokeHindRider : MonoBehaviour {

	public GameObject player;
	bool flag;
	float upPosition = 0;

	// Use this for initialization
	void Start () {
		flag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(flag) {
			upPosition = 2f;
			//player.transform.Translate(0, 2f, 0, Space.Self);
			//player.transform.localPosition = new Vector3 (0, 1f, 0);
		}
		//player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+upPosition, player.transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D other) {
		flag = true;
		transform.parent = player.transform;
		//player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+2f, player.transform.position.z);
	}
}
