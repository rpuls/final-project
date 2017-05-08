using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

    public TurnState CurrentTurnState;
    public GameManager GameManager;
    private MoveController MoveController;
	
	void Start () {
        // This gets the Game Manager from the GameManager Object!
        MoveController = new MoveController();
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
        GameObject PlayerNameText = GameObject.Find("Info Text");
        PlayerNameText.GetComponent<Text>().text = ("Player: " + GameManager.playerOne.userName);
        GameObject PlayerLifeText = GameObject.Find("Player Info");
        PlayerLifeText.GetComponent<Text>().text = "Life Left: " + GameManager.playerOne.lifeLeft;
    }

    private void GiveTurnToPlayerTwo()
    {
        CameraScript.ChangeCamera(CameraView.P2);
        CurrentTurnState = TurnState.PlayerTwo;
        GameObject PlayerNameText = GameObject.Find("Info Text");
        PlayerNameText.GetComponent<Text>().text = ("Player: " + GameManager.playerTwo.userName);
        GameObject PlayerLifeText = GameObject.Find("Player Info");
        PlayerLifeText.GetComponent<Text>().text = "Life Left: "+GameManager.playerTwo.lifeLeft;
    }

    private void EditTurnButton()
    {
        GameObject Turnbutton = GameObject.Find("End Turn Button Text");
        Turnbutton.GetComponent<Text>().text = "End Turn";
    }

    public void ReciveMove(String move)
    {
        MoveController.DecideMove(move, this);
    }

    public enum TurnState {PlayerOne, PlayerTwo, Start};
}
