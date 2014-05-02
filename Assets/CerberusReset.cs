using UnityEngine;
using System.Collections;

public class CerberusReset : MonoBehaviour {
	public GameObject Cerberus;
	public GameObject rocks;
	public CameraFollow camera;
	public SpawnStalactite stalactiteSpawning;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "P1" && CerberusActivate.CerberusActive) {
			Cerberus.SetActive(false);
			rocks.SetActive(false);
			camera.player = GameObject.FindGameObjectWithTag("P1").transform;
			camera.xMargin = 1f;
			camera.yMargin = 1f;
			camera.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,-1);
			CerberusActivate.CerberusActive = false;
			stalactiteSpawning.end();
		}
	}
}
