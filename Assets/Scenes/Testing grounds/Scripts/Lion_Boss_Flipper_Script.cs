using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class Lion_Boss_Flipper_Script : MonoBehaviour
{
	
	
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int mode = 1;
	public int numModes = 2;
	private Lion_Boss_Flipper_Child_Script childScript;
	private GameObject child1;
	private GameObject child2;
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;
	
	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		if (mode == 1)
		{
		//	child2.active = true; 
			childScript = child2.GetComponent<Lion_Boss_Flipper_Child_Script>();
			childScript.activate_Me = true;
			child2.renderer.material.color = Color.green;

			child1.renderer.material.color = Color.blue;

		}
		
		if (mode == 2) {
		//	child1.active = true;
			childScript = child1.GetComponent<Lion_Boss_Flipper_Child_Script>();
			childScript.activate_Me = true;
			child1.renderer.material.color = Color.green; 

			child2.renderer.material.color = Color.blue; 
		}
		
		mode += 1;
		
		if (mode > numModes)
			mode = 1;
	}
	
	void Start(){
		child1 = gameObject.transform.Find("Flipper_Child1").gameObject;;
		child2 = gameObject.transform.Find("Flipper_Child2").gameObject;;
		child2.renderer.material.color = Color.blue;
		//	child2.renderer.material.color = Color.gray;

	//	child2.active = false; 
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
				Damage(shot.damage);
				
				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}
}