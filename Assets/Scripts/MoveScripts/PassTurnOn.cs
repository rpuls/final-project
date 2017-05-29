using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTurnOn : MonoBehaviour, IMove {

    public TurnManager turnmanager;

    public void CleanUp()
    {
        turnmanager.MoveIsDone(this.gameObject);
    }

    public void DoMove()
    {
        this.gameObject.SetActive(true);
        StartCoroutine(WaitABit());
    }

    private IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(2.0F);
        CleanUp();
    }
}
