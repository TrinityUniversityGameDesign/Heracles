using UnityEngine;
using System.Collections;

public class HeadScript : MonoBehaviour {
    public bool active;
    private bool attacking;
    private int charge;
    private int chargeMax;
    private Color baseColor;
    public SpriteRenderer sprite;
    public Vector3 dest;
    private Vector3 orig;
    public float speed;
    public Transform pos;
	private Vector3[] dests;
	private int waitTime;
	private int waitMax;
	public GameObject fire;
	public GameObject arcFire;
	// Use this for initialization
	void Start () {
        charge = 0;
        chargeMax = 60;
        baseColor = sprite.color;
        orig = pos.localPosition;
		genDests ();
		chooseDest ();
		waitTime = 0;
		waitMax = 20;
	}

    void FixedUpdate()
    {
        if (abs(Vector3.Distance(pos.localPosition, dest)) > 0.15f) //destination is more than .1ish away from position, then move towards
        {
			moveTowardsDest();
        }
		else if (attacking) { //if attacking and at destination, sit and charge and fire, then move away
            chargingColors();
            charge += 1;
            if(charge >= chargeMax) {
                attack();
                attacking = false;
				charge = 0;
                chooseDest();
            }
		} else if(waitTime > waitMax) { //if at destination and done waiting, go somewhere else
            chooseDest();
			waitTime = 0;
		} else { //wait a moment before moving
			waitTime++;
		}
        
    }

    void moveTowardsDest() //we have a destination, now head there
    {
		Vector3 towardDest = new Vector3(dest.x - pos.localPosition.x, dest.y - pos.localPosition.y, pos.localPosition.z);
        towardDest.Normalize();
        pos.Translate(towardDest * speed);
    }

    void chooseDest() //we're at the destination, need a new one
	{
		Vector3 newDest = dests [(int)Random.Range (0, 9)];
		while (newDest.Equals(dest)) {
			newDest = dests [(int)Random.Range (0, 9)];
		}
		dest = dests [(int)Random.Range (0, 9)];
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

	void genDests() { //generates dests based on current position
		dests = new Vector3[9];
		dests [0] = new Vector3 (orig.x - 0.2f, orig.y - 0.1f, orig.z);
		dests [1] = new Vector3 (orig.x - 0.2f, orig.y + 0.1f, orig.z);
		dests [2] = new Vector3 (orig.x - 0.1f, orig.y - 0.2f, orig.z);
		dests [3] = new Vector3 (orig.x - 0.1f, orig.y + 0.2f, orig.z);
		dests [4] = new Vector3 (orig.x + 0.1f, orig.y - 0.2f, orig.z);
		dests [5] = new Vector3 (orig.x + 0.1f, orig.y + 0.2f, orig.z);
		dests [6] = new Vector3 (orig.x + 0.2f, orig.y - 0.1f, orig.z);
		dests [7] = new Vector3 (orig.x + 0.2f, orig.y + 0.1f, orig.z);
		dests [8] = new Vector3 (orig.x, orig.y, orig.z);
	}


}
