using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {
	public AudioSource gameAudio;
	private bool isLoading;
	// Use this for initialization
	void Start () {
		isLoading = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isLoading) {
			StartCoroutine (audioFade ());
		}
	}

	public void LoadScene() {	
		isLoading = true;
		Invoke ("nextScene", 1.1f);
	}

	void nextScene() {
		SceneManager.LoadScene ("Let It Go Test");
	}

	IEnumerator audioFade() {
		gameAudio.volume *= 0.9f;
		yield return null;
	}
}
