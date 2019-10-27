using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    private bool isFullscreen;

    public void ResolutionSet()
    {
        int resValue = resolutionDropdown.value;
        string[] resolution = resolutionDropdown.options[resValue].ToString().Split('x');
        Screen.SetResolution(Convert.ToInt32(resolution[0]), Convert.ToInt32(resolution[1]), isFullscreen);
    }

    public void Fullscreen()
    {
        if (isFullscreen == true)
        {
            Screen.fullScreen = false;
            isFullscreen = false;
        }

        if (isFullscreen == false)
        {
            Screen.fullScreen = true;
            isFullscreen = true;
        }
    }

    void Start()
    {
        UnityEngine.Resolution[] resolutionArray = Screen.resolutions;
        for (int i = 0; i < resolutionArray.Length; i++)
        {
            string[] resArr = resolutionArray[i].ToString().Split('@');
            resolutionDropdown.options.Add(new Dropdown.OptionData(resArr[0], null));            
        }

        string[] curResolution = Screen.currentResolution.ToString().Split('@');
        resolutionDropdown.GetComponentInChildren<Text>().text = curResolution[0];
        isFullscreen = Screen.fullScreen;
    }    
}
