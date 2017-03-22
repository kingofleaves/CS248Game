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
	public AudioSource gameAudio;

	// Use this for initialization
	void Start () {
		Time.timeScale = timescale;
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pause() {
		if (paused) {
			Time.timeScale = timescale;
			pauseButton.image.sprite = pause;
			gameAudio.Play ();
		} else {
			Time.timeScale = 0f;
			pauseButton.image.sprite = play;
			gameAudio.Pause ();
		}
		paused = !paused;
	}
}
