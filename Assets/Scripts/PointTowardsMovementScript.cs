using UnityEngine;
using System.Collections;

public class PointTowardsMovementScript : MonoBehaviour {

    private Rigidbody2D body;
    private Transform rot;
    private Quaternion defaultRot;
	// Use this for initialization
	void Start () {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        rot = this.gameObject.GetComponent<Transform>();
        defaultRot = rot.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 direction = body.velocity.normalized;
        rot.rotation = defaultRot;
        Vector3 rotateAngle = new Vector3(0, 0, Vector2.Angle(Vector2.right, direction));
        if (direction.y < 0)
        {
            rot.Rotate(-rotateAngle);
        }
        else
        {
            rot.Rotate(rotateAngle);
        }
	}
}
