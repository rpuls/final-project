using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

    public TurnState CurrentTurnState;
    public GameManager GameManager;
    public GameObject CanvasPlayerOne;
    public GameObject CanvasPlayerTwo;
	
	void Start () {
        // This gets the Game Manager from the GameManager Object!
        GameObject gameManager = GameObject.Find("Game Manager");
        try
        {
            GameManager = gameManager.GetComponent<GameManager>();
        } catch (Exception e)
        {
            GameManager = SetupDummyGame();
        }
        //
        CameraScript.ChangeCamera(CameraView.Center);
        CurrentTurnState = TurnState.Start;
        GameObject Turnbutton = GameObject.Find("End Turn Button Text");
        Turnbutton.GetComponent<Text>().text = "Start game";
	}

    private GameManager SetupDummyGame()
    {
        // Method that is suppose to run if Game is not started from Welcome Scene
        PlayerStats p1 = new PlayerStats();
        PlayerStats p2 = new PlayerStats();
        p1.userName = "Hans Peter";
        p2.userName = "Grete Elisabeth";
        GameManager gm = new GameManager();
        gm.playerOne = p1;
        gm.playerTwo = p2;
        return gm;
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
        CanvasPlayerOne.SetActive(true);
        CanvasPlayerTwo.SetActive(false);
    }

    private void GiveTurnToPlayerTwo()
    {
        CameraScript.ChangeCamera(CameraView.P2);
        CurrentTurnState = TurnState.PlayerTwo;
        CanvasPlayerOne.SetActive(false);
        CanvasPlayerTwo.SetActive(true);
    }

    private void EditTurnButton()
    {
        GameObject Turnbutton = GameObject.Find("End Turn Button Text");
        Turnbutton.GetComponent<Text>().text = "End Turn";
    }


    public enum TurnState {PlayerOne, PlayerTwo, Start};
}
