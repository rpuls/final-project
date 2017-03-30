using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThunderTimerScript : MonoBehaviour {

	private float m_Position = 0f;					// The starting position in % of where the thundercloud will spawn
	public Slider m_Slider;							// The slider to represent where the cloud is
	public Image m_FillImage;						// The image component of the slider.
	public Color m_FullHealthColor = Color.green;	// The color the health bar will be when on full health.
	public Color m_ZeroHealthColor = Color.red;		// The color the health bar will be when on no health.
	public GameObject m_ThunderStroke;				// A "thunder" prefab that will be instantiated when space i tabbed, and spawns where the cloud is

	// Use this for initialization
	void Start (){
		
	}
	
	// Update is called once per frame
	float tempTime;
	void Update (){
		tempTime += Time.deltaTime;
		if (tempTime > 0.01) {
			tempTime = 0;
			moveCloud ();
		}
	}

	bool isMovingFoward = true;
	public void moveCloud (){
		

		if (isMovingFoward) {
			m_Position += 0.03f;
			if (m_Position >= 0.99f) {
				isMovingFoward = false;
			}
		} else {
			m_Position -= 0.03f;
			if (m_Position <= 0.01f) {
				isMovingFoward = true;
			}
		}
		m_Slider.value = m_Position;
	}
}
