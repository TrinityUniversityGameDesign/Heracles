using UnityEngine;
using System.Collections;

public class CerberusScript : MonoBehaviour {
    public GameObject[] heads;
    private HeadScript[] headScripts;
    public Transform pos;
    public int attackTime;
    private int timer;
    private int phase;
    private Vector3 lowDest;
    private Vector3 highDest;
	// Use this for initialization
	void Start () {
        timer = 0;
        phase = 1;
        headScripts = new HeadScript[3];
        for (int x = 0; x < 3; x++)
        {
            headScripts[x] = heads[x].GetComponent<HeadScript>();
        }
        lowDest = new Vector3(-46.5f, -59.5f, 0f);
        highDest = new Vector3(-46.5f, -58.5f, 0f);
	}

    void FixedUpdate()
    {
        timer++;
        checkLive();
        if (timer > attackTime)
        {
            timer = 0;
            bool done = false;
            int head = -1;
            //while (!done)
            //{
                head = (int)Random.Range(0, 3);
                if (headScripts[head].attacking == false)
                {
                    done = true;
                }
            //}
            int attack = (int) Random.Range(0, 2);
            int position = (int)Random.Range(0, 2);
            headScripts[head].attackType = attack;
            headScripts[head].attacking = true;
            if (position == 0)
            {
                headScripts[head].dest = heads[head].transform.InverseTransformPoint(lowDest);
            }
            else
            {
                headScripts[head].dest = heads[head].transform.InverseTransformPoint(highDest);
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

    void startAttack()
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
        if (position == 0)
        {
            headScripts[head].dest = lowDest;
        }
        else
        {
            headScripts[head].dest = highDest;
        }
    }

    void phase2()
    {

    }

    void phase3()
    {

    }

    void die()
    {

    }
}
