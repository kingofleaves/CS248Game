using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
	public GameObject GameOverUI;
	public GameObject deathEffect;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Goal") {
			triggerGoal ();
		}
		if (col.gameObject.tag != "stage") {
			triggerGameOver (col); 
		}
	}
	void triggerGoal() {

	}

	void triggerGameOver(Collision col) {
		LoadGameOver (col);
		DeathAnimation (col);
	}

	void LoadGameOver (Collision col) {
		GameOverUI.SetActive (true);
		//pass col to GameOverUI
	}

	void DeathAnimation (Collision col) {
		ContactPoint contact = col.contacts[0];
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		GameObject explosion = Instantiate (deathEffect, pos, rot);
		explosion.SetActive (true);
		explosion.GetComponent<ParticleSystem> ().Play ();
		Debug.Log (col.gameObject.tag);
		Debug.Log (col.gameObject.name);
		Destroy (col.gameObject);
		Destroy(gameObject);
	}
}
