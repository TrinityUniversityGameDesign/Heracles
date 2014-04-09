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
		if (rigidbody2D.gravityScale == 0) {
			GetComponent<PointTowardsMovementScript>().enabled = false;
			rigidbody2D.velocity = new Vector3();
			Destroy(gameObject, 10);
		}
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

	if (other.tag == "Lion") {
	  audio.PlayOneShot (lionHurt);
	} else if(other.tag != "P1") {
	  audio.PlayOneShot (arrowHit1);
	}
  }
}