using UnityEngine;
using System.Collections;

public class MasterLadderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject obj1 = GameObject.Find("LadderType1");
		GameObject obj2 = GameObject.Find("LadderType1.1");
		GameObject obj3 = GameObject.Find("LadderType2");
		GameObject obj4 = GameObject.Find("LadderType2.1");
		GameObject obj5 = GameObject.Find("LadderType5");
		GameObject obj6 = GameObject.Find("LadderType5.1");
		GameObject obj7 = GameObject.Find("LadderType7");
		GameObject obj8 = GameObject.Find("LadderType7.1");
		GameObject obj9 = GameObject.Find("LadderType8");
		GameObject obj10 = GameObject.Find("LadderType8.1");

		Toggle (obj1);
		Toggle (obj2);
		Toggle (obj3);
		Toggle (obj4);
		Toggle (obj5);
		Toggle (obj6);
		Toggle (obj7);
		Toggle (obj8);
		Toggle (obj9);
		Toggle (obj10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Toggle(GameObject obj){
		if (obj.collider2D.enabled == false)
			Enable (obj);
		else
			Disable (obj);
	}
	
	void Disable(GameObject obj){
		obj.collider2D.enabled = false; 
		obj.renderer.material.color = Color.grey;
	}
	
	void Enable(GameObject obj){
		obj.collider2D.enabled = true; 
		obj.renderer.material.color = Color.green;
	}
}
