using UnityEngine;
using System.Collections;

public class TransportTo : MonoBehaviour
{

		GameObject p;
		GameObject c;
		public float x, y, z;
		public float cameraX, cameraY, cameraZ;
		public bool oneUse;
		bool used = false;
		public bool triggeredByPlayer;
		public int triggeredOnNumTry;

		// Use this for initialization	
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
								if (other.CompareTag ("P1")) {
										if (triggeredOnNumTry == 0) {
												p.transform.position = new Vector3 (x, y, z);
												c.transform.position = new Vector3 (cameraX, cameraY, cameraZ);
												if (oneUse)
														used = true;
										} else {
												triggeredOnNumTry--;
										}
								}
						}
						if (other.CompareTag ("Shot")) {
								if (triggeredOnNumTry == 0) {
										p.transform.position = new Vector3 (x, y, z);
										c.transform.position = new Vector3 (cameraX, cameraY, cameraZ);
										if (oneUse)
												used = true;
								} else {
										triggeredOnNumTry--;
								}
						}
				}
		}
}
