using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour {
	public float timescale = 1f;

	// Use this for initialization
	void Start () {
		Time.timeScale = timescale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
