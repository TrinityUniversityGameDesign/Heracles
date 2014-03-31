using UnityEngine;
using System.Collections;

public class TimeText : MonoBehaviour {

	public GUIText timeText;
	public float timer = 0.00f; // initialize a timer that starts at 0.00
	



	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		timeText.text = "Time Elapsed " + timer.ToString ("0.0");
	}
}
