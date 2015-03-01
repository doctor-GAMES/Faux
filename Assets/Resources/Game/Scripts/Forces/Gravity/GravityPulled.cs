﻿using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class GravityPulled : MonoBehaviour 
{
	public bool keepUpright = false;
	
	GameObject[] attractors;
	GameObject closest;


	void Start ()
	{

		rigidbody2D.fixedAngle = false;
		attractors = World.GravityAttractors;
	}

	void FixedUpdate () 
	{
		float biggestAtt = 0;
		foreach(GameObject attractor in attractors)
		{
			float dist = (transform.position - attractor.transform.position).magnitude;
			float att = attractor.rigidbody2D.mass / Mathf.Pow(dist,2);
			if( att > biggestAtt)
			{
				biggestAtt = att;
				closest = attractor;
			}
		}
	}

	void Update ()
	{
		closest.GetComponent<GravityAttractor>().Attract(gameObject, keepUpright);
	}
}