using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {

	public List<GameObject> attackCards;
	public static float animationSpeed = 2f;

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

	Hashtable flip1 = iTween.Hash("y", 90, "time", animationSpeed,"easetype", iTween.EaseType.easeInQuad);
	Hashtable flip2 = iTween.Hash("y", 180, "time", animationSpeed, "easetype", iTween.EaseType.easeOutQuart);
	Hashtable moveToCenter = iTween.Hash("x", 730, "y", 350, "time", animationSpeed);
	Hashtable scale = iTween.Hash("x", 2, "y", 2, "time", animationSpeed);


	public IEnumerator TurnCard(GameObject otherCard){
		iTween.RotateTo (gameObject, flip1);
		yield return new WaitForSeconds (animationSpeed);
		gameObject.SetActive (false);
		otherCard.SetActive (true);
		iTween.RotateTo (otherCard, flip2);
		iTween.MoveTo (otherCard, moveToCenter);
		iTween.ScaleTo (otherCard, scale);
		yield return new WaitForSeconds (animationSpeed);
	}

}
