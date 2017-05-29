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
    public GameObject MoveCanvas;
    public GameObject InfoCanvas;
    public bool HasPlayerChooseCard  { get; set; }
    public delegate void TurnPassed();
    public static event TurnPassed OnTurn;
	
	void Start () {
        // This gets the Game Manager from the GameManager Object!
        HasPlayerChooseCard = false;
        GameObject gameManager = GameObject.Find("Game Manager");
        try
        {
            GameManager = gameManager.GetComponent<GameManager>();
        } catch (Exception e) {
			print (e);
            GameManager = SetupDummyGame();
        }
        //
        CameraScript.ChangeCamera(CameraView.Center);
        CurrentTurnState = TurnState.Start;
        EndTurn();
	}

    private GameManager SetupDummyGame()
    {
        // Method that is suppose to run if Game is not started from Welcome Scene
        PlayerStats p1 = gameObject.AddComponent<PlayerStats>() as PlayerStats;
        PlayerStats p2 = gameObject.AddComponent<PlayerStats>() as PlayerStats;
        p1.userName = "Hans Peter";
        p2.userName = "Grete Elisabeth";
<<<<<<< HEAD
        GameManager gm = gameObject.AddComponent<GameManager>() as GameManager;
=======
        p1.lifeLeft = 100;
        p2.lifeLeft = 100;
        GameManager gm = new GameManager();
>>>>>>> master
        gm.playerOne = p1;
        gm.playerTwo = p2;
        return gm;
    }


    public void EndTurn()
    {

        if(CurrentTurnState == TurnState.Start)
        {
            Text[] infoTexts = InfoCanvas.GetComponentsInChildren<Text>();
            infoTexts[0].text = "Vikings: " + GameManager.playerOne.userName;
            infoTexts[3].text = "Samuari: " + GameManager.playerTwo.userName;
            GiveTurnToPlayerOne();
            UpdateInfoCanvas();
        }

        else if(CurrentTurnState == TurnState.PlayerOne)
        {
            GiveTurnToPlayerTwo();
            UpdateInfoCanvas();
        }

        else if(CurrentTurnState == TurnState.PlayerTwo)
        {
            GiveTurnToPlayerOne();
            UpdateInfoCanvas();
        }

        if (OnTurn != null)
        {
            OnTurn(); // TELLS OTHER GAMEOBJ that a turn has passed!
        }

    }

    private void UpdateInfoCanvas()
    {
        Text[] infoTexts = InfoCanvas.GetComponentsInChildren<Text>();
        infoTexts[1].text =  "Life Left: " + GameManager.playerOne.lifeLeft;
        infoTexts[2].text =  "Life Left: " + GameManager.playerTwo.lifeLeft;
        if (CurrentTurnState == TurnState.PlayerOne)
        {
            infoTexts[4].text = "Current Player Turn: Vikings";
        }
        else
        {
            infoTexts[4].text = "Current Player Turn: Samurai";
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

    
	/*
    private void EditTurnButton()
    {
        GameObject Turnbutton = GameObject.Find("End Turn Button Text");
        Turnbutton.GetComponent<Text>().text = "End Turn";
    }*/




    /*
     * This Method sets the Canvas
     * of the current Player Inactive
     */
    internal void SetPlayerCanvasInactive()
    {
       if(CurrentTurnState == TurnState.PlayerOne)
        {
            CanvasPlayerOne.SetActive(false);
        }
       else
        {
            CanvasPlayerTwo.SetActive(false);
        }
    }

    /*
     * Method that is called from the diffrent gameObjects that does the moves!
     * Should send its own gameobject with as a parameter, so that the turnmanager can deactivate it.
     * */
    internal void MoveIsDone(GameObject objectToBeDeactivated)
    {
        if(objectToBeDeactivated != null)
        {
            objectToBeDeactivated.SetActive(false);
        }
        MoveCanvas.SetActive(false);
        HasPlayerChooseCard = false;
        EndTurn();
    }

    public enum TurnState { PlayerOne, PlayerTwo, Start };
}
