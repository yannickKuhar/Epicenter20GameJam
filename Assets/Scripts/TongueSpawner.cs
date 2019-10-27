using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueSpawner : MonoBehaviour
{
    public GameObject tongue;
    private bool tongue_active = true;

    private void Update()
    {
        Debug.Log("update");
        if (Mathf.FloorToInt(Random.Range(0.0f, 1000.0f)) < 10)  //makes player jump
        {
            if (!tongue_active)
            {
                Debug.Log("extend");
                tongue.SetActive(true);
                tongue_active = true;
            }
            else
            {
                tongue.SetActive(false);
                tongue_active = false;
            }
        }
    }
}
