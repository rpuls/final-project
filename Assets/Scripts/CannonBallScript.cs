using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour {
    AudioSource cannonCollideAudio;
    public GameObject particlePrefab;
    public TurnManager tm;
    // Use this for initialization
    void Start () {
        cannonCollideAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        print(collision.transform.gameObject.tag);
        //if (collision.relativeVelocity.magnitude > 2)
        // Should have a reference instead of find
        
        if (collision.transform.gameObject.tag.Equals("castle"))
        {
            print("Collided with: " + collision.gameObject.tag);
            cannonCollideAudio.Play();
            Explode();
            //gameObject.GetComponent<Rigidbody>().AddExplosionForce(10000,gameObject.transform.position,100000,100);
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000, gameObject.transform.position, 1000, 100);
            var vel = GetComponent<Rigidbody>().velocity;      //to get a Vector3 representation of the velocity
            var speed = vel.magnitude;
            tm.GameManager.playerTwo.lifeLeft -= (int)speed/10;
            print(tm.GameManager.playerTwo.lifeLeft);
            //print("Velocity of Cannonball: " + vel);
            print("Speed of Cannonball: " + speed);
                
        }
    }

    void Explode()
    {

        GameObject obj = Instantiate(particlePrefab, gameObject.transform.position, gameObject.transform.rotation);
        var exp = obj.GetComponent<ParticleSystem>();
        exp.Play();
        //gameObject.SetActive(false);
        //Destroy(gameObject, 0.2f);
        //DestroyImmediate(gameObject);
    }
}
