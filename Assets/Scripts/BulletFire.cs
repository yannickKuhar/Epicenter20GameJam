using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
  public PlayerController player;
	public GameObject bullet;
	public GameObject bulletSpawnPoint;

	public KeyCode fireButton;
	public float bulletSpeed = 10.0f;
	public int bulletCount = 5;

	void FixedUpdate()
	{
		if (bulletCount > 0)
		{
			FireBullet();
		}
	}

	//////////////////// Bullet fire. ////////////////////

	private void FireBullet()
	{
		if (Input.GetKeyDown(fireButton))
		{	
			GameObject projectile = Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
			Rigidbody2D projRB = projectile.GetComponent<Rigidbody2D>();
			
			if (player.GetFacingRight())
			{
				projRB.velocity = Vector2.right * bulletSpeed;
			}
			else
			{
				projRB.velocity = Vector2.left * bulletSpeed;
			}

			bulletCount--;
		}
	}
}
