using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController {

	public void DecideMove(string name, TurnManager gamestate)
    {
        switch(name)
        {
            case "swordCard1":
                Debug.Log("GREEEAT! 1");
                break;
            case "swordCard2":
                Debug.Log("GREEEAT! 2");
                break;
            case "swordCard3":
                Debug.Log("GREEEAT! 3");
                break;
        }
    }
}
