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

    }
}
