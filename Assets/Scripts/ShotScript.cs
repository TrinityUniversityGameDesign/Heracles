using UnityEngine;
using System.Collections;

/// <summary>
/// Projectile behavior
/// </summary>
public class ShotScript : MonoBehaviour
{
  public AudioClip arrowShoot1;
  public AudioClip arrowShoot2;
  // 1 - Designer variables

  /// <summary>
  /// Damage inflicted
  /// </summary>
  public int damage = 1;

  /// <summary>
  /// Projectile damage player or enemies?
  /// </summary>
  public bool isEnemyShot = false;

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
}