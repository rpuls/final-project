﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThunderTimerScript : MonoBehaviour {

	public Slider m_Slider;							// The slider to represent where the cloud is
	public Image m_FillImage;						// The image component of the slider.
	public GameObject m_ThunderStroke;				// A "thunder" prefab that will be instantiated when space i tabbed, and spawns where the cloud is
	public AudioSource m_ThunderStrikeSound;		// Sound source
	public GameObject m_thunderAnimation;			// animation prefab source
	private bool move = true;						// Used to toggle movement
	private bool isMovingFoward = true;				// Used to change direction forth/back
	private float position = 0f;					// The starting position in % of where the thundercloud will spawn
	public float thunderDifficulty = 0.9f;			// low = easy, max difficulty = 0.99f
	private float tempTime;							// Used for delay
	// Use this for initialization
	void Start (){
		m_ThunderStrikeSound = GameObject.FindGameObjectWithTag("Thunder").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame

	void Update (){
		MoveCloud ();
		Shoot ();
	}

	private void Shoot(){
		if (Input.GetKeyDown ("space")) {
			move = false;
			if (position > thunderDifficulty) {
				m_ThunderStrikeSound.Play ();
				m_thunderAnimation.SetActive (true);
				StartCoroutine(StrikeAnimator (m_thunderAnimation));
			}
		}
	}

	private IEnumerator StrikeAnimator(GameObject thunder_prefab){
		thunder_prefab.SetActive (true);
		yield return new WaitForSeconds (5);
		thunder_prefab.SetActive (false);
	}

	public void MoveCloud (){
		if (move) {
			tempTime += Time.deltaTime;
			if (tempTime > 0.01) {
				tempTime = 0;
				if (isMovingFoward) {
					position += 0.03f;
					if (position >= 0.99f) {
						isMovingFoward = false;
					}
				} else {
					position -= 0.03f;
					if (position <= 0.01f) {
						isMovingFoward = true;
					}
				}
				m_Slider.value = position;
			}
		}
	}
}