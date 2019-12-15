using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBox : MonoBehaviour
{
    [SerializeField] private GameObject button = default;
    [SerializeField] private bool activeByAnim = default;
    private bool active;
    [SerializeField] private float animSpeed = 1f;
    private Animator anim;
    [SerializeField] private bool reverse = false;
    [SerializeField] private bool shortAnim = false;
    [SerializeField] private bool diag = false;



    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {    
        
        if (activeByAnim)
        {
            if (button.GetComponent<BasicButtonPress>().pressed == true)
            {
                anim.speed = animSpeed;
            }
            else
            {
                anim.speed = 0;
            }
        }
        else
        {
            anim.speed = animSpeed;
        }
        
        if(reverse)
        {
            anim.SetBool("Reverse", true);
        }
        if(shortAnim)
        {
            anim.SetBool("Short", true);
        }
        if(diag)
        {
            anim.SetBool("Diag", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = transform;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
