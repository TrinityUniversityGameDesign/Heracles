using UnityEngine;
using System.Collections;

public class FireballSpawnScript : MonoBehaviour {

    public GameObject fireBall;
    private bool active;
    public int fireRate;
    public int fireLife;
	public Vector2 origin;
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
                    newObj.transform.position = new Vector3(origin.x, origin.y, transform.position.z);
                }
                else
                { //comes down at your legs
                    newObj.transform.position = new Vector3(origin.x, origin.y - 1.25f, transform.position.z);
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
            this.gameObject.SetActive(false); //the box collider is positioned in front, and turns it off when passed through
        }
    }
}
