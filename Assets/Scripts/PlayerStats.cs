﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public string gameClass { get; set;}
	public string userName { get; set; }

	// Use this for initialization
	void Start () {
        UnityEngine.Object.DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
