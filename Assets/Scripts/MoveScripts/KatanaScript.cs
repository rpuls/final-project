using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaScript : MonoBehaviour, IMove {

	public GameObject KatanaPrefab;
	public TurnManager turnmanager;
	private Vector3 StartPos = new Vector3(-124f,16f,0f);
	private Hashtable Attack = iTween.Hash("x", 110f, "y", 16f, "z", 0f, "time", 1);//, "easetype", iTween.EaseType.easeInQuad);
	private Hashtable AttackFail = iTween.Hash("x", 63f, "y", 16f, "z", 0f, "time", 1);//, "easetype", iTween.EaseType.easeInQuad);
	private bool OponentHaveWall;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	//Activates itself
	public void DoMove() {
		CleanUp ();
		//some how, check if oponen have wall defense active and set OponentHaveWall = true
		this.gameObject.SetActive(true);
		StartCoroutine (KatanaAttack ());
	}


	private IEnumerator KatanaAttack(){
		yield return new WaitForSeconds (1f);
		CameraScript.ChangeCamera (CameraView.P2K);
		yield return new WaitForSeconds (0.5f);
		KatanaPrefab.SetActive (true);
		yield return new WaitForSeconds (1f);
		if (OponentHaveWall) {
			iTween.MoveTo (KatanaPrefab, AttackFail);
			yield return new WaitForSeconds (1.1f);
		} else {
			iTween.MoveTo (KatanaPrefab, Attack);
			turnmanager.GameManager.playerOne.GiveDamage (20);
			yield return new WaitForSeconds (1.1f);
		}
		yield return new WaitForSeconds (1f);
		CleanUp();
		turnmanager.MoveIsDone(null);
	}

	public void CleanUp(){
		KatanaPrefab.transform.position = StartPos;
		KatanaPrefab.SetActive (false);
		OponentHaveWall = false;
	}
}
