using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragingObject : MonoBehaviour
{
    private bool isDragging = false;

    public PlayerController targetPlayer;
    private KeyCode pull;
    private float orgSpeed;

    [SerializeField] private Text colorInfo = default;

    private void Awake()
    {
        if (!targetPlayer.GetComponent<PlayerController>().singelPlayer)
        {
            pull = targetPlayer.GetComponent<PlayerController>().PullControl;
        }
        else
        {
            pull = KeyCode.F;
        }
        colorInfo.text = "";
        colorInfo.CrossFadeAlpha(0.0f, 0.05f, false);

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
            if (targetPlayer.tag == "PlayerWhite" && !targetPlayer.GetComponent<PlayerController>().singelPlayer)
            {
                colorInfo.text = "Hold L to drag.";
            }
            if (targetPlayer.tag == "PlayerBlack" || targetPlayer.tag == "PlayerWhite" && targetPlayer.GetComponent<PlayerController>().singelPlayer)
            {
                colorInfo.text = "Hold F to drag.";
            }
            colorInfo.CrossFadeAlpha(1.0f, 0.1f, false);

        }

        if (Input.GetKey(pull) && collision.collider.tag == targetPlayer.tag  && isDragging == false)
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;
            Dragging();            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colorInfo.CrossFadeAlpha(0.0f, 0.2f, false);
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
