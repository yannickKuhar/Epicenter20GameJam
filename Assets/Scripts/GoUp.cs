using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    [Header("Fetcher")]
    [SerializeField] private BasicButtonPress triggerButton;
    [SerializeField] private Animator animator;
    
    [Header("Status")]
    [SerializeField] private bool up;
    void Start()
    {
        up = false;
    }

    void Update()
    {
        if (triggerButton.GetComponent<BasicButtonPress>().pressed == true  && !up)
        {
            Debug.Log("We're in boys");
            up = true;
            animator.SetTrigger("BoxGoUp");
        }
    }
}
