using UnityEngine;
using System.Collections;

public class HeadScript : MonoBehaviour {
    public bool active;
    private bool attacking;
    private int charge;
    private int chargeMax;
    private Color baseColor;
    public SpriteRenderer sprite;
    private Vector3 dest;
    private Vector3 orig;
    public float speed;
    public Transform pos;
	// Use this for initialization
	void Start () {
        charge = 0;
        chargeMax = 60;
        baseColor = sprite.color;
        orig = pos.position;
	}

    void FixedUpdate()
    {
        if (abs(Vector3.Distance(pos.position, dest)) < 0.1f) //destination is more than .1ish away from position, then move towards
        {
            moveTowardsDest();
        }
        else if (attacking) { //if attacking and at destination, sit and charge and fire, then move away
            chargingColors();
            charge += 1;
            if(charge >= chargeMax) {
                attack();
                attacking = false;
                chooseDest();
            }
        } else { //if at destination and not attacking, go somewhere else
            chooseDest();
        }
        
    }

    void moveTowardsDest() //we have a destination, now head there
    {
        Vector3 towardDest = new Vector3(dest.x - pos.position.x, dest.y - pos.position.y, 0);
        towardDest.Normalize();
        pos.Translate(towardDest * speed);
    }

    void chooseDest() //we're at the destination, need a new one
    {

    }

    void chargingColors() //change colors when charging
    {
        if (sprite.color == baseColor)
        {
            sprite.color = Color.red;
        }
        else
        {
            sprite.color = baseColor;
        }
    }

    void attack() //use the next attack
    {

    }

    float abs(float num)
    {
        if (num < 0)
        {
            return 0 - num;
        }
        return num;
    }


}
