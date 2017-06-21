using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour {

    public int animationSpeedSeconds = 3;

    // Use this for initialization
    void Start () {
        Hashtable EndPosition = iTween.Hash("x", 165f, "y", 25f, "z", 0f, "time", animationSpeedSeconds);
        iTween.MoveTo(this.gameObject, EndPosition);
        StartCoroutine(KillYouSelf());
	}

    private IEnumerator KillYouSelf()
    {
        yield return new WaitForSeconds(animationSpeedSeconds);
        Destroy(this.gameObject);
    }

}
