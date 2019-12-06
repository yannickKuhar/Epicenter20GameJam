using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Control Variables")]
    [SerializeField] private string horizontalInputName = default;
    [SerializeField] private string verticalInputName = default;
    [SerializeField] private bool singelPlayer = true;
    public KeyCode PullControl;
    private string verticalInput;
    public bool active = true;

    [Header("Movement Variables")]
	public float movementSpeed = 5.0f;
    private float horizInput = default;
    private Rigidbody2D rb;
	private bool facingRight = true;
    public bool isDragging = false;


    [Header("Jumping Variables")]
    public KeyCode jumpKey;
    [SerializeField] private float jumpForce = 2;
    [SerializeField] private bool isGrounded;
    private bool isJumping = false;
    [SerializeField] private float jumpButtonPressTimerRemember = 0.2f;
    [SerializeField] private float jumpButtonPressTimer = 0f;
    [SerializeField] private float jumpCut = 0.5f;

    [Header("SP Stuff")]
    [SerializeField] private string setControllerHor = "HorizontalAD";
    [SerializeField] private string setControllerVer = "VerticalWS";

    private float rayCastLength = 0.005f;	
	private float width;
	private float height;
    private bool frozen = false;
                                                

    //////////////////// Unity main functions. ////////////////////

    void Awake()
  {
        if (GameMode.PlayerNum == 2)
        {
            singelPlayer = false;
        }

        if (singelPlayer && gameObject.tag == "PlayerWhite")
        {
            active = false;
        }
  
  
        //not exactly sure zakaj rabita drugačne boundarije ampak it works so ¯\_(ツ)_/¯
        if (gameObject.tag == "PlayerWhite")
        {
            width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
            height = GetComponent<Collider2D>().bounds.extents.y + 0.2f;
        }
        if (gameObject.tag == "PlayerBlack")
        {
            width = GetComponent<Collider2D>().bounds.extents.x;
            height = GetComponent<Collider2D>().bounds.extents.y;                                                                   
        }
	    rb = GetComponent<Rigidbody2D>();
  }

    void Update()
    {
        ActivityCheck();

        isGrounded = IsOnGround();
        PlayerMovement();
        PlayerJump();
    }
    void FixedUpdate()
    {
        Vector2 vect = rb.velocity;
        rb.velocity = new Vector2(horizInput * movementSpeed, vect.y);
    }

    private void ActivityCheck()
    { 
        if (singelPlayer)
        {
            if(active)
            {
                horizontalInputName = setControllerHor;
                jumpKey = KeyCode.W;
                PullControl = KeyCode.F;
            }
            if (!active)
            {
                horizontalInputName = "";
                jumpKey = default;
                PullControl = default;
            }
        }
    }

    private void PlayerMovement()
	{
        if (active)
        {
            horizInput = Input.GetAxisRaw(horizontalInputName) * movementSpeed;

            if (horizInput > 0 && !facingRight)
            {
                FlipPlayer();
            }
            else if (horizInput < 0 && facingRight)
            {
                FlipPlayer();
            }
        }
	}
    private void FlipPlayer()
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
    private void PlayerJump()
	{
        
        jumpButtonPressTimer -= Time.deltaTime;
        if (Input.GetKeyDown(jumpKey) && !isDragging)
        {
            jumpButtonPressTimer = jumpButtonPressTimerRemember;
        }

        if ((jumpButtonPressTimer > 0f) && isGrounded)
        {
            jumpButtonPressTimer = 0f;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //faster falloff
        if (Input.GetKeyUp(jumpKey))
        {
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCut);
            }
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
    public bool GetFacingRight()
	{
		return facingRight;
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


}
