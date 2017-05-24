using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoCanvasPositionScript : MonoBehaviour {

	public Text VikingPlayerInfo;
	public Text VikingLife;
	public Text SamuraiPlayerInfo;
	public Text SamuraiLife;
	public Text TurnInfo;

	//public GameObject VikingPlayerInfo;

	// Use this for initialization
	void Start () {
		SetPositions ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetPositions(){
		VikingPlayerInfo.rectTransform.anchoredPosition = new Vector2 (-(Screen.width/2)+130f, (Screen.height/2)-45f);
		VikingLife.rectTransform.anchoredPosition = new Vector2 (-(Screen.width/2)+130f, (Screen.height/2)-75f);
		SamuraiPlayerInfo.rectTransform.anchoredPosition = new Vector2 ((Screen.width/2)-130f, (Screen.height/2)-45f);
		SamuraiLife.rectTransform.anchoredPosition = new Vector2 ((Screen.width/2)-130f, (Screen.height/2)-75f);
		TurnInfo.rectTransform.anchoredPosition = new Vector2 (-(Screen.width/2)+130f, -(Screen.height/2)+45f);
	}
}
