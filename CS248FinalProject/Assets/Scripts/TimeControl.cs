using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour {
	public float timescale = 1f;
	private bool paused;
	public Button pauseButton;
	public Sprite pause;
	public Sprite play;
	public GameObject[] gameAudios;

	// Use this for initialization
	void Start () {
		Time.timeScale = timescale;
		paused = false;
		gameAudios = GameObject.FindGameObjectsWithTag ("MainAudio");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pause() {
		if (paused) {
			Time.timeScale = timescale;
			pauseButton.image.sprite = pause;
			for (int i = 0; i < gameAudios.Length; i++) {
				gameAudios [i].GetComponent<AudioSource>().Play ();
			}
		} else {
			Time.timeScale = 0f;
			pauseButton.image.sprite = play;
			for (int i = 0; i < gameAudios.Length; i++) {
				gameAudios [i].GetComponent<AudioSource>().Pause ();
			}
		}
		paused = !paused;
	}
}
