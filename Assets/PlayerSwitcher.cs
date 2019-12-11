using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    private GameObject whitePlayer;
    private GameObject blackPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if(!GameMode.singlePlayer)
        {
            Destroy(gameObject);
        }
        whitePlayer = GameObject.FindGameObjectWithTag("PlayerWhite");
        blackPlayer = GameObject.FindGameObjectWithTag("PlayerBlack");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) /*&& blackPlayer.GetComponent<PlayerController>().active == true*/)
        {
            Debug.Log("Going to white player");
            whitePlayer.GetComponent<PlayerController>().active = false;
            blackPlayer.GetComponent<PlayerController>().active = true;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) /*&& whitePlayer.GetComponent<PlayerController>().active == true*/)
        {
            Debug.Log("Going to white player");
            whitePlayer.GetComponent<PlayerController>().active = true;
            blackPlayer.GetComponent<PlayerController>().active = false;

        }
    }

}
