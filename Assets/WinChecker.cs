using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    [SerializeField] private WinLoader loader;
    [SerializeField] private string playerColor = "Black";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" + playerColor)
        {
            Debug.Log("Commence win trigger");

            if (playerColor == "Black")
            { 
                Debug.Log("player je crn, dodaj crni check");
                loader.GetComponent<WinLoader>().blackCheck = true;
            }
            if (playerColor == "White")
            {
                loader.GetComponent<WinLoader>().whiteCheck = true;
            }
        }
    }
}
