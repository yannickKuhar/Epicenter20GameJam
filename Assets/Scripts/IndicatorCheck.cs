using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorCheck : MonoBehaviour
{
    private GameObject whitePlayer;
    private GameObject blackPlayer;

    // Start is called before the first frame update
    void Start()
    {
        whitePlayer = GameObject.FindGameObjectWithTag("PlayerWhite");
        blackPlayer = GameObject.FindGameObjectWithTag("PlayerBlack");

        if (!GameMode.singlePlayer)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        WhiteActiveCheck();
    }

    private void WhiteActiveCheck()
    {
        if (whitePlayer.GetComponent<PlayerController>().active)
        {
            transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
