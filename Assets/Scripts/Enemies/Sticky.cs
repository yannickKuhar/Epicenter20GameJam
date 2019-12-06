using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetPlayer;
    public GameObject savedPlayer;
    private int health = 5;
   // private bool extended = true;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        if (collision.CompareTag("Bullet")) 
        {
            health = health - 1;
            targetPlayer.GetComponent<PlayerController>().unfreeze();
            savedPlayer.GetComponent<PlayerController>().unfreeze();
        }
        if (collision.CompareTag("PlayerWhite"))
        {
            collision.gameObject.GetComponent<PlayerController>().freeze();
            Debug.Log("playur collided");
            //targetPlayer.GetComponent<PlayerController>().freeze();

        }
        else if (collision.CompareTag("PlayerBlack"))
        {
            collision.gameObject.GetComponent<PlayerController>().freeze();
        }
    }
}
