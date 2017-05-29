using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour, IMove
{
    int cannonDX;
    int cannonDY;
    private int force;
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
        if (Input.GetKey("x"))
        {
            force += 100;
        }
        else if (Input.GetKeyUp("x"))
        {
            AttackMove(force);
            force = 0;
        }
    }




    public void moveCannon()
    {


        //if (Input.GetKey("t")) cannonDY++;
        //else if (Input.GetKey("g")) cannonDY--;
        //else cannonDY = 0;
        if (Input.GetKey("f")) cannonDX--;
        else if (Input.GetKey("h")) cannonDX++;
        else cannonDX = 0;
        gameObject.transform.Rotate(0, cannonDX, cannonDY);
    }

    public void AttackMove(int force)
    {
        //CameraScript.ChangeCamera(CameraView.Center);
        GameObject cannon = gameObject;
        //GameObject g = GameObject.Find("castle");
        //gameObject..GetComponent<Rigidbody>().isKinematic = true;
        //transform.parent.GetComponent<Rigidbody>().isKinematic = true;
        //int multiplier = 5000;

        //Cannonshot
        print("Fire!");
        cannonAudio.Play();
        Vector3 firepos = new Vector3(cannon.transform.position.x - 0.2f, cannon.transform.position.y, cannon.transform.position.z);
        print(firepos);
        // Make explosion to cover up spawn inacuracy?
        GameObject clone = GameObject.Instantiate(cannonBall, firepos, Quaternion.identity);
        Vector3 direction = (cannon.transform.rotation) * Vector3.forward;
        
        if (cannon.name.Equals("ballista"))
        {
            
            //direction = new Vector3((direction.x), direction.y, direction.z);
            direction = Quaternion.Euler(0, -90, 0) * direction;
            //Quaternion.Euler
            print(direction);
        }
        clone.GetComponent<Rigidbody>().AddForce(direction * force);
        clone.GetComponent<Rigidbody>().AddForce(Vector3.up * force/100);

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
