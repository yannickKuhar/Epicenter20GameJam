using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }    
}

