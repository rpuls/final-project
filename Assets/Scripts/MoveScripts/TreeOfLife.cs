using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeOfLife : MonoBehaviour, IMove {

	public Text RestoreHPText;
	public TurnManager turnManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Activates itself
	public void DoMove() {
		CleanUp();
		this.gameObject.SetActive(true);
		StartCoroutine(RestoreCountDown());
	}

	private IEnumerator RestoreCountDown(){
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n.";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n..";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n...";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n....";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n.....";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n......";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n.......";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n........";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n.........";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n..........";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n...........";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n............";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n.............";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n..............";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n...............";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n................";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n.................";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n..................";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "RESTORE HP!\n...................";
		yield return new WaitForSeconds (0.1f);
		//turnManager. SET HP TO 100
		RestoreHPText.text = "HP RESTORED!";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "";
		yield return new WaitForSeconds (0.1f);		
		RestoreHPText.text = "HP RESTORED!";
		yield return new WaitForSeconds (0.1f);		
		RestoreHPText.text = "";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "HP RESTORED!";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "";
		yield return new WaitForSeconds (0.1f);		
		RestoreHPText.text = "HP RESTORED!";
		yield return new WaitForSeconds (0.1f);		
		RestoreHPText.text = "";
		yield return new WaitForSeconds (0.1f);
		RestoreHPText.text = "HP RESTORED!";
		yield return new WaitForSeconds (0.1f);
		CleanUp();
		turnManager.MoveIsDone (null);
	}

	public void CleanUp(){
		RestoreHPText.text = "";
		this.gameObject.SetActive(false);
	}
}
