using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {



	void OnParticleCollision (GameObject other )
	{
		Destroy (gameObject);
	}
}
