using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FlipCard(GameObject otherCard){
		iTween.RotateTo (gameObject, new Vector3 (0, 90, 0), 3f);
		otherCard.transform.Rotate(new Vector3(0,90,0));
		otherCard.SetActive (true);
		gameObject.SetActive (false);
		iTween.RotateTo(otherCard, new Vector3 (0, 180, 0), 3f);
	}
}
