using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameObject parent;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        parent = gameObject;
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "EnemyWhite" || collision.gameObject.tag == "EnemyBlack")
		{    
            anim.SetTrigger("Death");
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
	}

    private void Update()
    {
        if (transform.localScale.y < 0.1)
        {
            Destroy(gameObject);
        }
    }
}
