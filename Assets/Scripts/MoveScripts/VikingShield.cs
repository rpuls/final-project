using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VikingShield : MonoBehaviour, IMove {

    public TurnManager Turnmanager;
    public GameObject TurnsTextObj;
    public GameObject Header;
    private int TurnsReduceDamageCount = 0;

  	
    public void CleanUp()
    {
        TurnsTextObj.SetActive(false);
        Header.SetActive(false);
        Turnmanager.MoveIsDone(null);
    }

    public void DoMove()
    {
        this.gameObject.SetActive(true);
        Header.SetActive(true);
        TurnManager.OnTurn += TurnHasPassed;
        TurnsReduceDamageCount += 7;
        StartCoroutine(ReducesVikingDamage());
    }

    //Gets called when Turn has passed!
    private void TurnHasPassed()
    {
        TurnsReduceDamageCount--;
        Debug.Log("Turns Left with Reduced Damage: " + TurnsReduceDamageCount);
        if(TurnsReduceDamageCount <= 0)
        {
            TurnsReduceDamageCount = 0;
            Turnmanager.GameManager.playerOne.SetDamageReducer(1F);
            TurnManager.OnTurn -= TurnHasPassed;
            this.gameObject.SetActive(false);
        }
        
    }

    private IEnumerator ReducesVikingDamage()
    {
        Turnmanager.GameManager.playerOne.SetDamageReducer(0.75F);
        yield return new WaitForSeconds(1);
        TurnsTextObj.SetActive(true);
        yield return new WaitForSeconds(0.5F);
        TurnsTextObj.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        TurnsTextObj.SetActive(true);
        yield return new WaitForSeconds(0.5F);
        CleanUp();
    }
}
