using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour {
	public float perspZoomSpeed = 0.5f;
	public float orthoZoomSpeed = 0.5f;
	public float maxOrthoSize = 10f;
	public float minOrthoSize = 0.1f;
	public float maxPerspSize = 100f;
	public float minPerspSize = 10f;
	public SwitchCamera switchCamera;
	public GameObject instructionText;
	private bool textClosed = false;
	// Use this for initialization
	void Start () {
		switchCamera = FindObjectOfType<SwitchCamera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 2) {
			Touch touchZero = Input.GetTouch (0);
			Touch touchOne = Input.GetTouch (1);
			if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began) {
				return;
			}
			Vector2 touchZeroPreviousPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePreviousPos = touchOne.position - touchOne.deltaPosition;

			float previousTouchSeparation = Vector2.Distance (touchZeroPreviousPos, touchOnePreviousPos);
			float currTouchSeparation = Vector2.Distance (touchZero.position, touchOne.position);

			float touchSeparationDifference = previousTouchSeparation - currTouchSeparation;

			if (Camera.current.orthographic) {
				//Camera.current.orthographicSize += touchSeparationDifference * orthoZoomSpeed;
				//Camera.current.orthographicSize = Mathf.Clamp (Camera.current.orthographicSize, minOrthoSize, maxOrthoSize);
			} else {
				Camera.current.fieldOfView += touchSeparationDifference * perspZoomSpeed;
				Camera.current.fieldOfView = Mathf.Clamp (Camera.current.fieldOfView, minPerspSize, maxPerspSize);
			}
		}	

		if (switchCamera.perspCamera.isActiveAndEnabled && instructionText != null) {
			instructionText.SetActive (true);
		}
	}
}
