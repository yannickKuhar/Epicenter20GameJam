using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public static int levelCount = 1;
    public static int maxLevelCount;
    
    public GameObject QuickMenu;

    public void PlayClick()
    {
        levelCount = 1;
        SceneManager.LoadScene("Level1");
    }

    private void Update()
    {
        if (levelCount > maxLevelCount)
            maxLevelCount = levelCount;
    }
}
