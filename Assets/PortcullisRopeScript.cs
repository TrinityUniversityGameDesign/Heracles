using UnityEngine;
using System.Collections;

public class PortcullisRopeScript : MonoBehaviour {

    public GameObject rope;
    private RopeScript ropeS;
    private Transform pos;
    // Use this for initialization
    void Start()
    {
        pos = this.gameObject.GetComponent<Transform>();
        ropeS = rope.GetComponent<RopeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ropeS.severed)
        {
            pos.position = new Vector3(pos.position.x, pos.position.y - 0.1f, pos.position.z);
        }
    }
}
