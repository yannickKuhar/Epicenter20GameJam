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

	public bool isJumping = false;
	private float jumpButtonPressTime = 0.0f;
	public float jumpSpeed = 5.0f;
	public float maxJumpTime = 0.2f;

    public bool isDragging = false;
    
    
    public KeyCode PullControl;
	public KeyCode jumpKey;
		
	private float rayCastLength = 0.005f;
	
	private float width;
	private float height;
    private float horizInput;


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
    private void FixedUpdate()
    {
        PerformMove(horizInput);
        PerformJump();
    }

    //////////////////// Player move. ////////////////////

    private void PlayerMovement()
    {
        horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;


        if (horizInput > 0 && !facingRight)
        {
            FlipPlayer();
        }
        else if (horizInput < 0 && facingRight)
        {
            FlipPlayer();
        }
    }

    private void PerformMove(float horizInput)
    {
        Vector2 vect = rb.velocity;

        rb.velocity = new Vector2(horizInput * movementSpeed, vect.y);
    }

    void FlipPlayer()
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
 
	//////////////////// Player jump. ////////////////////

	private void PlayerJump()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        if (IsOnGround() && isJumping == false && isDragging == false)
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

    private void PerformJump()
    {
        if (isJumping && (jumpButtonPressTime <= maxJumpTime))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
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

	//////////////////// Getters. ////////////////////
	public bool GetFacingRight()
	{
		return facingRight;
	}

    /////////////////// Win conditions //////////////

}
