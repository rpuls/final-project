using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static bool hasChosenCard;
	public enum ActivePlayer { P1, P2 };
	public List<GameObject> playerPrefabs;

	void Start() { 
        
    }
		
    
    void Update() {


    }

	public void setPlayerCalss(){

	}

	public void createPlayer(){
		GameObject.Find ("Name Input").GetComponent< find type her> ();
		GameObject.Find ("Label").GetComponent<TextMesh> ();
		//instanciate

	}
}


