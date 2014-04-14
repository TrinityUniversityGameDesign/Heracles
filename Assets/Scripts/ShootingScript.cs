using UnityEngine;
using System.Collections;

/// <summary>
/// Launch projectile
/// </summary>
public class ShootingScript : MonoBehaviour
{
	//bowPullSound
	public AudioClip bowPull;
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------
    public Vector2 direction;
    public GameObject shotPrefab;
    private BT_TragectoryScript traj;
    public int angle;
    //public Transform target; Original Script

    /// <summary>
    /// Building strength of shot
    /// </summary>
	public float shotStrength = 0;
	public float shotGrowth;
	public float minShotStrength;
	public float maxShotStrength = 40;
	public bool bowPullLoop = false;
	private PlayerControl player;

    void Start()
    {	
        traj = this.gameObject.GetComponent<BT_TragectoryScript>();
        traj.objShot = this.gameObject;
        traj.sightLine = this.GetComponent<LineRenderer>();
		player = GetComponent<PlayerControl>();
    }

    void FixedUpdate()
    {
		  if (Input.GetButton ("Fire") && player.IsGrounded()) {
			if (!bowPullLoop) {
					audio.clip = bowPull;
					audio.Play ();
					bowPullLoop = true;
			}
			if (shotStrength < maxShotStrength) {
					shotStrength += 1f;
			}
			direction = Input.mousePosition;
			Vector3 direction3 = Camera.main.ScreenToWorldPoint (new Vector3 (direction.x, direction.y, 0));
			if (direction3.x - transform.position.x > 0 && !player.IsFacingRight())
				player.flipDirection();
			else if (direction3.x - transform.position.x < 0 && player.IsFacingRight())
				player.flipDirection();
			direction = new Vector2 (direction3.x, direction3.y);
			direction.x -= this.gameObject.transform.position.x;
			direction.y -= this.gameObject.transform.position.y;
			direction.Normalize ();
			direction = direction * shotStrength / 35;
			float tempAngle = (Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg);
			traj.SetTragectory (tempAngle, shotStrength+5); //Addison - added 5 to second parameter so that the trajectory doesn't start drawing from the floor.
		} else if (shotStrength > minShotStrength && player.IsGrounded()) { 
	        Attack ();
		    shotStrength = 0;
		  }
		else shotStrength = 0;
    }

    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    /// <summary>
    /// Create a new projectile if possible
    /// </summary>
    /*public void Attack()
    {
        var mouseDir = Input.mousePosition;
        mouseDir.x -= Screen.width / 2;
        mouseDir.y -= Screen.height / 2;
        mouseDir.Normalize();
        mouseDir = mouseDir * shotStrength / 35;
        // Create a new shot
        var shotTransform = Instantiate(shotPrefab) as Transform;

        // Assign position
        shotTransform.position = transform.position;

        // Make the weapon shot always towards it
        InitialVelocityScript move = shotTransform.gameObject.GetComponent<InitialVelocityScript>();
        if (move != null)
        {
            move.direction = mouseDir; // towards in 2D space is the right of the sprite
        }
    }
    */
	public void Attack()
	{
		//if (CanGenerateNew)
		//{
		bool facingRight = GetComponent<PlayerControl>().IsFacingRight();
		audio.Stop ();
		bowPullLoop = false;
		GameObject newObj = Instantiate(shotPrefab) as GameObject;
		Vector3 arrowPos;
		if (facingRight)
			arrowPos = new Vector3(transform.position.x+0.7f,transform.position.y+0.52f,transform.position.z);
		else
			arrowPos = new Vector3(transform.position.x-0.7f,transform.position.y+0.52f,transform.position.z);
		newObj.transform.position = arrowPos;
		InitialVelocityScript move = newObj.GetComponent<InitialVelocityScript>();
		if (move != null)
		{
			move.direction = direction; // towards in 2D space is the right of the sprite
		}
		//}
	}

    /*float BallisticVel(Vector3 target, float newAngle)
    {
        Vector3 dir = target - transform.position;
        float h = dir.y;
        dir.y = 0;
        float dist = dir.magnitude;
        float a = angle * Mathf.Deg2Rad;
        dir.y = dist * Mathf.Tan(a);
        dist += h / Mathf.Tan(a);
        return Mathf.Sqrt(Mathf.Abs(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a)));
    }

    public bool CanGenerateNew
    {
        get
        {
            return genCooldown <= 0f;
        }
    }*/
}