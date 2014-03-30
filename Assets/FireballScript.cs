using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour {
    public int life; //How long the fireball lasts
    public float speed; //How fast it goes
    private int counter; //How long the fireball has been alive
    public Transform pos; //The fireball's transform

    void start()
    {
        counter = 0;
    }

	void FixedUpdate () {
        if (counter > life) //If fireball's life is over, destroy it
        {
            Destroy(this.gameObject);
        }
        else
        {
            counter++;
            if (pos != null) //for some reason, Pos has to be public, rather than just getting the component. I don't know why.
            {
                pos.Translate(new Vector3(speed, 0, 0));
            }
        }
	}
}
