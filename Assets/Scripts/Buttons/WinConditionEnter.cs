using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class WinConditionEnter : MonoBehaviour
{
    [Header("Fethcer")]
    public WinLoader loader;
    [SerializeField] private Text colorInfo;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBlack")
        {
            Debug.Log("Player is off the button.");
            loader.gameObject.GetComponent<WinLoader>().blackCheck = true;
            colorInfo.text = "Black player on check point. Waiting for black.";
            Debug.Log("Black player checked");
        }
        if (collision.gameObject.tag == "PlayerWhite")
        {
            Debug.Log("Player is off the button.");
            loader.gameObject.GetComponent<WinLoader>().whiteCheck = true;
            colorInfo.text = "Black player on check point. Waiting for White.";
            Debug.Log("White player checked");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBlack")
        {
            Debug.Log("Player is off the button.");
            loader.gameObject.GetComponent<WinLoader>().blackCheck = false;
            colorInfo.text = "";
            Debug.Log("Black player unchecked");
        }
        if (collision.gameObject.tag == "PlayerWhite")
        {
            Debug.Log("Player is off the button.");
            loader.gameObject.GetComponent<WinLoader>().whiteCheck = false;
            colorInfo.text = "";
            Debug.Log("White player unchecked");
        }
    }


}
