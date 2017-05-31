using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IMove {

    public TurnManager turnmanager;
    private int turnCount;
    private int turnsToStayAlive = 0;
    public GameObject buildText;

    // Use this for initialization
    void Start () {
	}

    private void TurnPassed()
    {
        turnCount++;
        Debug.Log("Turns Alive: " + turnCount);
        if (turnCount >= turnsToStayAlive)
        {
            turnCount = 0;
            TurnManager.OnTurn -= TurnPassed;
            this.gameObject.SetActive(false);
        }
    }

    public void CleanUp()
    {
        turnmanager.MoveIsDone(null);
    }

    public void DoMove()
    {
        if (gameObject.name.Equals("samuraiwall"))
        {
            gameObject.transform.position = new Vector3(-91, 3.1f, -54.4f);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90, 180, -80));
        }
        else if (gameObject.name.Equals("woodenwall"))
        {
            gameObject.transform.position = new Vector3(126.6f, 3f, 19);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
        }
        this.gameObject.SetActive(true);
        turnsToStayAlive += 3;
        TurnManager.OnTurn += TurnPassed;
        DisplayText();
    }

    private void DisplayText()
    {
        StartCoroutine(ShowWall());
    }

    private IEnumerator ShowWall()
    {
        buildText.SetActive(true);
        yield return new WaitForSeconds(0.5F);
        buildText.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        buildText.SetActive(true);
        yield return new WaitForSeconds(0.5F);
        buildText.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        buildText.SetActive(true);
        yield return new WaitForSeconds(0.5F);
        buildText.SetActive(false);
        CleanUp();
    }
}
