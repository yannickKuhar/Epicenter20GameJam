using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragingObject : MonoBehaviour
{
    private bool isDragging = false;

    private GameObject player;
    private string pull;

    private void Dragging()
    {
        this.transform.SetParent(player.transform);
        player.GetComponent<PlayerController>().movementSpeed = 1.0f;
        player.GetComponent<PlayerController>().isDragging = true;
        isDragging = true;
    }

    private void StopDragging()
    {
        this.transform.SetParent(null);
        player.GetComponent<PlayerController>().movementSpeed = 2.0f;
        player.GetComponent<PlayerController>().isDragging = false;
        isDragging = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player = collision.collider.gameObject;
            pull = player.GetComponent<PlayerController>().PullControl;
        }

        if (Input.GetKey(pull) && collision.collider.gameObject == player && isDragging == false)
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;

            if (contactPoint.y <= center.y + (player.transform.lossyScale.x / 2) && contactPoint.y >= center.y - (player.transform.lossyScale.x / 2))            
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
