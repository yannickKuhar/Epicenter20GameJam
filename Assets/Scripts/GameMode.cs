using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    private static int playerNum;

    public static int PlayerNum
    {
        get
        {
            return playerNum;
        }
        set
        {
            playerNum = value;
        }
    }
}
