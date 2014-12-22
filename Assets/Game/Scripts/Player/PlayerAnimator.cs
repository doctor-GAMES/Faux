﻿using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

	Animator anim;
	PlayerController PC;
	
	public float maxIdleTime = 40.0f, idleTime;

	void Awake () 
	{
		anim = GetComponent<Animator>();
		PC = GetComponent<PlayerController>();
	}

	void Update () 
	{
		anim.SetBool("moving", (rigidbody2D.velocity != Vector2.zero));
		anim.SetFloat("verticalVelocity", transform.InverseTransformDirection(rigidbody2D.velocity).y);
		anim.SetBool("grounded", PC.grounded);

		if(idleTime < 0)
		{
			anim.SetInteger("idleActivity", Random.Range(1,3));
			idleTime = Random.Range(0.0f, maxIdleTime);
		}
		else
		{
			anim.SetInteger("idleActivity", 0);
			idleTime -= Time.deltaTime;
		}
	}

	void StopAtFrame()
	{
		anim.StopPlayback();
	}
}
