using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
	public GameObject GameOverUI;
	public GameObject SuccessUI;
	public GameObject Menu;
	public GameObject deathEffect;
	public AudioSource bgm;
	public AudioSource explosionAudio;
	public AudioSource successAudio;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Goal") {
			if (!SuccessUI.activeInHierarchy) {
				triggerGoal ();
			}	
			Debug.Log ("success");
		} else if (col.gameObject.tag != "stage") {
			triggerGameOver (col); 
		}
	}
	void triggerGoal() {
		Menu.SetActive (true);
		SuccessUI.SetActive (true);
		bgm.Stop ();
		successAudio.Play ();
	}

	void triggerGameOver(Collision col) {
		if (!SuccessUI.activeInHierarchy) {
			LoadGameOver ();
		}
		DeathAnimation (col);
	}

	void LoadGameOver () {
		Menu.SetActive (true);
		GameOverUI.SetActive (true);
	}

	void DeathAnimation (Collision col) {
		explosionAudio.Play();
		bgm.Stop ();
		Handheld.Vibrate ();
		explosionAudio.transform.parent = transform.parent;
		GetComponent<Rigidbody> ().isKinematic = true;
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
