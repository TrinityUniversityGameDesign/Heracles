using UnityEngine;
using System.Collections;

public class MoveTest : MonoBehaviour {
	public string pathName;
	public double time;
	public double delay;
	public string easetype;
	public string looptype;


	// Use this for initialization
	void Start () {
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (pathName), "time", time, "looptype", looptype, "easetype", easetype, "delay", delay));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
