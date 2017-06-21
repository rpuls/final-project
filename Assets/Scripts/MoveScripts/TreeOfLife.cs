using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeOfLife : MonoBehaviour, IMove {

	public Text RestoreHPText;
	public TurnManager turnManager;

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
		turnManager.GameManager.playerTwo.lifeLeft = 100;
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
