using UnityEngine;
using UnityEngine.UI;

public class SetTextToNull : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Text>().text = "";
    }
}
