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
    private bool operable = false;
    public GameObject QuickMenu;

    public void SelectLevel()
    {
        SceneManager.LoadScene("Level" + thisLevel, LoadSceneMode.Additive);
        QuickMenu.GetComponent<Transform>().gameObject.SetActive(false);
    }

    private void Awake()
    {
        completedLvl = PlayGame.levelCount;
        thisLevel = this.GetComponentInChildren<Text>().text;

        if (Convert.ToInt32(this.GetComponentInChildren<Text>().text) > completedLvl)
        {
            this.GetComponent<Button>().interactable = false;
            this.GetComponentInChildren<Text>().text = "?";
        }
    }

    private void Update()
    {
        if (!operable)
        {
            if (Convert.ToInt32(this.GetComponentInChildren<Text>().text) >= completedLvl)
            {
                this.GetComponent<Button>().interactable = true;
                this.GetComponentInChildren<Text>().text = thisLevel;
                operable = true;
            }
        }
    }
}
