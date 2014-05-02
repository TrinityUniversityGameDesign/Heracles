using UnityEngine;
using System.Collections;

public class TransportTo : MonoBehaviour
{

		GameObject p;
		GameObject c;
		public float x, y, z;
		public bool oneUse;
		bool used = false;
		public bool triggeredByPlayer;

		void Start ()
		{
				p = GameObject.FindGameObjectWithTag ("P1");
				c = GameObject.FindGameObjectWithTag ("MainCamera");
		}

		// Update is called once per frame
		void Update ()
		{
		}

		void OnTriggerEnter2D (Collider2D other)
	{
				if (!used) {
						if (triggeredByPlayer) {
								if (other.tag == "P1") {
					shake();
										p.transform.position = new Vector3 (x, y, z);
										c.transform.position = new Vector3 (x, y, z - 63f);
										Camera.main.GetComponent<CameraFollow> ().SetTarget (p.transform);
										if (oneUse)
												used = true;
								}
						} else if (other.CompareTag ("Shot")) {
				shake ();
								p.transform.position = new Vector3 (x, y, z);
								c.transform.position = new Vector3 (x, y, z - 63f);
								Camera.main.GetComponent<CameraFollow> ().SetTarget (p.transform);
								if (oneUse)
										used = true;

						}
				}
		}

	void shake() {
		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");
		iTween.ShakePosition (cam, new Vector3 (3, 3, 0), 2f);

	}

}
