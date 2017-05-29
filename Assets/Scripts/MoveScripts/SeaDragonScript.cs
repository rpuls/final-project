using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaDragonScript : MonoBehaviour, IMove {

	public GameObject SeaSnakePrefab;
	public TurnManager turnmanager;
	private Vector3 StartPos = new Vector3(145,-18f,6.5f);
	private Hashtable Engange = iTween.Hash("x", 145f, "y", -1f, "z", 6.5f, "time", 1);//, "easetype", iTween.EaseType.easeInQuad);
	private Hashtable Attack = iTween.Hash("x", -97f, "y", 7f, "z", 6.5f, "time", 1);//, "easetype", iTween.EaseType.easeInQuad);
	private Hashtable AttackFail = iTween.Hash("x", -45f, "y", 7f, "z", 6.5f, "time", 1);//, "easetype", iTween.EaseType.easeInQuad);
	private bool OponentHaveWall;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Activates itself
	public void DoMove()
	{
		CleanUp();
		//some how, check if oponen have wall defense active and set OponentHaveWall = true
		this.gameObject.SetActive(true);
		StartCoroutine (SeaAttack ());
	}


	private IEnumerator SeaAttack(){
		//yield return new WaitForSeconds (2f);
		CameraScript.ChangeCamera (CameraView.Center);
		yield return new WaitForSeconds (2f);
		iTween.MoveTo (SeaSnakePrefab, Engange);
		yield return new WaitForSeconds (1.1f);
		if (OponentHaveWall) {
			iTween.MoveTo (SeaSnakePrefab, AttackFail);
			yield return new WaitForSeconds (1.1f);
		} else {
			iTween.MoveTo (SeaSnakePrefab, Attack);
			turnmanager.GameManager.playerTwo.GiveDamage (33);
			yield return new WaitForSeconds (1.1f);
		}
		CleanUp();
		turnmanager.MoveIsDone(null);
	}

	public void CleanUp(){
		SeaSnakePrefab.transform.position = StartPos;
		SeaSnakePrefab.transform.rotation = Quaternion.Euler(-90, 0, -90);
		OponentHaveWall = false;
	}
}
