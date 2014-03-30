using UnityEngine;
using System.Collections;

public class RopeScript : MonoBehaviour {

    public bool severed;
	// Use this for initialization
	void Start () {
        severed = false;
	}
	
	// Update is called once per frame
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            severed = true;
            this.gameObject.SetActive(false);
        }
    }
}
