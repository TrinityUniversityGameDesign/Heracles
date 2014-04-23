using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class FlipperScript : MonoBehaviour
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


	//used to determine animation state - do not touch.
	public bool animStateR = false;
	public bool animate = false;
	private Animator anim;
    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {

        if (mode == 1)
        {
			GameObject gateA = gameObject.transform.Find("gateA").gameObject;
			gateA.active = false; 

			GameObject gateB = gameObject.transform.Find("gateB").gameObject;
			gateB.active = true; 

        }

		if (mode == 2) {
			GameObject gateB = gameObject.transform.Find("gateB").gameObject;
			gateB.active = false; 
			
			GameObject gateA = gameObject.transform.Find("gateA").gameObject;
			gateA.active = true; 
				}

			mode += 1;

		if (mode > numModes)
			mode = 1;
    }

	void Start(){
//		GameObject gateA = gameObject.transform.Find("gateA").gameObject;
		GameObject gateB = GameObject.Find("gateB");
		gateB.active = false; 
		anim = GetComponent<Animator> ();
	}

	void Update() {
		if (animStateR)
			anim.SetBool ("stateR", true);
		else
			anim.SetBool ("stateR", false);
		if (animate)
			anim.SetBool ("animate", true);
		else
			anim.SetBool ("animate", false);
	}

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
		animate = true;
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // Destroy the shot
             //   Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
		} else if(otherCollider.tag == "Stalactite") {
			Damage(0);
		}
    }
}