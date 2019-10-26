using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragingObject : MonoBehaviour
{
    private GameObject player;

    private string WPPull = "f";
    private string BPPull = "m";

    private bool isDragging = false;
    
    private void Dragging()
    {
        this.transform.SetParent(player.transform);
        player.GetComponent<WhitePlayer>().movementSpeed = 1.0f;
        //collision.collider.gameObject.GetComponent<WhitePlayer>().isjumping = true;
        isDragging = true;
    }

    private void StopDragging()
    {
        this.transform.SetParent(null);
        player.GetComponent<WhitePlayer>().movementSpeed = 2.0f;
        isDragging = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        player = collision.collider.gameObject;

        if (Input.GetKey(WPPull) && player.name == "WhitePlayer" && isDragging == false)
            Dragging();
        
        if (Input.GetKey(BPPull) && player.name == "BlackPlayer" && isDragging == false)
            Dragging();

        if (player.CompareTag("Wall")) { }
    }

    private void Update()
    {
        if (isDragging == true )
        {
            if (!Input.GetKey(WPPull) && player.name == "WhitePlayer")
                StopDragging();

            if (!Input.GetKey(BPPull) && player.name == "BlackPlayer")
                StopDragging();
        }
    }
}
