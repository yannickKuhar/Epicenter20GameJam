using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetTextToNull : MonoBehaviour
{
    void U()
    {    
        this.GetComponent<Text>().text = "";
    }
}
