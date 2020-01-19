using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene3Txt : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Text>().text = "This is a combat scene - Use CTRL & L-Shift to attack.";
    }
}
