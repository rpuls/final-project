using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : MonoBehaviour, IMove {

    public TurnManager Turnmanager;
    public GameObject Header;
    public GameObject TurnText;
    private int TurnsWithDamageBoost = 0;


    public void CleanUp()
    {
        Header.SetActive(false);
        TurnText.SetActive(false);
        Turnmanager.MoveIsDone(null);
    }

    public void DoMove()
    {
        this.gameObject.SetActive(true);
        Header.SetActive(true);
        TurnText.SetActive(true);
        TurnManager.OnTurn += TurnHasPassed;
        StartCoroutine(BoostDamage());
    }

    private void TurnHasPassed()
    {
        TurnsWithDamageBoost--;
        if(TurnsWithDamageBoost <= 0)
        {
            TurnsWithDamageBoost = 0;
            Turnmanager.GameManager.playerTwo.SetDamageMultiplier(1F);
            TurnManager.OnTurn -= TurnHasPassed;
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator BoostDamage()
    {
        TurnsWithDamageBoost = 3;
        Turnmanager.GameManager.playerTwo.SetDamageMultiplier(3.0F);
        yield return new WaitForSeconds(1);
        TurnText.SetActive(true);
        yield return new WaitForSeconds(0.5F);
        TurnText.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        TurnText.SetActive(true);
        yield return new WaitForSeconds(0.5F);
        CleanUp();
    }
}
