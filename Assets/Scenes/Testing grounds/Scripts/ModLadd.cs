using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class ModLadd : MonoBehaviour
{
	
	
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int mode = 1;
	public int numModes = 2;
	
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;
	
	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage( )
	{
		if (mode == 1)
		{
			GameObject gateA = GameObject.Find("LadderType1");
			Disable(gateA);
			
			GameObject gateB = GameObject.Find("LadderTypeA");
			Enable(gateB); 
			
		}
		
		if (mode == 2) {
			GameObject gateB = GameObject.Find("LadderTypeA");
			Disable(gateB); 
			
			GameObject gateA = GameObject.Find("LadderType1");
			Enable (gateA);  
		}
		
		mode += 1;
		
		if (mode > numModes)
			mode = 1;
	}
	
	void Start(){
		//		GameObject gateA = gameObject.transform.Find("gateA").gameObject;
		GameObject gateB = gameObject.transform.Find("LadderTypeA").gameObject;
		Disable(gateB); 
	}
	
	void Disable(GameObject obj){
		obj.collider2D.enabled = false; 
		obj.renderer.material.color = Color.grey;
	}
	void Enable(GameObject obj){
		obj.collider2D.enabled = true; 
		obj.renderer.material.color = Color.green;
	}
	
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage();
				
				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}
}