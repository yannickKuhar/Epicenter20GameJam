using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragingObject : MonoBehaviour
{
    private bool isDragging = false;

    public GameObject targetPlayer;
    private KeyCode pull;
    private float orgSpeed;


    private float myDig;
    private float playerDig;

    private void Awake()
    {
        pull = targetPlayer.GetComponent<PlayerController>().PullControl;
        myDig = transform.lossyScale.x * transform.lossyScale.y;
        Debug.Log(myDig);
        playerDig = targetPlayer.transform.lossyScale.x * targetPlayer.transform.lossyScale.y;
        Debug.Log(playerDig);

    }

    private void Dragging()

    {
        this.transform.SetParent(targetPlayer.transform);
        orgSpeed = targetPlayer.GetComponent<PlayerController>().movementSpeed;
        targetPlayer.GetComponent<PlayerController>().movementSpeed = 1.0f;
        targetPlayer.GetComponent<PlayerController>().isDragging = true;
        isDragging = true;
    }

    private void StopDragging()
    {
        this.transform.SetParent(null);
        targetPlayer.GetComponent<PlayerController>().movementSpeed = orgSpeed;
        targetPlayer.GetComponent<PlayerController>().isDragging = false;
        isDragging = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(targetPlayer.tag))
        {
            Debug.Log("Correct player dragging box");
            targetPlayer = collision.collider.gameObject;
            //
        }                    

        if (Input.GetKey(pull) && collision.collider.name == targetPlayer.name  && isDragging == false)
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;
            Debug.Log("Ali imama prav?");
            if (myDig < playerDig)
                Dragging();            
        }
    }

    private void Update()
    {

        if (isDragging == true)
        {
            if (!Input.GetKey(pull))
            {
                StopDragging();
            }
        }                  
    }
}
