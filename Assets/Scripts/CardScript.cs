using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {

	//GameObject selectedCard;

	// Use this for initialization
	void Start () {
		//selectedCard = GameOGetComponent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FlipCard(){
		print ("test");
		gameObject.transform.Rotate(new Vector3(0,0,180));
	}
}
