using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
    public GameObject cb;
    AudioSource cannonAudio;
    GameObject cannon;
    public int cannonDX;
    public int cannonDY;
    // Use this for initialization
    void Start () {
        cannon = GameObject.FindGameObjectWithTag("Cannon");
        cannonAudio = GameObject.FindGameObjectWithTag("Cannon").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        moveCannon();
        
    }

    void moveCannon()
    {
        if (Input.GetKeyUp("x")) Attack();

        if (Input.GetKey("t")) cannonDX++;
        else if (Input.GetKey("g")) cannonDX--;
        else cannonDX = 0;
        if (Input.GetKey("f")) cannonDY--;
        else if (Input.GetKey("h")) cannonDY++;
        else cannonDY = 0;
        cannon.transform.Rotate(cannonDX, cannonDY, 0);
    }
    void Attack()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        int multiplier = 3000;
        //Cannonshot
        print("Fire!");
        cannonAudio.Play();
        Vector3 firepos = new Vector3(cannon.transform.position.x-0.2f, cannon.transform.position.y, cannon.transform.position.z);
        // Make explosion to cover up spawn inacuracy?
        GameObject clone = GameObject.Instantiate(cb, firepos, Quaternion.identity);
        float cannonX = cannon.transform.rotation.x + gameObject.transform.rotation.x;
        float cannonY = cannon.transform.rotation.y + gameObject.transform.rotation.y;
        print("CannonX "+cannonX * multiplier);
        print("CannonY "+cannonY * multiplier);
        clone.GetComponent<Rigidbody>().AddForce((cannon.transform.rotation)*Vector3.forward*multiplier);
        

        // Insert waiting -> re disable kinematic
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        //if (collision.relativeVelocity.magnitude > 2)
        

    }
    
}
