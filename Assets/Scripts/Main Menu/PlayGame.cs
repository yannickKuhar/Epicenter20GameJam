using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public static int levelCount = 1;
    
    public void PlayClick()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
    }    
}
