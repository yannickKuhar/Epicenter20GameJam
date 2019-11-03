using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddySystem : MonoBehaviour
{

    [Header("Fetcher")]
    [SerializeField] private GroundEnemy buddy = default;

    public void DestroyBuddy()
    {
        //buddy.GetComponent<Animator>().SetBool("Dying", true);
        //Invoke("Destroy(buddy.gameObject)", 1);
        Destroy(buddy.gameObject);
    }

}
