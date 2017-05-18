using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour {

	public List<GameObject> attackCards;
	public static float animationSpeed = 2f;
    public GameObject MoveCanvas;
    private TurnManager Turnmanager;
    private Vector2 OriginalPosition;

	//private static Vector3 centerPos;
	private static int middleX = Screen.width / 2;
	private static int middleY = Screen.height / 2;

	//hashtables for itween

	//flip
	Hashtable flip1 = iTween.Hash("y", 90, "time", animationSpeed,"easetype", iTween.EaseType.easeInQuad);
    Hashtable flip2 = iTween.Hash("y", 180, "time", animationSpeed, "easetype", iTween.EaseType.easeOutQuart);
	Hashtable basePos = iTween.Hash("y", 0, "time", animationSpeed, "easetype", iTween.EaseType.easeOutQuart);
	Hashtable moveToCenter = iTween.Hash("x", (Screen.width / 2), "y", (Screen.height / 2), "time", animationSpeed);
	Hashtable scaleX2 = iTween.Hash("x", 2, "y", 2, "time", animationSpeed);
    Hashtable normalSize = iTween.Hash("x", 1, "y", 1, "time", animationSpeed);
    //pick
    Hashtable scaleX05 = iTween.Hash("x", 0.5f, "y", 0.5f, "time", animationSpeed);
	Hashtable moveToConor = iTween.Hash("x", 100, "y", 100, "time", animationSpeed);
	//shake
	Hashtable shake = iTween.Hash("z", 5, "speed", 1f);



	void Start () {
        Turnmanager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        OriginalPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
	}

	void Update () {
		
	}

	//public methods to call from trigger.
	public void FlipCard(){
        if (Turnmanager.HasPlayerChooseCard) return;
		GameObject newCard = attackCards [UnityEngine.Random.Range( 0, attackCards.Count )];
        Turnmanager.HasPlayerChooseCard = true;
		StartCoroutine (TurnCard(newCard));
       // StartCoroutine("TurnCard", newCard);
		newCard.transform.Rotate (0, 90, 0);
        StartCoroutine("Thing", 2.0F);
    }



    IEnumerator Thing(float Why)
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Hello");
        gameObject.GetComponent<RectTransform>().anchoredPosition = OriginalPosition;
        yield return null;
    }


    public void PickCard(){
		iTween.MoveTo (gameObject, moveToConor);
		iTween.ScaleTo (gameObject, scaleX05);
		Debug.Log ("xxx");
		print ("yyy");
	}

	public void ShakeCard(){
        if (Turnmanager.HasPlayerChooseCard) return;
        iTween.ShakeRotation (gameObject, shake);
	}


	//coroutines and other logic.
	public IEnumerator TurnCard(GameObject otherCard){
		iTween.RotateTo (gameObject, flip1);
		yield return new WaitForSeconds (animationSpeed);
        iTween.RotateTo(gameObject, basePos);
        //gameObject.SetActive (false);
        otherCard.SetActive (true);
		iTween.RotateTo (otherCard, flip2);
		iTween.MoveTo (otherCard, moveToCenter);
		iTween.ScaleTo (otherCard, scaleX2);
        yield return new WaitForSeconds (animationSpeed);
        yield return new WaitForSeconds(1.0F);
        ResetJustActivedCard(otherCard);
    }

    private void ResetJustActivedCard(GameObject otherCard)
    {
        Debug.Log("Go Back");
        otherCard.GetComponent<RectTransform>().rotation = gameObject.GetComponent<RectTransform>().rotation;
        otherCard.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position;
        otherCard.GetComponent<RectTransform>().localScale = new Vector2(1.0F, 1.0F);
        //otherCard.GetComponent<Image>().enabled = false;
        Turnmanager.MoveCanvas.SetActive(true);
        otherCard.GetComponent<DoMove>().Activate();
        Turnmanager.SetPlayerCanvasInactive();
    }

}
