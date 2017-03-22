using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {
	private Camera [] cameras;
	// Use this for initialization
	void Start () {
		cameras = FindObjectsOfType<Camera>();
		foreach (Camera thisCamera in cameras) {
			thisCamera.enabled = !thisCamera.orthographic;
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
