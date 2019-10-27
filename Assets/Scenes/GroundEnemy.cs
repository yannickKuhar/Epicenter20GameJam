using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public float bossSpeed = 1f;
    private Vector2 direction = Vector2.left;
    private bool grounded;
    private Rigidbody2D rb;
    private int health = 10;


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
        if(health < 0)
        {
           Destroy(gameObject);
        }
    }

    private void checkJump()
    {
        grounded = Physics.Raycast(transform.position, Vector2.down, 0.005f);
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
        else if (collision.CompareTag("Sword"))
        {
            health -= 2;
        }
        else if (collision.CompareTag("Bullet"))
        {
            health -= 1;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(theobjectToIgnore.collider, GetComponent<Collider>());
        }
        if (collision.gameObject.tag == "enemy")
        {
            Physics.IgnoreCollision(theobjectToIgnore.collider, GetComponent<Collider>());
        }
    }
}
