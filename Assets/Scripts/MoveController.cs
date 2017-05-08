using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController {

    MoveContainer Container;

	public void DecideMove(string name, TurnManager gamestate)
    {
        Container = GameObject.Find("MovesContainer").GetComponent<MoveContainer>();

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
        Container.LightningBoltAnimation.SetActive(true);

    }
}
