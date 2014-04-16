using UnityEngine;
using System.Collections;

public class ParallaxBackground : MonoBehaviour
{
	public float ParallaxFactor = 10;
	private Transform player;
	private Vector3 last;

	void Start() {
		player = GameObject.FindGameObjectWithTag("P1").transform;
	}

	void FixedUpdate() {
		Vector3 now = player.position;
		float xpos = transform.position.x-((now.x - last.x)/ParallaxFactor);
		float ypos = transform.position.y-((now.y - last.y)/(ParallaxFactor+ParallaxFactor/2));
		transform.position = new Vector3(xpos,ypos,transform.position.z);
		last = now;
	}
}