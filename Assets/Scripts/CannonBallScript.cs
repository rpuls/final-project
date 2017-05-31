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
        
        // Should have a reference instead of find
        
        if (collision.transform.gameObject.tag.Equals("castle") && !CollidingWithUs(collision))
        {
            print("Collided with: " + collision.gameObject.tag);
            cannonCollideAudio.Play();
            Explode();
            //gameObject.GetComponent<Rigidbody>().AddExplosionForce(10000,gameObject.transform.position,100000,100);
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000, gameObject.transform.position, 1000, 100);
            DoDamage();
                
        }
        if (collision.transform.gameObject.tag.Equals("Wall") && !CollidingWithUs(collision))
        {
            print("Collided with: " + collision.gameObject.tag);
            cannonCollideAudio.Play();
            Explode();
            //gameObject.GetComponent<Rigidbody>().AddExplosionForce(10000,gameObject.transform.position,100000,100);
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000, gameObject.transform.position, 1000, 100);
            StartCoroutine(RemoveWall(collision));

        }

    }

    private IEnumerator RemoveWall(Collision collision)
    {
        print("Wait!");
        yield return new WaitForSeconds(5f);
        collision.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        collision.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        collision.gameObject.SetActive(false);
        if (collision.gameObject.name.Equals("samuraiwall"))
        {
            collision.gameObject.transform.position = new Vector3(-91, 3.1f, -54.4f);
            collision.gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90, 180, -80));
        }
        else if (collision.gameObject.name.Equals("woodenwall"))
        {
            collision.gameObject.transform.position = new Vector3(126.6f, 3f, 19);
            collision.gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
        }
        yield return new WaitForSeconds(1);

    }
    public bool CollidingWithUs(Collision collision)
    {
        return ((collision.gameObject.name.Equals("samurai castle") || collision.gameObject.name.Equals("samuraiwall")) && tm.CurrentTurnState==TurnManager.TurnState.PlayerTwo 
            || (collision.gameObject.name.Equals("viking castle")|| (collision.gameObject.name.Equals("woodenwall"))) && tm.CurrentTurnState == TurnManager.TurnState.PlayerOne);
    }

    public void DoDamage()
    {

        var vel = GetComponent<Rigidbody>().velocity;      //to get a Vector3 representation of the velocity
        var speed = vel.magnitude;
        if (tm.CurrentTurnState == TurnManager.TurnState.PlayerOne)
        {
            tm.GameManager.playerTwo.lifeLeft -= (int)speed / 10;
        }
        else tm.GameManager.playerOne.lifeLeft -= (int)speed / 10;
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
