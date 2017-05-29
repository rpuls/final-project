using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
    Attack attack;
    // Use this for initialization
    void Start () {
        //attack = gameObject.AddComponent<Attack>() as Attack;
        //attack = gameObject.AddComponent<CannonScript>() as CannonScript;


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("x")) attack.AttackMove();
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
