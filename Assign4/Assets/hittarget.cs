﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hittarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision col)
	{

		GetComponent<ParticleSystem>().Play();
	}
}
