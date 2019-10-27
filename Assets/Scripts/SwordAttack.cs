using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
	public PlayerController player;
	public KeyCode attackKey;
	public GameObject sword;
	public GameObject swordPoint;

	public float distance = 1.0f;
	
  void Update()
  {	
		if (Input.GetKeyDown(attackKey))
		{
			Attack();
		}
  }

	private void Attack()
	{
		Vector3 goal;
		
		if (player.GetFacingRight())
		{
			Debug.Log("yes");
			goal = new Vector3(sword.transform.position.x + distance, sword.transform.position.y, sword.transform.position.z);
		}
		else
		{
			goal = new Vector3(sword.transform.position.x - distance, sword.transform.position.y, sword.transform.position.z);
		}

		sword.transform.position = goal;

		SoundManager.Instance.PlayOneShot (SoundManager.Instance.swipe);

		StartCoroutine(ResetSword());
	}

	IEnumerator ResetSword()
  {
    yield return new WaitForSeconds(0.05f);
    // print(Time.time);
		sword.transform.position = swordPoint.transform.position;
  }
}
