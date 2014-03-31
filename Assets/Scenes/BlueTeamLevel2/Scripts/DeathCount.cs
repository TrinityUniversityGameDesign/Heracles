using UnityEngine;
using System.Collections;

public class DeathCount : MonoBehaviour {
	public GUIText deathCountText;
	public double deathCount = 0;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		deathCountText.text = "Number of Deaths " + deathCount;
	
	}
}
