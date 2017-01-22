using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTilt : MonoBehaviour {
	private float xAngle;
	private float zAngle;
	public float restoringforce;
	// Use this for initialization
	void Start () {
		xAngle = 0f;
		zAngle = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		xAngle = Input.GetAxis ("Horizontal");
		xAngle += (0 - xAngle)*restoringforce;
		zAngle = Input.GetAxis ("Vertical");
		zAngle += (0 - zAngle)*restoringforce;
		transform.Rotate(new Vector3(xAngle, 0, zAngle));
		
	}
}
