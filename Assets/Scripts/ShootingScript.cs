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
	public int maxShotStrength = 40;

    void Start()
    {	
        traj = this.gameObject.GetComponent<BT_TragectoryScript>();
        traj.objShot = this.gameObject;
        traj.sightLine = this.GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
		if (Input.GetButton("Fire"))
        {
			/*bool bowPullLoop = true;
			if(bowPullLoop) {
				audio.clip = bowPull;
				audio.Play ();
				bowPullLoop = false;
			}
			*/
            if (shotStrength < maxShotStrength)
            {
                shotStrength += 2.0f;
            }
            direction = Input.mousePosition;
            Vector3 direction3 = Camera.main.ScreenToWorldPoint(new Vector3 (direction.x, direction.y, 0));
            direction = new Vector2(direction3.x, direction3.y);
            direction.x -= this.gameObject.transform.position.x;
            direction.y -= this.gameObject.transform.position.y;
            direction.Normalize();
            direction = direction * shotStrength / 35;
            float tempAngle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            traj.SetTragectory(tempAngle, shotStrength);
        }
        else if (shotStrength > 0)
        {
            Attack();
            shotStrength = 0;
        }
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
			//audio.Stop ();
            GameObject newObj = Instantiate(shotPrefab) as GameObject;
            newObj.transform.position = transform.position;
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