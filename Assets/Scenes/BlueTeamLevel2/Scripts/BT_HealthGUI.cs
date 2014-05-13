using UnityEngine;
using System.Collections;

public class BT_HealthGUI : MonoBehaviour {

	public Texture2D healthIcon;
	public int xStart = 20;
	public int yStart = 20;
	public bool flip = false;

	private BT_HealthScript healthScript;

	void OnGUI() {
		int currentHealth = healthScript.GetHealth ();
		//Debug.Log ("current health: " + currentHealth.ToString ());
		int space = 50;
		for (int i=1; i <= currentHealth; i++)
		{
			if (flip == true)
			{
				GUI.DrawTexture (new Rect((xStart - space*(i-1)),yStart,50,25), healthIcon, ScaleMode.ScaleToFit);
			}
			else
			{
				GUI.DrawTexture (new Rect((xStart + space*(i-1)),yStart,50,25), healthIcon, ScaleMode.ScaleToFit);
			}
		}
	}

	// Use this for initialization
	void Start () {
		healthScript = GetComponent<BT_HealthScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


