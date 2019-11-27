using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag != "PlayerWhite" && collision.gameObject.tag != "PlayerBlack")
		{
		    if (collision.gameObject.tag == "EnemyWhite")
            {
                //TODO: Pogruntaj kako narediti animacijo, ki jih ubije? Also - treuntna faking animacija nog je problematicna, ker te zginejo?
                collision.gameObject.GetComponent<BuddySystem>().DestroyBuddy();
                Destroy(collision.gameObject);
            }

            Destroy(gameObject);
		}
	}
}
