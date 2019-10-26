using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    [SerializeField] private WinLoader loader;
    [SerializeField] private string playerColor = "Black";

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" + playerColor)
        {
            Debug.Log("player entered");
            loader.GetComponent<WinLoader>().blackCheck = true;
        }
    }

    
}
