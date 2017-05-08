using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {

	public List<GameObject> attackCards;
	public static float animationSpeed = 2f;
    private TurnManager Turnmanager;


	//hashtables for itween

	//flip
	Hashtable flip1 = iTween.Hash("y", 90, "time", animationSpeed,"easetype", iTween.EaseType.easeInQuad);
	Hashtable flip2 = iTween.Hash("y", 180, "time", animationSpeed, "easetype", iTween.EaseType.easeOutQuart);
	Hashtable moveToCenter = iTween.Hash("x", Screen.width/2, "y", Screen.height/2, "time", animationSpeed);
	Hashtable scaleX2 = iTween.Hash("x", 2, "y", 2, "time", animationSpeed);
	//pick
	Hashtable scaleX05 = iTween.Hash("x", 0.5f, "y", 0.5f, "time", animationSpeed);
	Hashtable moveToConor = iTween.Hash("x", 100, "y", 100, "time", animationSpeed);
	//shake
	Hashtable shake = iTween.Hash("z", 5, "speed", 1f);



	void Start () {
        Turnmanager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
	}

	void Update () {
		
	}

	//public methods to call from trigger.
	public void FlipCard(){
		GameObject newĆard = attackCards [Random.Range( 0, attackCards.Count )];
        string thing = newĆard.gameObject.name;
        Turnmanager.ReciveMove(thing);
		StartCoroutine (TurnCard(newĆard));
		newĆard.transform.Rotate (0, 90, 0);
	}

	public void PickCard(){
		iTween.MoveTo (gameObject, moveToConor);
		iTween.ScaleTo (gameObject, scaleX05);
		Debug.Log ("xxx");
		print ("yyy");
	}

	public void ShakeCard(){
		iTween.ShakeRotation (gameObject, shake);
	}



	//coroutines and other logic.
	public IEnumerator TurnCard(GameObject otherCard){
		iTween.RotateTo (gameObject, flip1);
		yield return new WaitForSeconds (animationSpeed);
		gameObject.SetActive (false);
		otherCard.SetActive (true);
		iTween.RotateTo (otherCard, flip2);
		iTween.MoveTo (otherCard, moveToCenter);
		iTween.ScaleTo (otherCard, scaleX2);
		yield return new WaitForSeconds (animationSpeed);
	}
		
}
