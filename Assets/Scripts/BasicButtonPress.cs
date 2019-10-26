using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonPress : MonoBehaviour
{
    public bool activated = false;
    public bool playerOnTop = false;
    public GameObject Player;
    public GameObject execution;
    public Animator animator;

    void Update()
    {
        /*if (transform.position.y < -0.05)
        {
            animator.SetBool("ButtonDown", false);
        }             */
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (activated == false && col.name == Player.name)
        {
            /*this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            this.GetComponent<Rigidbody2D>().mass = 1;
            activated = true; */
            animator.SetTrigger("ButtonPressed");
           
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (activated == false && col.name == Player.name)
        {
            /*this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            this.GetComponent<Rigidbody2D>().mass = 1;
            activated = true; */
            animator.SetTrigger("ButtonUnpressed");

        }
    }
    /* private void OnCollisionExit2D(Collision2D collision)
     {
         if (collision.collider.tag == "Player" )
         {
             animator.SetBool("PlayerWentOff", true);
         }
     }    */
}
