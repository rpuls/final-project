using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour, IMove
{
    int cannonDX;
    int cannonDY;
    AudioSource cannonAudio;
    
    public GameObject cannonBall;
    public TurnManager turnManager;

    // Use this for initialization
    void Start()
    {
        cannonAudio = GetComponent<AudioSource>();
        //cannonBall = GameObject.Find("CannonBall");
    }

    // Update is called once per frame
    void Update()
    {
        moveCannon();
        if (Input.GetKeyDown("x"))
        {
            AttackMove();
        }
    }




    public void moveCannon()
    {


        if (Input.GetKey("t")) cannonDX++;
        else if (Input.GetKey("g")) cannonDX--;
        else cannonDX = 0;
        if (Input.GetKey("f")) cannonDY--;
        else if (Input.GetKey("h")) cannonDY++;
        else cannonDY = 0;
        gameObject.transform.Rotate(0, cannonDX, cannonDY);
    }

    public void AttackMove()
    {
        CameraScript.ChangeCamera(CameraView.Center);
        GameObject cannon = gameObject;
        //GameObject g = GameObject.Find("castle");
        //gameObject..GetComponent<Rigidbody>().isKinematic = true;
        //transform.parent.GetComponent<Rigidbody>().isKinematic = true;
        int multiplier = 5000;
        //Cannonshot
        print("Fire!");
        cannonAudio.Play();
        Vector3 firepos = new Vector3(cannon.transform.position.x - 0.2f, cannon.transform.position.y + 10, cannon.transform.position.z);
        // Make explosion to cover up spawn inacuracy?
        GameObject clone = GameObject.Instantiate(cannonBall, firepos, Quaternion.identity);
        Vector3 direction = (cannon.transform.rotation) * Vector3.forward;
        if (cannon.name.Equals("ballista"))
        {
            
            //direction = new Vector3((direction.x), direction.y, direction.z);
            direction = Quaternion.Euler(90, 0, 0) * direction;
            print(direction);
        }
        clone.GetComponent<Rigidbody>().AddForce(direction * multiplier);


        // Insert waiting -> re disable kinematic

        //CleanUp();
    }
    private IEnumerator WaitForShot()
    {
        
        yield return new WaitForSeconds(7f);
        CleanUp();
    }

    public void DoMove()
    {
        print("Cannon do move");
        gameObject.SetActive(true);
    }

    public void CleanUp()
    {
        //gameObject.SetActive(false);
        Debug.Log("turnmanager is null " +turnManager == null);
        Debug.Log("gameObject is " + gameObject.name);

        turnManager.MoveIsDone(gameObject);
    }
}
