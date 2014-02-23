using UnityEngine;
using System.Collections;

public class BT_DemoScript : MonoBehaviour {

	private TextMesh score;

	// Use this for initialization
	void Start () {
		score = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Player") != null)
			score.text = GameObject.FindGameObjectWithTag("Player").GetComponent<BT_HealthScript>().GetHealth().ToString();
		else {
			score.text = "0";
			GameObject.FindGameObjectWithTag("Enemy").GetComponent<BT_ObjGeneratorScript>().enabled = false;
			GameObject.FindGameObjectWithTag("Enemy").GetComponent<BT_MovementScript>().enabled = false;
		}
	}
}
