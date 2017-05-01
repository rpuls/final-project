using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public static bool hasChosenCard;
	public PlayerStats playerOne;
	public PlayerStats playerTwo;
    private bool playerOneSetup = false;

    public void Start()
    {
        UnityEngine.Object.DontDestroyOnLoad(this);
    }

    public void ConFirmedClicked(){
        if (!playerOneSetup)
        {
            SetUpPlayerclass(playerOne);
            SetUpPlayerUserName(playerOne);
            ClearTextFields();
        }
        else
        {
            SetUpPlayerclass(playerTwo);
            SetUpPlayerUserName(playerTwo);
            SceneManager.LoadScene("main");
        }
	}

    private void ClearTextFields()
    {
        GameObject classDropdown = GameObject.FindWithTag("PlayerOneClass");
        classDropdown.GetComponent<Dropdown>().value = 0;
        GameObject nameInputField = GameObject.FindWithTag("PlayerUserName");
        nameInputField.GetComponent<InputField>().text = "";
        GameObject setupCanvas = GameObject.Find("setup p1");
        Color red = new Color(240.0f, 9.0f, 9.0f, 100.0f);
        setupCanvas.GetComponent<Image>().color = red;
        GameObject createButtonText = GameObject.Find("btnText");
        createButtonText.GetComponent<Text>().text = "Start Game";
        playerOneSetup = true;
    }

    private void SetUpPlayerclass(PlayerStats ps){
		GameObject classDropDown = GameObject.FindWithTag("PlayerOneClass");
		int menuIndex = classDropDown.GetComponent<Dropdown> ().value;
		List<Dropdown.OptionData> menuOptions = classDropDown.GetComponent<Dropdown> ().options;
		string selected = (menuOptions [menuIndex].text);
		ps.gameClass = selected;
	}

	public void createPlayer(){
		//GameObject.Find ("Name Input").GetComponent< find type her> ();
		GameObject.Find ("Label").GetComponent<TextMesh> ();
		//instanciate
	}


	private void SetUpPlayerUserName(PlayerStats ps){
		GameObject nameInputField = GameObject.FindWithTag("PlayerUserName");
		string username = nameInputField.GetComponent<InputField>().text;
		ps.userName = username;
	}

}

