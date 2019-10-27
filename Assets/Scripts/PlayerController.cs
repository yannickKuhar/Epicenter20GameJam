using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string horizontalInputName;
	public string verticalInputName;

	public float movementSpeed = 5.0f;

	private Rigidbody2D rb;

	private bool facingRight = true;

	private bool isJumping = false;
	private float jumpButtonPressTime = 0.0f;
	public float jumpSpeed = 5.0f;
	public float maxJumpTime = 0.2f;

    public bool isDragging = false;
    public KeyCode PullControl;

    public KeyCode jumpKey;

    private float rayCastLength = 0.005f;
	
	private float width;
	private float height;
    private bool frozen = false;


    //////////////////// Unity main functions. ////////////////////

   void Awake()
  {
		width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
		height = GetComponent<Collider2D>().bounds.extents.y + 0.2f;

	    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
		PlayerMovement();
		PlayerJump();
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

    void FlipPlayer()
    {
        if (!frozen)
        {
            if (isDragging == false)
            {
                // Flip the facing value
                facingRight = !facingRight;

                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
    }

    //////////////////// Player jump. ////////////////////

    private void PlayerJump()
	{
		float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

		// Debug.Log(vertInput);

		if (IsOnGround () && isJumping == false && isDragging == false)
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

    public void unfreeze()
    {
        if (frozen)
        {
            frozen = false;
            rb.constraints = (UnityEngine.RigidbodyConstraints2D)RigidbodyConstraints.None;
        }
    }

    public void freeze()
    {
        Debug.Log("frozen");
        frozen = true;
        //Debug.Log(rb.gravityScale);
        
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        //rb.isKinematic = true;
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    //////////////////// Getters. ////////////////////
    public bool GetFacingRight()
	{
		return facingRight;
	}

    /////////////////// Win conditions //////////////

}
