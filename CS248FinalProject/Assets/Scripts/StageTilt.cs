using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTilt : MonoBehaviour {
	//private float xAngle;
	//private float zAngle;
	public float restoringforce;

	private Gyroscope phoneGyro;
	// Use this for initialization
	void Start () {
		xAngle = 0f;
		zAngle = 0f;
		phoneGyro = Input.gyro;
		if (!phoneGyro.enabled)
			phoneGyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		// On PC
		/*
		xAngle += Input.GetAxis ("Horizontal");
		xAngle += (0 - xAngle)*restoringforce;
		zAngle += Input.GetAxis ("Vertical");
		zAngle += (0 - zAngle)*restoringforce;
		transform.eulerAngles = new Vector3 (xAngle, 0, zAngle);
		*/

		// On Android
		gameObject.transform.rotation = phoneGyro.attitude;

	}
}
