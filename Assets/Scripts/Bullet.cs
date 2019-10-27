using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
  {
		if (collision.gameObject.tag != "PlayerWhite" && collision.gameObject.tag != "PlayerBlack")
		{
			Destroy(gameObject);
		}
	}
}
