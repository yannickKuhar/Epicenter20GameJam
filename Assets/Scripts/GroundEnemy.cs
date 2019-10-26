using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public float bossSpeed = 1f;
    private Vector2 direction = Vector2.left;
    private bool grounded;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move();
        if (Mathf.FloorToInt(Random.Range(0.0f, 10000.0f)) < 10)  //makes player jump
        {
            Debug.Log(Mathf.FloorToInt(Random.Range(0.0f, 100.0f)));
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
        checkJump();
    }

    private void checkJump()
    {
        grounded = Physics.Raycast(transform.position, Vector2.down, 0.1f);
    }

    private void move()
    { 
        transform.Translate(direction * bossSpeed * Time.deltaTime);
    }

    //private void jump()
    //{
    //    Debug.Log("jumping");
    //    if (isJumping)
    //    {
    //        rb.AddForce(Vector2.up, ForceMode2D.Impulse);
    //        isJumping = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        if (collision.CompareTag("Wall"))
        {
            if (direction.Equals(Vector2.left))
            {
                direction = Vector2.right;
            }
            else if (direction.Equals(Vector2.right))
            {
                direction = Vector2.left;
            }
        }
    }

 

}
