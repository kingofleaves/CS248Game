using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {
	private Camera [] cameras;
	public Camera perspCamera;
	public Camera orthoCamera;
	// Use this for initialization
	void Awake () {
		cameras = FindObjectsOfType<Camera>();
		foreach (Camera thisCamera in cameras) {
			thisCamera.enabled = thisCamera.orthographic;
			if (thisCamera.orthographic)
				orthoCamera = thisCamera;
			else
				perspCamera = thisCamera;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void switchCamera () {
		
		foreach (Camera thisCamera in cameras) {
			thisCamera.enabled = !thisCamera.enabled;
		}
	}
}
