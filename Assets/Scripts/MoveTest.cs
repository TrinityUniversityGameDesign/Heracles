using UnityEngine;
using System.Collections;

public class MoveTest2 : MonoBehaviour {
	public string pathName;
	public double time;
	public double delay;
	public string easetype;
	public string looptype;

	/*Looptypes:
	 *	loop - will perfrom the animation in a looping fassion, starting each time from the beginning of the path
	 *	pingpong - will play the animation forward following the path and then retrace the path backwards then loop
	 *Eastypes:
	 *	the most commonly used are:
	 *		linear - constant motion throughout the animation
	 *		easeInOutSine - animation slows towards the begging and end speeding up slightly in the middle
	 *  others:
	 *		easeInQuad
	 *		easeOutQuad
	 *		easeInOutQuad
	 *		easeInCubic
	 *		easeOutCubic
	 *		easeInOutCubic
	 *		easeInQuart
	 *		easeOutQuart
	 *		easeInOutQuart
	 *		easeInQuint
	 *		easeOutQuint
	 *		easeInOutQuint
	 *		easeInSine
	 *		easeOutSine
	 *		easeInExpo
	 *		easeOutExpo
	 * 		easeInOutExpo
	 *		easeInCirc
	 *		easeOutCirc
	 *		easeInOutCirc
	 *		spring
	 *		easeInBounce
	 *		easeOutBounce
	 *		easeInOutBounce
	 *		easeInBack
	 *		easeOutBack
	 *		easeInOutBack
	 *		easeInElastic
	 *		easeOutElastic
	 *		easeInOutElastic
	 *		
	 *		additional doccumentation can be found at http://itween.pixelplacement.com/documentation.php
	 */
	// Use this for initialization
	void Start () {
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (pathName), "time", time, "looptype", looptype, "easetype", easetype, "delay", delay));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
