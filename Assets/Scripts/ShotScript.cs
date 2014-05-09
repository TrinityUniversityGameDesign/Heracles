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
  public AudioClip lionHurt;
  public bool soundEnabled = true;
  private Transform target;
  private float xOffset;
  private float yOffset;
  private bool doFollow = false;
  private bool set = false;
  bool hitOnce = false;
  GameObject player;
  bool arrowInXBounds;
  bool arrowInYBounds;
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
	player = GameObject.FindWithTag ("P1");
	float randomNum = Random.Range (1, 100);
	if (randomNum < 50) {
	  audio.PlayOneShot (arrowShoot1);
	} else {
	  audio.PlayOneShot (arrowShoot2);
	}
    // 2 - Limited time to live to avoid any leak
    Destroy(gameObject, 6); // 20sec
  }
  void OnTriggerEnter2D (Collider2D other) 
  {
	if (soundEnabled) {
		/*if (other.tag == "Lion") {
	  		audio.PlayOneShot (lionHurt);
		} else */ 
		arrowInXBounds = (((this.transform.position.x - player.transform.position.x) < 20) || ((this.transform.position.x - player.transform.position.x) > -20)); 
		arrowInYBounds = (((this.transform.position.y - player.transform.position.y) < 20) || ((this.transform.position.y - player.transform.position.y) > -20)); 
		if((this.rigidbody2D.velocity == new Vector2(0,0)) && !hitOnce && arrowInXBounds && arrowInYBounds) {
	  	  audio.PlayOneShot (arrowHit1);
		  hitOnce = true;
		}
	}
 }
}
