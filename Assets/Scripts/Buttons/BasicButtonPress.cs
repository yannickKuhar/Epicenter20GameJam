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
    [SerializeField] private string objColor = default;
    public bool interactibleByBoth;
    public bool goesBackUp;
    
    [Header("Stats")]
    public bool pressed = false;
    public bool pressedByBox = false;
    public bool pressedByPlayer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" + objColor)
        {
            Debug.Log("Player is on the button, drop down.");

            pressedByPlayer = true;
            pressed = true;
            pressedByBox = false;

            ButtonGoesDown();

            buddyButton.gameObject.GetComponent<BasicButtonPress>().pressed = true;
        }
        if (collision.gameObject.tag == "Draggable" + objColor)
        {
            Debug.Log("Draggable Object is on top");

            pressedByBox = true;
            pressed = true;
            pressedByPlayer = false;


            ButtonGoesDown();
            buddyButton.gameObject.GetComponent<BasicButtonPress>().pressed = true;
        }
        else if (collision.gameObject.tag == "PlayerWhite" && interactibleByBoth || collision.gameObject.tag == "PlayerBlack" && interactibleByBoth)
        {
            Debug.Log("Player is on the button, drop down.");
            ButtonGoesDown();
            pressed = true;
            buddyButton.gameObject.GetComponent<BasicButtonPress>().pressed = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" + objColor)
        {
            Debug.Log("Player is on the button, drop down.");
            
            pressedByPlayer = true;
            pressed = true;
            pressedByBox = false;

            ButtonGoesDown();

            buddyButton.gameObject.GetComponent<BasicButtonPress>().pressed = true;
        }
        if (collision.gameObject.tag == "Draggable" + objColor)
        {


            pressedByBox = true;
            pressed = true;
            pressedByPlayer = false;


            ButtonGoesDown();
            buddyButton.gameObject.GetComponent<BasicButtonPress>().pressed = true;
        }
        else if (collision.gameObject.tag == "PlayerWhite" && interactibleByBoth || collision.gameObject.tag == "PlayerBlack" && interactibleByBoth)
        {
            ButtonGoesDown();
            pressed = true;
            buddyButton.gameObject.GetComponent<BasicButtonPress>().pressed = true;
        }
  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (goesBackUp)
        {
            if (collision.gameObject.tag == "PlayerWhite" || collision.gameObject.tag == "PlayerBlack")
            {
                if (pressedByBox)
                {
                    return;
                }
                
                if (!pressedByBox)
                {
                    ButtonGoesUp();

                    pressedByPlayer = false;
                    pressed = false;
                }

            }
            if (collision.gameObject.tag == "DraggableBlack" || collision.gameObject.tag == "DraggableWhite")
            {
                if (pressedByPlayer)
                {
                    return;
                }

                if (!pressedByPlayer)
                {
                    ButtonGoesUp();

                    pressedByPlayer = false;
                    pressed = false;
                }
            }
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
