using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplier : MonoBehaviour {
	private Rigidbody rb;
	public float forceFactor;
	private GameObject stage;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		stage = GameObject.FindGameObjectWithTag ("rotating");
		forceFactor = stage.GetComponent<StageTilt> ().forceFactor;
	}

	// Update is called once per frame
	void Update () {
		Vector3 forceToAdd = new Vector3(forceFactor*Input.GetAxis ("Horizontal"), -forceFactor * 1f, forceFactor*Input.GetAxis ("Vertical"));
		//forceToAdd = stage.transform.rotation * forceToAdd;
		Vector3 phoneAccel = new Vector3 (Input.acceleration.x, Input.acceleration.z, Input.acceleration.y);

		if (phoneAccel.magnitude > 0.01f) {
			forceToAdd += phoneAccel * forceFactor;
			if (forceToAdd.y > -1f) {
				forceToAdd.y = -1f;
			}
		}
		rb.AddForce (forceToAdd);
	}
}
