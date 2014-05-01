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
		public float seconds;
		public GameObject deathFader;
		private GameObject deathfader;
		private bool fade = false;

		// Use this for initialization	
		void Start ()
		{
				if (seconds != null) {
						seconds = 1.4f;		
				}
				p = GameObject.FindGameObjectWithTag ("P1");
				c = GameObject.FindGameObjectWithTag ("MainCamera");
		}

		// Update is called once per frame
		void Update ()
		{
				if (fade) {
						Color tempColor = deathfader.GetComponent<MeshRenderer> ().material.color;
						tempColor.a += 0.015f;
						deathfader.GetComponent<MeshRenderer> ().material.color = tempColor;
				}
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (!used) {
						if (triggeredByPlayer) {
								if (other.tag == "P1") {
										/*
										StartCoroutine (wait (seconds));
										deathfader = Instantiate (deathFader, other.transform.position, Quaternion.identity) as GameObject;
										Color tempColor = deathfader.GetComponent<MeshRenderer> ().material.color;
										tempColor.a = 0.0f;
										deathfader.GetComponent<MeshRenderer> ().material.color = tempColor;
										fade = true;
										*/
										p.transform.position = new Vector3 (x, y, z);
										c.transform.position = new Vector3 (x, y, z - 63f);
										Camera.main.GetComponent<CameraFollow> ().SetTarget (p.transform);
										if (oneUse)
												used = true;
								}
						} else if (other.CompareTag ("Shot")) {
								/*
								StartCoroutine (wait (seconds));
								deathfader = Instantiate (deathFader, other.transform.position, Quaternion.identity) as GameObject;
								Color tempColor = deathfader.GetComponent<MeshRenderer> ().material.color;
								tempColor.a = 0.0f;
								*/
								deathfader.GetComponent<MeshRenderer> ().material.color = tempColor;
								fade = true;
								p.transform.position = new Vector3 (x, y, z);
								c.transform.position = new Vector3 (x, y, z - 63f);
								Camera.main.GetComponent<CameraFollow> ().SetTarget (p.transform);
								if (oneUse)
										used = true;

						}
				}
		}

		IEnumerator wait (float seconds)
		{
				yield return new WaitForSeconds (seconds); 
				Color tempColor = deathfader.GetComponent<MeshRenderer> ().material.color;
				tempColor.a = 0.0f;
				deathfader.GetComponent<MeshRenderer> ().material.color = tempColor;
				fade = false;

		}
}
