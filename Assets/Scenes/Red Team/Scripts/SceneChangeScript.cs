using UnityEngine;
using System.Collections;

public class SceneChangeScript : MonoBehaviour {
	
	public string level;
	public string publicLabel = "";
	bool hasCollided = false;
	string label = "Press N for the next level or press M for the tutorial level.";
	bool tutorial = false;
	bool next = false;
	GameObject backgroundMusic;
	public bool stopMusic;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate() {
		if (tutorial) {
			Application.LoadLevel("TutorialStartingLevel");
		}
		
		if (next) {
			Application.LoadLevel(level);
		}
	}
	
	void OnGUI() {
		if (hasCollided == true)
		{
			GUIStyle style = new GUIStyle();
			style.normal.textColor = Color.white;
			if(publicLabel == "")
				GUI.Label(new Rect(Screen.width/2, Screen.height/2-100, 100, 100), label, style);
			else {
				GUI.Label(new Rect(Screen.width/2, Screen.height/2-100, 100, 100), publicLabel, style);
			}
		}
	}
	
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("P1")) {
			hasCollided = true;
		}
	}
	
	void OnTriggerStay2D(Collider2D other) {
		//backgroundMusic = (GameObject.FindGameObjectsWithTag ("Music"))[0];	
		//commented because it breaks scene change - please be careful
		if(Input.GetKey(KeyCode.N)) {
			if(stopMusic) {
				Destroy(backgroundMusic.gameObject);
			}
			next = true;
		}
		if(Input.GetKey(KeyCode.M)){
			if(stopMusic) {
				Destroy(backgroundMusic.gameObject);
			}
			tutorial = true;
		}
	}
	
	void OnTriggerExit2D() {
		hasCollided = false;
	}
}