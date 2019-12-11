using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public static bool singlePlayer = true;

    public void ChangeMode()
    {
        if (singlePlayer)
        {
            singlePlayer = false;
            Debug.Log("Switching to MP mode");
            Debug.Log(singlePlayer);
        }
        else
        {
            singlePlayer = true;
            Debug.Log("not sp, switching to sp");
            Debug.Log(singlePlayer);
        }

    }
}
