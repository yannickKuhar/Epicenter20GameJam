using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePlayer : MonoBehaviour
{
		public string horizontalInputName;

		public float movementSpeed = 5.0f;
		public float jumpSpeed = 5.0f;

		private Rigidbody2D rb;

		public KeyCode jumpKey;

		private bool isJumping = false;
		
    // Start is called before the first frame update
    void Awake()
    {
			rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }

		private void PlayerMovement()
		{
			float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

			Vector2 vect = rb.velocity;
 
			rb.velocity = new Vector2 (horizInput * movementSpeed, vect.y);
		}
}
