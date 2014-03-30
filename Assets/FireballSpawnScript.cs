using UnityEngine;
using System.Collections;

public class FireballSpawnScript : MonoBehaviour {

    public GameObject fireBall;
    private bool active;
    public int fireRate;
    public int fireLife;
    public float fireSpeed;
    private int timer;
	// Use this for initialization
	void Start () {
        active = true;
	}
	
	// Update is called once per frame
	void FixedUpdate(){
        if (active)
        {
            if (timer >= fireRate)
            {

                GameObject newObj = Instantiate(fireBall) as GameObject;
                if (Random.Range(0f, 1f) < 0.5) // 50/50 chance
                { //comes from spawner's position
                    newObj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                }
                else
                { //comes down at your legs
                    newObj.transform.position = new Vector3(transform.position.x, transform.position.y - 1.25f, transform.position.z);
                }
                FireballScript fire = newObj.GetComponent<FireballScript>();
                fire.life = fireLife;
                fire.speed = fireSpeed;
                timer = 0;
            }
            timer++;
        }
	}

    void OnTriggerEnter2D(Collider2D playerCollision)
	{
        if (playerCollision.gameObject.tag == "P1") {
            active = false; //the box collider is positioned in front, and turns it off when passed through
        }
    }
}
