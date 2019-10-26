using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BasicButtonPress : MonoBehaviour
{
    [Header("Fethcer")]
    public GameObject execution;
    public GameObject buttonUp;
    public GameObject buttonDown;
    public BasicButtonPress buddyButton;

    [Header("Interaction Settings")]
    [SerializeField] private string objColor;
    public bool interactibleByBoth;
    
    [Header("Stats")]
    public bool pressed = false;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Player" + objColor)
        {
            Debug.Log("Player is on the button, drop down.");
            ButtonGoesDown();
            pressed = true;
        }
        else if (collision.gameObject.tag == "PlayerWhite" && interactibleByBoth || collision.gameObject.tag == "PlayerBlack" && interactibleByBoth)
        {
            Debug.Log("Player is on the button, drop down.");
            ButtonGoesDown();
            pressed = true;
        }
        else
        {
            Debug.Log("Incorrect player on the platform");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerWhite" || collision.gameObject.tag == "PlayerBlack")
        {
            Debug.Log("Player is off the button.");
            ButtonGoesUp();
            pressed = false;
        }    
    }

    private void ButtonGoesDown()
    {
        buttonUp.SetActive(false);
        buddyButton.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        buttonDown.SetActive(true);
        buddyButton.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        //animator.SetTrigger("GoDown");
    }
    private void ButtonGoesUp()
    {
        buttonUp.SetActive(true);
        buddyButton.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        buttonDown.SetActive(false);
        buddyButton.gameObject.transform.GetChild(1).gameObject.SetActive(false);


    }
    private void Update()
    {
        if (pressed)
        {
            
        }
    }
}
