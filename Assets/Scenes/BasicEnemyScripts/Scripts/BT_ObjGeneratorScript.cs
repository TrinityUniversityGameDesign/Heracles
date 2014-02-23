using UnityEngine;
using System.Collections;

public class BT_ObjGeneratorScript : MonoBehaviour {

	// ObjGeneratorScript:
	// 		Generates any pre-determined object on a given interval.
	//		NEEDS WORK AND ADDED FUNCTIONALITY. IN PROGRESS.

	public GameObject obj;
	public float genRate = 0.5f;
	public float genCooldown = 0f;

	public int genDirectionX = 1;
	public int genDirectionY = 1;
	public float genSpeedX = 0.2f;
	public float genSpeedY = 0f;

	// Update is called once per frame
	void Update () {
		if (genCooldown > 0f)
			genCooldown -= Time.deltaTime;
		else
			Generate();
	}

	public void Generate() {
		if (CanGenerateNew) {
			genCooldown = genRate;
			GameObject newObj = Instantiate(obj) as GameObject;
			newObj.transform.position = transform.position;
			BT_MovementScript movementScript = newObj.GetComponent<BT_MovementScript>();
			if (movementScript != null) {
				movementScript.SetControlMethod("ConstantSpeed");
				movementScript.SetConstantSpeed(genDirectionX,genDirectionY,genSpeedX,genSpeedY);
			}
		}
	}
	
	public bool CanGenerateNew {
		get {
			return genCooldown <= 0f;
		}
	}
}
