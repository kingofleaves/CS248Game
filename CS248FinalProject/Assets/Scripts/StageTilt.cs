using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTilt : MonoBehaviour {
	private float xAngle;
	private float zAngle;
	public float restoringforce;
	public float forceFactor;		

	private Gyroscope phoneGyro;
	// Use this for initialization
	void Start () {
		forceFactor = 80f;
		xAngle = 0f;
		zAngle = 0f;
//		phoneGyro = Input.gyro;
//		phoneGyro.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		// On PC

		xAngle += Input.GetAxis ("Vertical");
		xAngle += (0 - xAngle)*restoringforce;
		zAngle -= Input.GetAxis ("Horizontal");
		zAngle += (0 - zAngle)*restoringforce;
			// On Android
			//transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
			//transform.rotation = Input.gyro.attitude;

			transform.eulerAngles = new Vector3 (xAngle, 0, zAngle);
	}
}
