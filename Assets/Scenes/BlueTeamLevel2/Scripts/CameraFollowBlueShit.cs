using UnityEngine;
using System.Collections;

public class CameraFollowBlueShit : MonoBehaviour {

	public Transform player;
	float x;
	float y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x = player.position.x;
		y = player.position.y;

		transform.position = new Vector3 (x, y, transform.position.z);
	}
}
