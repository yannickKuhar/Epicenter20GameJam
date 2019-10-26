using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
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
		Vector3 start = new Vector3(sword.transform.position.x, sword.transform.position.y, sword.transform.position.z);
		Vector3 goal = new Vector3(sword.transform.position.x + distance, sword.transform.position.y, sword.transform.position.z);

		sword.transform.position = goal;

		StartCoroutine(Example(start));
	}

	IEnumerator Example(Vector3 start)
  {
    yield return new WaitForSeconds(0.05f);
    print(Time.time);
		sword.transform.position = swordPoint.transform.position;
  }
}
