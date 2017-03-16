using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide : MonoBehaviour {

	// Use this for initialization
	//public ParticleSystem exp = GetComponent<ParticleSystem>();

	/*void update()
	{
		var exp = GetComponent<ParticleSystem>();
		exp.Play();
	}*/
	void OnCollisionEnter (Collision col)
	{
		//if (col.gameObject.name == "Cube")
		//{
		//	Destroy(col.gameObject);
		//}
		//var exp = GetComponent<ParticleSystem>();
		//exp.Play();
		//GetComponent<ParticleSystem>().Play();
		//Destroy (gameObject);

	}

}
