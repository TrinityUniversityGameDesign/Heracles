using UnityEngine;
using System.Collections;

public class CerberusScript : MonoBehaviour {
    public GameObject[] heads;
    private HeadScript[] headScripts;
    public Transform pos;
    public int attackTime;
    private int timer;
    private int phase;
	private bool up;
	private bool charging;
	private bool attacking;
	private int charge;
	public int jumpChargeMax;
    public Vector3 lowDest;
    public Vector3 highDest;
	private Color baseColor;
	public SpriteRenderer sprite;
	public GameObject spawner;
	private SpawnStalactite spawnScript;
	public GameObject shockwave;
	// Use this for initialization
	void Start () {
        timer = 0;
        phase = 1;
		attacking = false;
		up = false;
		charging = false;
		charge = 0;
        headScripts = new HeadScript[3];
		baseColor = sprite.color;
		spawnScript = spawner.GetComponent<SpawnStalactite> ();
        for (int x = 0; x < 3; x++)
        {
            headScripts[x] = heads[x].GetComponent<HeadScript>();
        }
	}

    void FixedUpdate()
    {
		if (charging) {
			charge += 1;
			chargingColors ();
			if(charge > jumpChargeMax) {
				attacking = true;
				charging = false;
				up = true;
				charge = 0;
				sprite.color = baseColor;
			}
		}
		if (attacking) {
			if(up) {
				if(pos.position.y > -53) {
					up = false;
				}
				pos.position = new Vector3(pos.position.x,pos.position.y+0.1f,0);
			} else {
				if(pos.position.y < -56.6) {
					attacking = false;
					up = false;
					pos.position = new Vector3(pos.position.x,-56.72793f,0);
					spawnScript.BeginFalling();
					spawnShockwave();
				}
				pos.position = new Vector3(pos.position.x,pos.position.y-0.1f,0);
			}

		} else {
			timer++;
			checkLive ();
			if (timer > attackTime && noCurrentAttacks ()) {
				timer = 0;
				//bool done = false;
				int head = -1;
				head = (int)Random.Range (0, 4);
				if (head == 3) { //not one of the heads
					charging = true;
				} else {
					while(!headScripts[head].active) {
						head = (int)Random.Range(0,3);
					}
					headScripts[head].attacking = true;
				}
			}
		}
    }

    void checkLive()
    {
        bool alive = false;
        for (int x = 0; x < 3; x++)
        {
            if (headScripts[x].active == true)
            {
                alive = true;
            }
        }
        if (!alive)
        {
            switch(phase) {
                case 1 : phase2(); break;
                case 2 : phase3(); break;
                case 3 : die(); break;
                default: print("ERROR ERROR INCORRECT PHASE"); break;
            }
        }
    }

	void spawnShockwave() {
		GameObject newObj = Instantiate(shockwave) as GameObject;
		newObj.transform.position = new Vector3 (-47f, -58.7f, 0f);
	}

    /*void startAttack()
    {
        bool done = false;
        int head = -1;
        while (!done)
        {
            head = (int)Random.Range(0, 3);
            if (headScripts[head].attacking == false)
            {
                done = true;
            }
        }
        int attack = (int)Random.Range(0, 2);
        int position = (int)Random.Range(0, 2);
        headScripts[head].attackType = attack;
        headScripts[head].attacking = true;
    }*/

	bool noCurrentAttacks() {
		for (int x = 0; x < 3; x++) {
			if(headScripts[x].attacking == true) {
				return false;
			}
		}
		if (attacking || charging) {
			return false;
		}
		return true;
	}

    void phase2()
    {
		transform.localScale = new Vector3 (0.75f * transform.localScale.x, 0.75f * transform.localScale.y, 0);
		phase = 2;
		for (int x = 0; x < 3; x++) {
			heads[x].SetActive(true);
			headScripts[x].active = true;
		}
    }

    void phase3()
    {
		transform.localScale = new Vector3 (0.75f * transform.localScale.x, 0.75f * transform.localScale.y, 0);
		phase = 3;
		for (int x = 0; x < 3; x++) {
			heads[x].SetActive(true);
			headScripts[x].active = true;
		}
    }

	public void returnToStart() {
		transform.localScale = new Vector3 (6.5f, 6.5f, 0);
		phase = 1;
		for (int x = 0; x < 3; x++) {
			heads[x].SetActive(true);
			headScripts[x].active = true;
		}
	}

    void die()
    {
		Destroy (this.gameObject);
    }

	void chargingColors() //change colors when charging
	{
		if (sprite.color == baseColor)
		{
			sprite.color = Color.yellow;
		}
		else
		{
			sprite.color = baseColor;
		}
	}
}
