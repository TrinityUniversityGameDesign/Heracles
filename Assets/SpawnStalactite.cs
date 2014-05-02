using UnityEngine;
using System.Collections;

public class SpawnStalactite : MonoBehaviour {
	public GameObject stalacPrefab;
	public Transform pos;
	public int minGap;
	public int timePer;
	public double spawnChance;
	private int sinceLast;
	private int timeLeft;

	// Use this for initialization
	void Start () {
		sinceLast = 0;
		timeLeft = 0;
	}

	void FixedUpdate () {
		if (timeLeft > 0) {
			--timeLeft;
			sinceLast++;
			if(sinceLast > minGap) {
				double prob = Random.Range(0f,1f);
				if(prob < spawnChance) {
					spawnNew();
				}
			}
		}
	}

	public void BeginFalling() {
		timeLeft = timePer;
	}

	public void end() {
		timeLeft = 0;
	}

	void spawnNew() {
		sinceLast = 0;
		GameObject newObj = Instantiate(stalacPrefab) as GameObject;
		newObj.transform.position = new Vector3 (pos.position.x + Random.Range (-8, 6), pos.position.y, 0);
	}
}
