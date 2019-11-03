using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "EnemyWhite" || collision.gameObject.tag == "EnemyBlack")
		{
			Destroy(gameObject);
		}
	}
}
