using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IconBehaviour : MonoBehaviour, IPointerDownHandler {
	public Button thisButton;
	private float originalSize;

	void Awake () {
		thisButton = GetComponent<Button> ();
	}

	void Start() {
		originalSize = thisButton.image.rectTransform.localScale.magnitude;
	}

	void Update () {
		StartCoroutine (shrink ());
	}

	public void OnPointerDown(PointerEventData eventData) {
		thisButton.image.rectTransform.localScale *= 1.5f;
	}

	IEnumerator shrink() {
		if (thisButton.image.rectTransform.localScale.magnitude > originalSize) {
			thisButton.image.rectTransform.localScale *= 0.95f;
		} 
		yield return null;
	}
		
}
