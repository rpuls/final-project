using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

    public TurnState CurrentTurnState;
    public GameManager GameManager;
	
	void Start () {
        // This gets the Game Manager from the GameManager Object!
        GameObject gameManager = GameObject.Find("Game Manager");
        GameManager = gameManager.GetComponent<GameManager>();
        //
        CameraScript.ChangeCamera(CameraView.Center);
        CurrentTurnState = TurnState.Start;
        GameObject Turnbutton = GameObject.Find("End Turn Button Text");
        Turnbutton.GetComponent<Text>().text = "Start game";
	}
	

    public void EndTurn()
    {
        if(CurrentTurnState == TurnState.Start)
        {
            EditTurnButton();
            GiveTurnToPlayerOne();
        }

        else if(CurrentTurnState == TurnState.PlayerOne)
        {
            GiveTurnToPlayerTwo();
        }

        else if(CurrentTurnState == TurnState.PlayerTwo)
        {
            GiveTurnToPlayerOne();
        }

    }

    

    private void GiveTurnToPlayerOne()
    {
        CameraScript.ChangeCamera(CameraView.P1);
        CurrentTurnState = TurnState.PlayerOne;
        GameObject PlayerNameText = GameObject.Find("Info Text");
        PlayerNameText.GetComponent<Text>().text = ("Player: " + GameManager.playerOne.userName);
    }

    private void GiveTurnToPlayerTwo()
    {
        CameraScript.ChangeCamera(CameraView.P2);
        CurrentTurnState = TurnState.PlayerTwo;
        GameObject PlayerNameText = GameObject.Find("Info Text");
        PlayerNameText.GetComponent<Text>().text = ("Player: " + GameManager.playerTwo.userName);
    }

    private void EditTurnButton()
    {
        GameObject Turnbutton = GameObject.Find("End Turn Button Text");
        Turnbutton.GetComponent<Text>().text = "End Turn";
    }

    public enum TurnState {PlayerOne, PlayerTwo, Start};
}
