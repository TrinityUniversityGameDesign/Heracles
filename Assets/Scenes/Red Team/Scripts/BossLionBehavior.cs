using UnityEngine;
using System.Collections;

public class BossLionBehavior : MonoBehaviour {




	/*
	GameObject greenpaw = gameObject.transform.Find("greenpaw").gameObject;

	GameObject redpaw = gameObject.transform.Find("redpaw").gameObject;

	GameObject lion = gameObject.transform.Find("BossLion").gameObject;



	// Use this for initialization
	void Start () {

		redpaw.Sprite = false;
		greenpaw.Sprite = false;

	}



	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		currentpos = lion.Vector2;
		lion.Vector2.MoveTowards (currentpos, redpaw.Vector2, 3);

	}

	/*void OnTriggerEnter2D(Collider2D otherCollider)
	{
		currentpos = lion.Vector2;
		lion.Vector2.MoveTowards (currentpos, greenpaw.Vector2, 3);
		
	}
      */


}
