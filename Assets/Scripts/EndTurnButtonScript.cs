using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButtonScript : MonoBehaviour {

    public GameObject TurnManager;

    public void EndTurnClicked()
    {
        // Just passes on the command to the Turn Manager
        TurnManager.GetComponent<TurnManager>().EndTurn();
    }
}
