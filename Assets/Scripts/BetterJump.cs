﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2.0f;

	private Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();	
	}
	
  void Update()
  {
		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (rb.velocity.y > 0 && !Input.GetButton("JumpU") || rb.velocity.y > 0 && !Input.GetButton("JumpW"))
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
  }
}
