using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WinConditionEnter : MonoBehaviour
{
    [Header("Fethcer")]
    public WinLoader loader;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBlack")
        {
            Debug.Log("Player is off the button.");
            loader.gameObject.GetComponent<WinLoader>().blackCheck = true;
            Debug.Log("Black player checked");
        }
        if (collision.gameObject.tag == "PlayerWhite")
        {
            Debug.Log("Player is off the button.");
            loader.gameObject.GetComponent<WinLoader>().whiteCheck = true;
            Debug.Log("White player checked");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }


}
