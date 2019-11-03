using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    [Header("Fetcher")]
    [SerializeField] private BasicButtonPress triggerButton = default;
    [SerializeField] private Animator animator = default;
    
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
            up = true;
            animator.ResetTrigger("BoxGoDown");
            animator.SetTrigger("BoxGoUp");
            
        }

        if (up & !triggerButton.GetComponent<BasicButtonPress>().pressed)
        {
            up = false;
            animator.ResetTrigger("BoxGoUp");
            animator.SetTrigger("BoxGoDown");
        }
    }
}
