using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.IO;

public class GT_GhostScript : MonoBehaviour {
	
	public static float d = 1;
	public static Stopwatch directionTimer = new Stopwatch();
	public static Stopwatch fadingTimer = new Stopwatch();
	public int fade = 1; //1 for fade away, -1 for fade in

	Color lecolor;
	double stableTime;
	double fadeTime;
	double movingTime;
	
	// Use this for initialization
	void Start () {
		directionTimer.Start ();
		fadingTimer.Start ();
		//stableTime = (double)Random.Range (5, 15);
		//fadeTime = (double)Random.Range (3, 10);
		//5movingTime = (double)Random.Range(2,10);
		stableTime = 10;
		fadeTime = 5;
		movingTime = 3;
	}
	
	// Update is called once per frame
	void Update () {
		//somehow allow for multiple instances of the timer? for each ghost?
		if (directionTimer.Elapsed > System.TimeSpan.FromSeconds(movingTime)) {
			d = -d;
			flipDirection();
			directionTimer = new Stopwatch();
			directionTimer.Start ();
		}
		
		if (fadingTimer.Elapsed > System.TimeSpan.FromSeconds (stableTime)) {
			//Time has passed the 10 seconds of statis
			if(fadingTimer.Elapsed < System.TimeSpan.FromSeconds(stableTime + fadeTime)) {
				//Time is during the 5 second fade time
				//Crrent/max * 255
				
				
				double current = (fadingTimer.Elapsed- System.TimeSpan.FromSeconds(stableTime)).TotalSeconds; // 
				//System.Diagnostics.Debug.WriteLine(current);
				//System.Diagnostics.Debug.WriteLine(total);
				if(fade == -1) {
					current = fadeTime - current;
				}
				
				double per = current / fadeTime;
				
				lecolor = Color.Lerp(Color.white, Color.clear, (float)per);
				renderer.material.color = lecolor;
				
				
				/*double current = (fadingTimer.Elapsed - System.TimeSpan.FromSeconds(10)).TotalSeconds;
				System.Diagnostics.Debug.WriteLine(current);
				double total = 5.0;
				System.Diagnostics.Debug.WriteLine(total);
				if(fade == -1) {
					current = total - current;
				}
				fade *= -1;
				double per = current / total;
				System.Diagnostics.Debug.WriteLine(per);
				var temp = renderer.material.color;
				temp.a = (float)(per);
				renderer.material.color = temp;*/
			} else {
				//time is past 15 seconds
				fadingTimer = new Stopwatch();
				fadingTimer.Start();
				fade *= -1;
			}
			
			
		}
		
		
	}
	
	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2 (d * 1.5f , 0);
	}
	
	public void flipDirection() {
		Vector3 transScale = transform.localScale;
		transScale.x *= -1;
		transform.localScale = transScale;
	}
}
