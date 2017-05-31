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
    GameObject sam;
    GameObject vik;
    private bool fired;


    public GameObject cannonBall;
    public TurnManager turnManager;

    // Use this for initialization
    void Start()
    {
        sam=GameObject.Find("samurai castle");
        vik=GameObject.Find("viking castle");
        cannonAudio = GetComponent<AudioSource>();
        //cannonBall = GameObject.Find("CannonBall");
    }

    // Update is called once per frame
    void Update()
    {
        if (!fired)
        {
            moveCannon();
            if (Input.GetKey("x"))
            {
                force += 100;
            }
            else if (Input.GetKeyUp("x"))
            {
                fired = true;
                AttackMove(force);
                force = 0;
            }
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
        
        Vector3 direction = (cannon.transform.rotation) * Vector3.forward;
        //vik.GetComponent<Rigidbody>().isKinematic = true;
        //sam.GetComponent<Rigidbody>().isKinematic = true;
        if (cannon.name.Equals("ballista"))
        {
            
            //BoxCollider col=vik.GetComponent<BoxCollider>();
            
                //col.enabled = false;
            
            //BoxCollider[] scol = sam.GetComponents<BoxCollider>();
            //foreach (BoxCollider c in scol)
           // {
            //    c.enabled = false;
           // }
            //direction = new Vector3((direction.x), direction.y, direction.z);
            direction = Quaternion.Euler(0, -90, 0) * direction;
            //Quaternion.Euler
            print(direction);
        }
        else
        {
            //sam.GetComponent<Rigidbody>().isKinematic = true;
        }
        // Cloning -> getting a new cannonball 

        //GameObject clone = Instantiate(cannonBall, firepos, Quaternion.identity);
        //clone.SetActive(true);
        //clone.GetComponent<Rigidbody>().AddForce(direction * force);
        //clone.GetComponent<Rigidbody>().AddForce(Vector3.up * force/10);


        // reusing cannonball
        cannonBall.SetActive(true);
        cannonBall.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cannonBall.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        cannonBall.transform.position = firepos;
        cannonBall.transform.rotation = Quaternion.identity;
        cannonBall.GetComponent<Rigidbody>().AddForce(direction * force);
        cannonBall.GetComponent<Rigidbody>().AddForce(Vector3.up * force / 10);



        // Insert waiting -> re disable kinematic

        StartCoroutine(WaitForShot());
        //CleanUp();
        
    }
    private IEnumerator WaitForShot()
    {
        print("Wait!");
        yield return new WaitForSeconds(8f);
        print("cleanup");
        
        cannonBall.SetActive(false);
        CleanUp();
        yield return new WaitForSeconds(4f);
        turnManager.MoveIsDone(gameObject);
    }

    public void DoMove()
    {
        print("Cannon do move");
        gameObject.SetActive(true);
    }

    private void placeCastles()
    {
        sam.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        sam.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        sam.transform.position = new Vector3(-135, 3.92f, 0);
        sam.transform.rotation = Quaternion.Euler(-90, 0, 0);

        vik.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        vik.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        vik.transform.position = new Vector3(165, 3.92f, 0);
        vik.transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

    public void CleanUp()
    {

        placeCastles();
        //BoxCollider col = vik.GetComponent<BoxCollider>();
        
        //    col.enabled = true;
        
        //BoxCollider[] scol = sam.GetComponents<BoxCollider>();
        //foreach (BoxCollider c in scol)
        //{
        //    c.enabled = true;
        //}
        //vik.GetComponent<Rigidbody>().isKinematic = false;
        //sam.GetComponent<Rigidbody>().isKinematic = false;

        fired = false;
        print(sam.transform.GetComponent<Rigidbody>().velocity);
        print(sam.transform.GetComponent<Rigidbody>().angularVelocity);
        
        
    }
}
