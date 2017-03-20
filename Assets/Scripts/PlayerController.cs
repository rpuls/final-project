using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
    public GameObject cb;
	public List<GameObject> building;
	public int playerClass;
	public string playerName;
	public int score;
	public int hp;

	void Start(){
		CreatePlayer ();
	}

	void Update() {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 170.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
	}

    private void CreatePlayer() {
		/*
        print(pNumber);
        if (pNumber == 1) {
            Vector3 startPosition = new Vector3(130.8f, 4.7f, 54.9f);
            Vector3 startRotation = new Vector3(0.462f, -85.065f, -0.495f);
            transform.position = startPosition;
            transform.eulerAngles = startRotation;
            transform.localScale = new Vector3(10, 10, 10);
        }
        else if (pNumber == 2) {
            Vector3 startPosition = new Vector3(-130.8f, 4.7f, 54.9f);
            Vector3 startRotation = new Vector3(0.462f, -85.065f, -0.495f);
            transform.position = startPosition;
            transform.eulerAngles = startRotation;
            transform.localScale = new Vector3(10, 10, 10);
        }
        else print(pNumber + " players connected already!");*/
    }

    public void Fire() {
        print("Fire!");
        GameObject clone = GameObject.Instantiate(cb, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(new Vector3(5, 5, 5));
    }
	   
}
