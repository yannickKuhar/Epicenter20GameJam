using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoader : MonoBehaviour
{
    public bool blackCheck;
    public bool whiteCheck;

    public string nextLvl;


    public int currentLvl;

    public void Start()
    {
        blackCheck = false;
        whiteCheck = false;
    }
    void Update()
    {
        if (blackCheck && whiteCheck)
        {
            Debug.Log("Load next lvl");
            SceneManager.LoadScene(nextLvl);
        }
    }
}
