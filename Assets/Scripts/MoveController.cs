using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController {

    MoveContainer Container;

    public MoveController()
    {
      Container = GameObject.Find("MovesContainer").GetComponent<MoveContainer>();
      ThunderTimerScript.ShotFeedback += ShotFeedback;
    }

	public void DecideMove(string name, TurnManager gamestate)
    {

        switch(name)
        {
            case "swordCard1":
                LightningAttack();
                break;
            case "swordCard2":
                LightningAttack();
                break;
            case "swordCard3":
                LightningAttack();
                break;
        }
    }

    private void LightningAttack()
    {
        Container.ThunderTimer.SetActive(true);
    }

    private void ShotFeedback(bool hit)
    {
        Debug.Log("Hit or Miss: " + hit);
        if(hit) Container.LightningBoltAnimation.SetActive(true);
        Container.ThunderTimer.SetActive(false);
    }
}
