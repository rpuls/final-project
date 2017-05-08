using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : Attack {
    int cannonDX;
    int cannonDY;
    AudioSource cannonAudio;
    GameObject cannon;
    public GameObject cannonBall;

    // Use this for initialization
    void Start () {
        cannonAudio = GameObject.FindGameObjectWithTag("Cannon").GetComponent<AudioSource>();
        cannon = GameObject.FindGameObjectWithTag("Cannon");
        cannonBall = GameObject.Find("CannonBall");
    }
	
	// Update is called once per frame
	void Update () {
        moveCannon();
	}


    public void moveCannon()
    {
        

        if (Input.GetKey("t")) cannonDX++;
        else if (Input.GetKey("g")) cannonDX--;
        else cannonDX = 0;
        if (Input.GetKey("f")) cannonDY--;
        else if (Input.GetKey("h")) cannonDY++;
        else cannonDY = 0;
        cannon.transform.Rotate(cannonDX, cannonDY, 0);
    }

    public override void AttackMove()
    {
        GameObject g = GameObject.Find("castle");
        g.GetComponent<Rigidbody>().isKinematic = true;
        //transform.parent.parent.GetComponent<Rigidbody>().isKinematic = true;
        int multiplier = 3000;
        //Cannonshot
        print("Fire!");
        cannonAudio.Play();
        Vector3 firepos = new Vector3(cannon.transform.position.x - 0.2f, cannon.transform.position.y, cannon.transform.position.z);
        // Make explosion to cover up spawn inacuracy?
        GameObject clone = GameObject.Instantiate(cannonBall, firepos, Quaternion.identity);
        float cannonX = cannon.transform.rotation.x + gameObject.transform.rotation.x;
        float cannonY = cannon.transform.rotation.y + gameObject.transform.rotation.y;
        print("CannonX " + cannonX * multiplier);
        print("CannonY " + cannonY * multiplier);
        clone.GetComponent<Rigidbody>().AddForce((cannon.transform.rotation) * Vector3.forward * multiplier);


        // Insert waiting -> re disable kinematic
    }
}
