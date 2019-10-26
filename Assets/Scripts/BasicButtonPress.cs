using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonPress : MonoBehaviour
{
    public bool activated = false;
    public GameObject[] Player;
    public GameObject execution;

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (activated == false && collision.collider.name == Player[0].name)
        {
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            this.GetComponent<Rigidbody2D>().mass = 1;
            activated = true;
        }
        
        else if (activated == false && Player.Length == 2)
        {
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            this.GetComponent<Rigidbody2D>().mass = 1;
            activated = true;
        }

        if (collision.collider.name == "ButtonBottom")
        {
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            try
            {
                execution.GetComponent<ExecuteButton>().ExecuteCommand();
            }
            catch
            {
                execution.GetComponentInChildren<ExecuteButton>().ExecuteCommand();
            }
            finally
            {
                Debug.Log("Button Press Error.");
            }
        }
    }
}
