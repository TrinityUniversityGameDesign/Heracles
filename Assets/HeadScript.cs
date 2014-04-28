using UnityEngine;
using System.Collections;

public class HeadScript : MonoBehaviour {
	public Transform pos;
    public bool active;
    public bool attacking;
    public int attackType;
    private int charge;
    private int chargeMax;
    private Color baseColor;
    public SpriteRenderer sprite;
	public GameObject fire;
	public GameObject arcFire;
    private bool charging;
	public int fireLife;
	public float fireSpeed;
	// Use this for initialization
	void Start () {
        charge = 0;
        chargeMax = 100;
        baseColor = sprite.color;
        charging = false;
		active = true;
	}

    void FixedUpdate()
    {
		if (attacking) {
            charging = true;
            chargingColors();
            charge += 1;
            if(charge >= chargeMax) {
				attack();
				sprite.color = baseColor;
                attacking = false;
                charging = false;
				charge = 0;
            }
		}
        
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
		GameObject newObj = Instantiate(fire) as GameObject;
		newObj.transform.position = new Vector3(pos.position.x, pos.position.y, pos.position.z);
		ArcFireball fireA = newObj.GetComponent<ArcFireball>();
		if (fireA != null) {
			fireA.Launch(fireSpeed);
		} else {
			CerberusFireball fireC = newObj.GetComponent<CerberusFireball>();
			fireC.speed = fireSpeed;
		}
    }

    float abs(float num)
    {
        if (num < 0)
        {
            return 0 - num;
        }
        return num;
    }


    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            if (charging) //only takes damage when charging
            {
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
                damage();
            }
        }
    }

    void damage() {
		attacking = false;
		charging = false;
        active = false;
		sprite.color = baseColor;
        this.gameObject.SetActive(false);
    }
}
