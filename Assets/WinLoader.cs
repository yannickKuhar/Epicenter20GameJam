using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoader : MonoBehaviour
{
    [SerializeField] public bool blackCheck, whiteCheck;

    private void Start()
    {
        blackCheck = false;
        whiteCheck = false;
    }
    void Update()
    {
        if (blackCheck && whiteCheck)
        {
            Debug.Log("Load next lvl");
            //SceneManager.LoadScene(Level2)
        }
    }
}
