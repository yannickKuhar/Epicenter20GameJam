using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteButton : MonoBehaviour
{
    public void ExecuteCommand()
    {
        if (this.name == "ButtonTop")
        {
            this.GetComponentInParent<BasicButtonPress>().activated = false;          
            while (this.GetComponent<Transform>().position.y < 0.1)
                this.GetComponent<Rigidbody2D>().mass = -1;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
