using System;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

     public override void OnStartClient(){
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Vector3 startPosition = new Vector3(20f,4.7f,54.9f);
        transform.position= startPosition;
    }

    void Update()
    {
		if (!isLocalPlayer)
		{
    		return;
		}

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 170.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
