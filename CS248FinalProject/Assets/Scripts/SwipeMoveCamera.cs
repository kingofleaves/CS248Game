using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMoveCamera : MonoBehaviour {
	private Vector2 startPos;
	public float cameraMoveFactor = 1f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
			Touch touchInput = Input.GetTouch (0);
			if (touchInput.phase == TouchPhase.Began) {
				startPos = touchInput.position;
			}
			if (touchInput.phase == TouchPhase.Moved) {
				if (!Camera.current.orthographic) {
					Camera.current.transform.parent = null;
					Vector3 cameraMove = new Vector3 (touchInput.deltaPosition.x, 0, touchInput.deltaPosition.y);
					cameraMove *= cameraMoveFactor;
					Camera.current.transform.Translate(cameraMove * cameraMoveFactor);
					// NOT SURE IF TRANSLATE IS OKAY DUE TO SCALE AND EVERYTHING.
				}
			}
		}
	}
}
