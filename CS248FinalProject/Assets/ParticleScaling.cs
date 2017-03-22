using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScaling : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnWillRenderObject () {
		GetComponent<ParticleRenderer>().material.SetVector("_Center", transform.position);
        GetComponent<ParticleRenderer>().material.SetVector("_Scaling", transform.lossyScale);
        GetComponent<ParticleRenderer>().material.SetMatrix("_Camera", Camera.current.worldToCameraMatrix);
        GetComponent<ParticleRenderer>().material.SetMatrix("_CameraInv", Camera.current.worldToCameraMatrix.inverse);
    }
}
