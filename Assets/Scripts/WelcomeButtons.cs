﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeButtons : MonoBehaviour {


	public void GoToMain(){
		SceneManager.LoadScene ("main");
	}


	public void YouSuck(){
		Application.Quit();
	}
}
