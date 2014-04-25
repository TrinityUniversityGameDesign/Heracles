using UnityEngine;
using System.Collections;

/// <summary>
/// Projectile behavior
/// </summary>
public class ShotScript : MonoBehaviour
{
  public AudioClip arrowShoot1;
  public AudioClip arrowShoot2;
  public AudioClip arrowHit1;
  public AudioClip arrowHit2;
  public AudioClip arrowHit3;
  public AudioClip lionHurt;
	public bool soundEnabled = true;
	private Transform target;
	private float xOffset;
	private float yOffset;
	private bool doFollow = false;
	private bool set = false;
  // 1 - Designer variables

  /// <summary>
  /// Damage inflicted
  /// </summary>
  public int damage = 1;

  /// <summary>
  /// Projectile damage player or enemies?
  /// </summary>
  public bool isEnemyShot = false;

	void Update() {
		if (rigidbody2D.gravityScale == 0 && !set) {
			set = true;
			soundEnabled = false;
			GetComponent<PointTowardsMovementScript>().enabled = false;
			rigidbody2D.velocity = new Vector3();
			Destroy(gameObject, 10);
		}
		if (doFollow) {
			transform.position = new Vector3(target.position.x+xOffset,target.position.y+yOffset,transform.position.z);
		}
	}

	public void TrackObject(Transform followThis) {
		doFollow = true;
		target = followThis;
		xOffset = transform.position.x-target.position.x;
		yOffset = transform.position.y-target.position.y;
	}

  void Start()
  {
	float randomNum = Random.Range (1, 100);
	if (randomNum < 50) {
	  audio.PlayOneShot (arrowShoot1);
	} else {
	  audio.PlayOneShot (arrowShoot2);
	}
    // 2 - Limited time to live to avoid any leak
    Destroy(gameObject, 20); // 20sec
  }
  void OnTriggerEnter2D (Collider2D other) 
  {
	if (soundEnabled) {
		if (other.tag == "Lion") {
	  		audio.PlayOneShot (lionHurt);
		} else if(other.tag != "P1" && other.tag != "DeathArea") {
	  		audio.PlayOneShot (arrowHit1);
		}
	}
 }
}
