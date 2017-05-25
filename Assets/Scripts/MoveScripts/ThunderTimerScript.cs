using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThunderTimerScript : MonoBehaviour, IMove {
    public delegate void HitOrMiss(bool hit);
    public Slider SliderBar;						// The slider to represent where the cloud is
	public Image m_FillImage;						// The image component of the slider.
	public AudioSource m_ThunderStrikeSound;		// Sound source
	public GameObject m_thunderAnimation;			// animation prefab source
	public GameObject m_missText;					// UI canvas text object
	private bool move = true;						// Used to toggle movement
	private bool isMovingFoward = true;				// Used to change direction forth/back
	private float position = 0f;					// The starting position in % of where the thundercloud will spawn
	public float thunderHitStart = 0.45f;			// 0.5f is middle all below is considered "hitable"
	public float thunderHitEnd = 0.55f;				// 0.5f is middle all above is considered "hitable"
	private float tempTime;							// Used for delay
    public TurnManager turnManager;

	void Start() {
		m_ThunderStrikeSound = GameObject.FindGameObjectWithTag("Thunder").GetComponent<AudioSource>();
		SliderBar.transform.position = new Vector3 ((Screen.width / 2)+50, Screen.height-45 );
	}

	void Update() {
		MoveCloud ();
		Shoot ();
	}

	private void Shoot() {
		if (Input.GetKeyDown ("space")) {
			move = false;
			if (position > thunderHitStart && position < thunderHitEnd) {
				m_ThunderStrikeSound.Play ();
				StartCoroutine (StrikeAnimator (m_thunderAnimation));
			} else {
				m_missText.SetActive (true);
                CleanUp();
            }
		}
	}

	private IEnumerator StrikeAnimator(GameObject thunder_prefab){
		thunder_prefab.SetActive (true);
		yield return new WaitForSeconds (0.3f);
		thunder_prefab.SetActive (false);
		yield return new WaitForSeconds (0.2f);
		thunder_prefab.SetActive (true);
		yield return new WaitForSeconds (0.3f);
		thunder_prefab.SetActive (false);
		yield return new WaitForSeconds (2f);
        CleanUp();
    }

	public void MoveCloud() {
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
				SliderBar.value = position;
			}
		}
	}

    public void DoMove() {
        this.gameObject.SetActive(true);
    }

    public void CleanUp() {
        move = true;
		m_missText.SetActive (false);
        turnManager.MoveIsDone(this.gameObject);
    }
}
