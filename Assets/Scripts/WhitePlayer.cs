using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePlayer : MonoBehaviour
{
	public string horizontalInputName;
	public string verticalInputName;

	public float movementSpeed = 5.0f;

	private Rigidbody2D rb;

	public GameObject bullet;
	public GameObject bulletSpawnPoint;
	
	public KeyCode fireButton;
	public float bulletSpeed;
	public int bulletCount = 5;

	private bool facingRight = true;

	private bool isJumping = false;
	private float jumpButtonPressTime = 0.0f;
	public float jumpSpeed = 5.0f;
	public float maxJumpTime = 0.2f;
	
	private float rayCastLength = 0.005f;
	
	private float width;
	private float height;
 
	//////////////////// Unity main functions. ////////////////////

  void Awake()
  {
		width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
		height = GetComponent<Collider2D>().bounds.extents.y + 0.2f;

		rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
		PlayerMovement();
		PlayerJump();

		if (bulletCount > 0)
		{
			BulletFire();
		}
  }
		
	//////////////////// Player move. ////////////////////

	private void PlayerMovement()
	{
		float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

		Vector2 vect = rb.velocity;
 
		rb.velocity = new Vector2 (horizInput * movementSpeed, vect.y);

		if (horizInput > 0 && !facingRight)
		{
			FlipPlayer();
		}
		else if (horizInput < 0 && facingRight)
		{
			FlipPlayer();
		}
	}
	
	void FlipPlayer(){
 
		// Flip the facing value
		facingRight = !facingRight;
 
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
 
	//////////////////// Player jump. ////////////////////
	
	private void PlayerJump()
	{
		float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

		// Debug.Log(vertInput);

		if (IsOnGround () && isJumping == false)
		{
			if (vertInput > 0f)
			{
				isJumping = true;
			}
		}

		if (jumpButtonPressTime > maxJumpTime)
		{
			vertInput = 0f;
		}
 
		if (isJumping && (jumpButtonPressTime <= maxJumpTime))
		{
			rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
		}
 
		if (vertInput >= 1f)
		{
			jumpButtonPressTime += Time.deltaTime;
		}
		else
		{
			isJumping = false;
			jumpButtonPressTime = 0f;
		}
	}

	public bool IsOnGround()
	{
		bool groundCheckDown = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y - height), -Vector2.up, rayCastLength);
 
		bool groundCheckRight = Physics2D.Raycast (new Vector2 (transform.position.x + (width - 0.2f), transform.position.y - height), -Vector2.up, rayCastLength);
 
		bool groundCheckLeft = Physics2D.Raycast (new Vector2 (transform.position.x - (width - 0.2f), transform.position.y - height), -Vector2.up, rayCastLength);
 
		if (groundCheckDown || groundCheckRight || groundCheckLeft)
		{
			return true;
		}
 
		return false; 
	}
	
	//////////////////// Bullet fire. ////////////////////

	private void BulletFire()
	{
		if (Input.GetKeyDown(fireButton))
		{	
			GameObject projectile = Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
			Rigidbody2D projRB = projectile.GetComponent<Rigidbody2D>();
			
			if (facingRight)
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
