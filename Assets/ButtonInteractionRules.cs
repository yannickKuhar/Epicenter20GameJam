﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractionRules : MonoBehaviour
{
    [Header("Fetcher")]
    public BasicButtonPress TopButton;
    public BasicButtonPress BottomButton;

    [Header("Interaction Rules")]
    [SerializeField] private bool bothCanInteract;

    [Header("Interaction Rules")]
    [SerializeField] private bool bothPressed;

    // Update is called once per frame
    void Start()
    {
        if (bothCanInteract)
        {
            TopButton.GetComponent<BasicButtonPress>().interactibleByBoth = true;
            TopButton.GetComponent<BasicButtonPress>().interactibleByBoth = true;
        }
        else
        {
            TopButton.GetComponent<BasicButtonPress>().interactibleByBoth = false;
            TopButton.GetComponent<BasicButtonPress>().interactibleByBoth = false;
        }
    }
    void Update()
    {
        //ce sta oba gumba pressed
        if (TopButton.GetComponent<BasicButtonPress>().pressed && BottomButton.GetComponent<BasicButtonPress>().pressed)
        {
            bothPressed = true;
        }
        if (!TopButton.GetComponent<BasicButtonPress>().pressed && !BottomButton.GetComponent<BasicButtonPress>().pressed)
        {
            bothPressed = false;
        }
        else
        {
            Debug.Log("This aint it chief");
        }
    }
}
