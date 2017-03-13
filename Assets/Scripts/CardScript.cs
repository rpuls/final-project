using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {

	public List<GameObject> attackCards;
	float turnSpeed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void FlipCard(){
		GameObject newĆard = attackCards [Random.Range( 0, attackCards.Count )];
		StartCoroutine (TurnCard(newĆard));
		newĆard.transform.Rotate (0, 90, 0);

	}

	public IEnumerator TurnCard(GameObject otherCard){
		iTween.RotateTo (gameObject, new Vector3 (0, 90, 0), turnSpeed);
		yield return new WaitForSeconds (turnSpeed);
//		gameObject.SetActive (false);
		otherCard.SetActive (true);
		iTween.RotateTo (otherCard, new Vector3 (0, 180, 0), turnSpeed);
		yield return new WaitForSeconds (turnSpeed);
	}

}
