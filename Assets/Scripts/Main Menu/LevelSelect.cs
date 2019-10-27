using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    private int completedLvl;
    private string thisLevel;

    public void SelectLevel()
    {
        SceneManager.LoadScene("Level" + thisLevel);
        WinLoader.currentLvl = Convert.ToInt32(this.GetComponentInChildren<Text>().text);
    }

    public void CheckIfReady()
    {
        if (Convert.ToInt32(this.GetComponentInChildren<Text>().text) > completedLvl)
        {
            this.GetComponent<Button>().interactable = false;
            this.GetComponentInChildren<Text>().text = "?";
        }
    }

    private void Awake()
    {
        completedLvl = PlayGame.maxLevelCount;
        thisLevel = this.GetComponentInChildren<Text>().text;
        CheckIfReady();
    }
}
