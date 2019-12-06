using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToBlack : MonoBehaviour
{
    private bool thisActive = true;
    [SerializeField] private PlayerController switchTarget;

    private void Awake()
    {
        if (GameMode.PlayerNum == 2)
        {
            thisActive = false;
        }
    }

    void Update()
    {
        //switch from white to blakc
        if (Input.GetKeyDown(KeyCode.X) && gameObject.GetComponent<PlayerController>().active == true)
        {
            //swapping to white   
            switchTarget.GetComponent<PlayerController>().active = true;
            gameObject.GetComponent<PlayerController>().active = false;

        }
    }
}
