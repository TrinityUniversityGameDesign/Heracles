using UnityEngine;
//using System.Collections;
using System;

public class HindEvasion : MonoBehaviour {

	public GameObject startPlatform;

	private GameObject currentPlatform;
	private GameObject[] adjacentPlatforms;
	private Vector2 currentPosition;

	void ChangePosition ()
	{
		currentPosition = currentPlatform.transform.position;
		adjacentPlatforms = currentPlatform.GetComponent<PlatformScript> ().adjacentPlatforms;
		
		currentPosition.y += this.gameObject.transform.localScale.y;
		
		transform.position = currentPosition;
	}

	public void CheckDistance (GameObject triggerPlatform)
	{
		if (Array.Exists(adjacentPlatforms, platform => platform == triggerPlatform))
		{
			int i = 0;
			GameObject nextPlatform = adjacentPlatforms[i];
			GameObject[] adjacentToPlayer = triggerPlatform.GetComponent<PlatformScript> ().adjacentPlatforms;

			while ((Array.Exists(adjacentToPlayer, platform => platform == nextPlatform) || nextPlatform == triggerPlatform) && i < adjacentPlatforms.Length)
			{
				nextPlatform = adjacentPlatforms[i];
				i += 1;
			}

			if (!Array.Exists(adjacentToPlayer, platform => platform == nextPlatform) && nextPlatform != triggerPlatform)
			{
				currentPlatform = nextPlatform;
				ChangePosition();
			}
		}

	}

	// Use this for initialization
	void Start ()
	{
		currentPlatform = startPlatform;
		currentPosition = currentPlatform.transform.position;
		adjacentPlatforms = currentPlatform.GetComponent<PlatformScript> ().adjacentPlatforms;
		
		currentPosition.y += this.gameObject.transform.localScale.y;
		
		transform.position = currentPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1"))
		{
			System.Random random = new System.Random();
			int i = random.Next(0, adjacentPlatforms.Length);
			currentPlatform = adjacentPlatforms[i];
			ChangePosition();
		}
	}
}
