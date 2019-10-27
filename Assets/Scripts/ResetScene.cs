using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
	public float resetTime = 3.0f;
	
	public string whiteStr = "White player died! Level will reset.";
	public string blackStr = "Black player died! Level will reset.";

	public Text white;
	public Text black;

  void Update()
  {
		if (GameObject.Find("CharacterWhite") == null)
		{
			white.text = whiteStr;
			StartCoroutine(Reset(white));
		}
		
		if (GameObject.Find("CharacterBlack") == null)
		{
			black.text = blackStr;
			StartCoroutine(Reset(black));
		}
  }

	private void SceneReset()
	{
  }
	
	IEnumerator Reset(Text text)
  {
    yield return new WaitForSeconds(resetTime);
		Debug.Log("Scene reset");
		text.text = "";
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
  }
}
