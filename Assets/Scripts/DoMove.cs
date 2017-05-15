using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoMove : MonoBehaviour
{
    public GameObject CardGameObj;

    internal void Activate()
    {
        if (CardGameObj == null) return;
        CardGameObj.GetComponent<IMove>().DoMove();
        gameObject.SetActive(false);
    }
}
