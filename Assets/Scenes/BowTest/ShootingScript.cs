using UnityEngine;
using System.Collections;

/// <summary>
/// Launch projectile
/// </summary>
public class ShootingScript : MonoBehaviour
{
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    /// <summary>
    /// Projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// Building strength of shot
    /// </summary>
    public int shotStrength;

    void Start()
    {
        shotStrength = 0;
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire"))
        {
            if (shotStrength < 100)
            {
                shotStrength += 1;
            }
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
    public void Attack()
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
}