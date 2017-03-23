using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour {
	public GameObject playerObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerObject != null) {
			this.transform.position = new Vector3 (playerObject.transform.position.x, this.transform.position.y, playerObject.transform.position.z);
		}
	}
}
