using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class FlipperScript : MonoBehaviour
{


		/// <summary>
		/// Total hitpoints
		/// </summary>
		public int mode = 1;
		public int numModes = 2;

		/// <summary>
		/// Enemy or player?
		/// </summary>
		public bool isEnemy = true;
		public bool stalactiteTrigger = false;
		public GameObject disappear;


		//used to determine animation state - do not touch.

		public bool animate;
		private Animator anim;
		/// <summary>
		/// Inflicts damage and check if the object should be destroyed
		/// </summary>
		/// <param name="damageCount"></param>
		public void Damage (int damageCount)
		{
				animate = true;

		if (stalactiteTrigger) {
			disappear.renderer.enabled = false;
			disappear.collider2D.isTrigger = true;
		}

		
				if (mode == 1) {
						GameObject gateA = gameObject.transform.Find ("gateA").gameObject;
						gateA.active = false; 

						GameObject gateB = gameObject.transform.Find ("gateB").gameObject;
						gateB.active = true; 
						
				}

				if (mode == 2) {
						GameObject gateB = gameObject.transform.Find ("gateB").gameObject;
						gateB.active = false; 
			
						GameObject gateA = gameObject.transform.Find ("gateA").gameObject;
						gateA.active = true; 
				}

				mode += 1;

				if (mode > numModes)
						mode = 1;
		}

		void Start ()
		{
//		GameObject gateA = gameObject.transform.Find("gateA").gameObject;
		//		GameObject gateB = GameObject.Find ("gateB");
		//		gateB.active = false; 
		}

		void Awake ()
		{
				anim = GetComponent<Animator> ();
		}

		void Update ()
		{
				if (animate)
						anim.SetBool ("animateT", true);
				else if (!animate)
						anim.SetBool ("animateT", false);
		}

		void OnTriggerEnter2D (Collider2D otherCollider)
		{
				if (stalactiteTrigger) {
						if (otherCollider.tag == "Stalactite") {
								Damage (0);
						}
				} 
				if (!stalactiteTrigger) {
				
						// Is this a shot?
						ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
						if (shot != null) {
								// Avoid friendly fire
								if (shot.isEnemyShot != isEnemy) {
										Damage (shot.damage);

										// Destroy the shot
										//   Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
								}
						}
				}
		}
}