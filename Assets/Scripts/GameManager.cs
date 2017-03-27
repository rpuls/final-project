using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public static bool hasChosenCard;
	public List<GameObject> playerPrefabs;
	public PlayerStats playerOne;
	public PlayerStats playerTwo;

	public void setPlayerOne(){
		setUpPlayerclass(playerOne);
		setUpPlayerUserName(playerOne);
	}

	private void setUpPlayerclass(PlayerStats ps){
		GameObject classDropDown = GameObject.FindWithTag("PlayerOneClass");
		int menuIndex = classDropDown.GetComponent<Dropdown> ().value;
		List<Dropdown.OptionData> menuOptions = classDropDown.GetComponent<Dropdown> ().options;
		string selected = (menuOptions [menuIndex].text);
		ps.gameClass = selected;
	}

	private void setUpPlayerUserName(PlayerStats ps){
		GameObject nameInputField = GameObject.FindWithTag("PlayerUserName");
		string username = nameInputField.GetComponent<InputField>().text;
		Debug.Log(username);
		ps.userName = username;
	}

}


