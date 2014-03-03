using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class FlipperLadder : MonoBehaviour
{
	 

	/// <summary>
    /// Total hitpoints
    /// </summary>
	public int numLadders = 5;
	public string lad1;
	public string lad2;
	public string lad3;
	public string lad4;
	public string lad5;
	public bool isEnemy;
	public bool destroyshot;

    /// <summary>
    /// Enemy or player?
    /// </summary>

    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage( )
    {
		int i = 1;
		//for (i = 1; i <= numLadders; i++) {

						GameObject obj1 = GameObject.Find (lad1);
						GameObject obj2 = GameObject.Find (lad2);
						GameObject obj3 = GameObject.Find (lad3);
						GameObject obj4 = GameObject.Find (lad4);
						GameObject obj5 = GameObject.Find (lad5);

						Toggle (obj1);
						Toggle (obj2);
						Toggle (obj3);
						Toggle (obj4);
						Toggle (obj5);
				//}
	}

	void Start(){

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
               if(destroyshot)
					Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }
}