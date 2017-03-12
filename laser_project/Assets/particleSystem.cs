using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystem : MonoBehaviour {
		public bool x;
		public ParticleSystem dust;

		void Start () {
			ParticleSystem pS = GetComponent<ParticleSystem>();
			pS.enableEmission = true;
		}

	/*
		void Update () 
		{
			if(x){

				dust.Play();
			}

			else if(!x){

				dust.Stop();

			}
		}
		*/

}
